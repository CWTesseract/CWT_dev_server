using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CWT_dev_server.CWTNet;
using CWTNet;
using Steamworks;

namespace CWT_dev_server
{
    class Client
    {
        private CSteamID m_hostSteamID;
        private Callback<P2PSessionRequest_t> m_P2PSessionRequest;
        private bool m_isChatClientOnly = false;

        UInt64 GUID;
        Vector3Int64 Position; 

        public Client(UInt64 SteamID, bool chatClient = false)
        {
            m_hostSteamID = new CSteamID(SteamID);
            m_P2PSessionRequest = Callback<P2PSessionRequest_t>.Create(OnP2PSessionRequest);
            m_isChatClientOnly = chatClient;


            GUID = 2;
            Position = new CWTNet.Vector3Int64(23540680, 117517965, 7672954);
        }

        void OnP2PSessionRequest(P2PSessionRequest_t pCallback)
        {
            bool ok = SteamNetworking.AcceptP2PSessionWithUser(pCallback.m_steamIDRemote);
        }

        /// <summary>
        /// A simple little function to join force-join a server unauthenticated and send chat messages.
        /// </summary>
        void DoNonAuthenticatedChat()
        {

            // Make steam happy.
            new Thread(() => {
                SteamAPI.RunCallbacks();
                if (SteamNetworking.IsP2PPacketAvailable(out uint packetSize, (int)CWTNet.Channel.SC))
                {
                    byte[] data = new byte[packetSize];
                    bool ok = SteamNetworking.ReadP2PPacket(data, packetSize, out uint newPacketSize, out CSteamID remoteSteamID, (int)CWTNet.Channel.SC);
                }
            }).Start();
            
            // Join the game.
            var joinPacket = new CWTNet.Packets.CS.ClientJoinPacket();
            PacketUtil.SendP2PPacket(m_hostSteamID, joinPacket);

            Thread.Sleep(1000);

            Console.WriteLine("Type your messages:");
            while (true)
            {
                var message = Console.ReadLine();
                PacketUtil.SendP2PPacket(m_hostSteamID, new CWTNet.Packets.CS.ClientChatMessage(message));
            }
        }
        
        public void Start()
        {

            Console.WriteLine("Client running under steam user: {0}", SteamFriends.GetPersonaName());


            // Go into chatting mode if selected.
            if (m_isChatClientOnly) { 
                DoNonAuthenticatedChat();
                return;
            }

            // Join the game.
            var joinPacket = new CWTNet.Packets.CS.ClientJoinPacket();
            PacketUtil.SendP2PPacket(m_hostSteamID, joinPacket);


            Stopwatch posUpdateWatch = new Stopwatch();
            posUpdateWatch.Start();

            while (true)
            {
                SteamAPI.RunCallbacks();

                // Send our client updates to the server.
                if(posUpdateWatch.ElapsedMilliseconds >= 1000)
                {
                    posUpdateWatch.Restart();

                    Console.WriteLine("Sending creature update...");
                    var creatureUpdatePacket = new CWTNet.Packets.CS.ClientCreatureUpdate();
                    creatureUpdatePacket.data.GUID = 2;
                    creatureUpdatePacket.data.Position = Position;
                    PacketUtil.SendP2PPacket(m_hostSteamID, creatureUpdatePacket);

                    // Zone discovery
                    Console.WriteLine("Sending Zone discovery update...");
                    var loadZone = new CWTNet.Packets.CS.DiscoverZone((int)((Position.X/65536)/64), (int)((Position.Y / 65536) / 64));
                    PacketUtil.SendP2PPacket(m_hostSteamID, loadZone);
                }

                // Read the servers updates for the client.
                if (SteamNetworking.IsP2PPacketAvailable(out uint packetSize, (int)CWTNet.Channel.SC))
                {
                    byte[] data = new byte[packetSize];
                    bool ok = SteamNetworking.ReadP2PPacket(data, packetSize, out uint newPacketSize, out CSteamID remoteSteamID, (int)CWTNet.Channel.SC);
                    using (var readMemoryStream = new MemoryStream(data))
                    {
                        var rdr = new BinaryReader(readMemoryStream);
                        SCPacketType opcode = (SCPacketType)rdr.ReadUInt32();


                        
                        switch (opcode)
                        {
                            case SCPacketType.SC_CREATURE_UPDATE:
                                Console.WriteLine("Got packet:{0}", opcode);
                                var serverCreatureUpdatePacket = new CWTNet.Packets.SC.ServerCreatureUpdate();
                                serverCreatureUpdatePacket.Deserialize(ref rdr);
                                var update = serverCreatureUpdatePacket.data;

                                /*
                                if (update.ClientSteamID.HasValue)
                                {
                                    Console.WriteLine("\tClientSteamID: {0}", update.ClientSteamID);
                                }
                                */
                                Console.WriteLine("\tGUID: {0}", update.GUID);
                                Console.WriteLine(update.ChangesToString(indent: 1));


                                break;

                            case SCPacketType.SC_SET_PLAYER_GUID:
                                Console.WriteLine("Got packet:{0}", opcode);
                                var setPlayerGUIDPacket = new CWTNet.Packets.SC.SetPlayerGUID(0);
                                setPlayerGUIDPacket.Deserialize(ref rdr);
                                    
                                Console.WriteLine("\tGUID: {0}", setPlayerGUIDPacket.m_GUID);

                                GUID = setPlayerGUIDPacket.m_GUID;
                                break;

                            case SCPacketType.SC_SERVER_UPDATE:
                                Console.WriteLine("Got packet:{0}", opcode);
                                var serverUpdateData = rdr.ReadBytes((int)packetSize - 4);
                                Console.WriteLine("\t{0}", BitConverter.ToString(serverUpdateData));
                                break;

                            case SCPacketType.SC_INVITATION:
                                Console.WriteLine("Got packet:{0}", opcode);
                                var invitationPacket = new CWTNet.Packets.SC.Invitation(0);
                                invitationPacket.Deserialize(ref rdr);

                                Console.WriteLine("\tVersion: {0}", invitationPacket.m_gameVersion);

                                // If force-joining gets patched, then we can just accept invitations like normal:
                                //var joinPacket = new CWTNet.Packets.CS.ClientJoinPacket();
                                //PacketUtil.SendP2PPacket(remoteSteamID, joinPacket);

                                break;

                            case SCPacketType.SC_SET_TIME:
                                /*
                                Console.WriteLine("Got packet:{0}", opcode);
                                var setTimePacket = new CWTNet.Packets.SC.SetTime(0, 0);
                                setTimePacket.Deserialize(ref rdr);
                                Console.WriteLine("\tDay: {0}", setTimePacket.m_day);
                                Console.WriteLine("\tTime: {0}", setTimePacket.m_time);
                                */
                                break;

                            default:
                                Console.WriteLine("Got unparsed packet from server: {0}, Size:0x{1:X}", opcode, packetSize);
                                break;
                        }
                        
                    }
                }

                Thread.Sleep(100);

            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CWTNet;
using Steamworks;

namespace CWT_dev_server
{
    class Server
    {
        private CSteamID m_RemoteSteamID;
        private Callback<P2PSessionRequest_t> m_P2PSessionRequest;


        // 1.0.0-0 == 100000
        // 0.9.1-5 ==  91005
        private static readonly uint SERVER_GAME_VERSION = 91005;

        public Server()
        {
            m_RemoteSteamID = new CSteamID(0);
            m_P2PSessionRequest = Callback<P2PSessionRequest_t>.Create(OnP2PSessionRequest);
        }

        void OnP2PSessionRequest(P2PSessionRequest_t pCallback)
        {
            Console.WriteLine("[OnP2PSessionRequest] -- Got session request from {0}", pCallback.m_steamIDRemote);

            bool ok = SteamNetworking.AcceptP2PSessionWithUser(pCallback.m_steamIDRemote);
            Console.WriteLine("[OnP2PSessionRequest] -- Accept ok: {0}", ok);

            m_RemoteSteamID = pCallback.m_steamIDRemote;
        }

        public void Start()
        {
            Console.WriteLine("Server running under steam user: {0}", SteamFriends.GetPersonaName());
            Console.WriteLine("CWD: {0}", Directory.GetCurrentDirectory());
            Console.WriteLine("AppID: {0}", SteamUtils.GetAppID());

            Stopwatch inviteStopWatch = new Stopwatch();
            inviteStopWatch.Start();

            while (true)
            {

                SteamAPI.RunCallbacks();

                // Send the friends an invite every 5 seconds.
                var friendsCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
                if (friendsCount > 0 && inviteStopWatch.ElapsedMilliseconds > 5000)
                {
                    // Restart the stopwatch.
                    inviteStopWatch.Restart();

                    for (int i = 0; i < friendsCount; i++)
                    {
                        CSteamID friend = SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate);
                        Console.WriteLine("[Server] Inviting friend[{0}], steamID: {1}", i, friend.m_SteamID);


                        var invitationPacket = new CWTNet.Packets.SC.Invitation(SERVER_GAME_VERSION);
                        PacketUtil.SendP2PPacket(friend, invitationPacket, CWTNet.Channel.SC);
                    }
                }

                // Read packets
                if (SteamNetworking.IsP2PPacketAvailable(out uint packetSize, (int)CWTNet.Channel.CS))
                {
                    byte[] data = new byte[packetSize];
                    bool ok = SteamNetworking.ReadP2PPacket(data, packetSize, out uint newPacketSize, out CSteamID remoteSteamID, 1);
                    using (var readMemoryStream = new MemoryStream(data))
                    {
                        var rdr = new BinaryReader(readMemoryStream);
                        CSPacketType opcode = (CSPacketType)rdr.ReadUInt32();
                        switch (opcode)
                        {
                            case CSPacketType.CS_CLIENT_JOIN:
                                var clientJoinPacket = new CWTNet.Packets.CS.ClientJoinPacket();
                                clientJoinPacket.Deserialize(ref rdr);

                                Console.WriteLine(opcode);
                                Console.WriteLine("\tSteamID: {0}", remoteSteamID);

                                Thread.Sleep(1* 1000);

                                // Send them a welcome message :).
                                Console.WriteLine("Sending chat packet");
                                var serverChatMessage = new CWTNet.Packets.SC.ServerChatMessage(0, "Welcome to the CWT dev server!");
                                PacketUtil.SendP2PPacket(remoteSteamID, serverChatMessage);


                                Thread.Sleep(1 * 1000);

                                // Send them a GUID.
                                var setPlayerGUIDPacket = new CWTNet.Packets.SC.SetPlayerGUID(2);
                                PacketUtil.SendP2PPacket(remoteSteamID, setPlayerGUIDPacket);

                                Thread.Sleep(1 * 1000);

                                // Send them the UNK6 packet. Don't know what this does tbh.
                                var unk6Packet = new CWTNet.Packets.SC.Unk6();
                                PacketUtil.SendP2PPacket(remoteSteamID, unk6Packet);

                                // Set the time.
                                var setTimePacket = new CWTNet.Packets.SC.SetTime(0, 0);
                                PacketUtil.SendP2PPacket(remoteSteamID, setTimePacket);



                                break;
                            case CSPacketType.CS_DISCOVER_ZONE:
                                var discoverZonePacket = new CWTNet.Packets.CS.DiscoverZone(0, 0);
                                discoverZonePacket.Deserialize(ref rdr);

                                /*
                                Console.WriteLine(opcode);
                                Console.WriteLine("\tZoneX:{0}, ZoneY:{1}", discoverZonePacket.m_zoneX, discoverZonePacket.m_zoneY);
                                */
                                break;

                            case CSPacketType.CS_CREATURE_UPDATE:
                                var creatureUpdatePacket = new CWTNet.Packets.CS.ClientCreatureUpdate();
                                creatureUpdatePacket.Deserialize(ref rdr);
                                var update = creatureUpdatePacket.data;

                                Console.WriteLine("\tGUID: {0}", update.GUID);
                                Console.WriteLine(update.ChangesToString(indent: 1));
                                break;


                            default:
                                Console.WriteLine("Got unparsed packet: {0}, Size:{1}", opcode, packetSize);
                                break;
                        }


                    }
                }

                Thread.Sleep(10);
            }
        }
    }
}

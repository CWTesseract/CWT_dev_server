using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWTNet;
using Steamworks;


namespace CWT_dev_server
{
    public static class PacketUtil
    {
        public static void SendP2PPacket(CSteamID steamID, CWTNet.CSPacket packet)
        {
            SendP2PPacket(steamID, packet, CWTNet.Channel.CS);
        }

        public static void SendP2PPacket(CSteamID steamID, CWTNet.SCPacket packet)
        {
            SendP2PPacket(steamID, packet, CWTNet.Channel.SC);
        }

        public static void SendP2PPacket(CSteamID steamID, CWTNet.IPacket packet, CWTNet.Channel channel)
        {
            using (var writeMemoryStream = new MemoryStream())
            {
                var wtr = new BinaryWriter(writeMemoryStream);

                wtr.Write((uint)packet.GetPacketOpcode());
                packet.Serialize(ref wtr);
                wtr.Flush();

                var packetData = writeMemoryStream.ToArray();
                SteamNetworking.SendP2PPacket(steamID, packetData, (uint)packetData.Length, EP2PSend.k_EP2PSendReliable, (int)channel);
            }
        }
    }
}

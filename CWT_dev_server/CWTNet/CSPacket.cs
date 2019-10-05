using CWTNet;

namespace CWT_dev_server.CWTNet
{
    public class CSPacket : PacketBase
    {
        public CSPacketType m_packetType { get; protected set; }

        public override uint GetPacketOpcode()
        {
            return (uint)m_packetType;
        }
    }
}

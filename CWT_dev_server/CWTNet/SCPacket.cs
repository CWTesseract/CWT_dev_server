using CWTNet;

namespace CWT_dev_server.CWTNet
{
    public class SCPacket : PacketBase
    {
        public SCPacketType m_packetType { get; protected set; }

        public override uint GetPacketOpcode()
        {
            return (uint)m_packetType;
        }
    }
}

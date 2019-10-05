using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWTNet;

namespace CWT_dev_server.CWTNet.Packets.CS
{
    public class DiscoverZone : CSPacket
    {
        public Int32 m_zoneX;
        public Int32 m_zoneY;

        public DiscoverZone(Int32 zoneX, Int32 zoneY)
        {
            m_packetType = CSPacketType.CS_DISCOVER_ZONE;
            m_zoneX = zoneX;
            m_zoneY = zoneY;
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
            wtr.Write((int)m_zoneX);
            wtr.Write((int)m_zoneY);
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
            m_zoneX = rdr.ReadInt32();
            m_zoneY = rdr.ReadInt32();
        }
    }
}

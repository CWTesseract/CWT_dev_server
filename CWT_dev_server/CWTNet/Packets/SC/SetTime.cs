using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWTNet;

namespace CWT_dev_server.CWTNet.Packets.SC
{
    public class SetTime : SCPacket
    {
        public UInt32 m_day;
        public UInt32 m_time;

        public SetTime(UInt32 day, UInt32 time)
        {
            m_packetType = SCPacketType.SC_SET_TIME;
            m_day = day;
            m_time = time;
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
            wtr.Write((uint)m_day);
            wtr.Write((uint)m_time);
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
            m_day = rdr.ReadUInt32();
            m_time = rdr.ReadUInt32();
        }
    }
}

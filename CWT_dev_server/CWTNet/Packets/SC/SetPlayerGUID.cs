using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWTNet;

namespace CWT_dev_server.CWTNet.Packets.SC
{
    public class SetPlayerGUID : SCPacket
    {
        public UInt64 m_GUID;

        public SetPlayerGUID(UInt32 GUID)
        {
            m_packetType = SCPacketType.SC_SET_PLAYER_GUID;
            m_GUID = GUID;
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
            wtr.Write((long)m_GUID);
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
            m_GUID = rdr.ReadUInt64();
        }
    }
}

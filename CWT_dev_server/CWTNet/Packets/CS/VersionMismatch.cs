using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWTNet;

namespace CWT_dev_server.CWTNet.Packets.CS
{
    public class VesionMismatch : CSPacket
    {
        public UInt32 m_gameVersion; // e.g. 91005 for 0.9.1-5

        public VesionMismatch(UInt32 gameVersion)
        {
            m_packetType = CSPacketType.CS_VERSION_MISMATCH;
            m_gameVersion = gameVersion;
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
            wtr.Write((uint)m_gameVersion);
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
            m_gameVersion = rdr.ReadUInt32();
        }
    }
}
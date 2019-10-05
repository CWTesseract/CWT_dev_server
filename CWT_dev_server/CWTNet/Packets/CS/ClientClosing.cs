using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWTNet;


namespace CWT_dev_server.CWTNet.Packets.CS
{
    class ClientClosing : CSPacket
    {
        public ClientClosing()
        {
            m_packetType = CSPacketType.CS_CLIENT_CLOSING;
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
        }
    }
}
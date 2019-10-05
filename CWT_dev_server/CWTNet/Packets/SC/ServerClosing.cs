using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWTNet;


namespace CWT_dev_server.CWTNet.Packets.SC
{
    class ServerClosing : SCPacket
    {
        public ServerClosing()
        {
            m_packetType = SCPacketType.SC_SERVER_CLOSING;
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
        }
    }
}
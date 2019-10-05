using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWTNet;


namespace CWT_dev_server.CWTNet.Packets.SC
{
    class ServerCreatureUpdate : SCPacket
    {
        public Shared.CreatureUpdateData data;

        public ServerCreatureUpdate()
        {
            data = new Shared.CreatureUpdateData();
            m_packetType = SCPacketType.SC_CREATURE_UPDATE;
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
            data.Serialize(ref wtr);
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
            data.Deserialize(ref rdr);
        }
    }
}
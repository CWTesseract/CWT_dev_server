using CWTNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWT_dev_server.CWTNet
{
    public class PacketBase : IPacket
    {

        public virtual uint GetPacketOpcode()
        {
            return uint.MaxValue;
        }

        public byte[] Serialize()
        {
            using (var ms = new MemoryStream())
            {
                var wtr = new BinaryWriter(ms);
                Serialize(ref wtr);
                wtr.Flush();
                ms.Flush();
                return ms.GetBuffer();
            }
        }

        public void Deserialize(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                var rdr = new BinaryReader(ms);
                Deserialize(ref rdr);
                rdr.Close();
            }
        }

        public virtual void Serialize(ref BinaryWriter wtr)
        {

            throw new NotImplementedException();
        }

        public virtual void Deserialize(ref BinaryReader rdr)
        {
            throw new NotImplementedException();
        }
    }
}

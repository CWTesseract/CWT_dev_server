using System.IO;

namespace CWT_dev_server.CWTNet
{
    public interface IPacket
    {
        uint GetPacketOpcode();

        byte[] Serialize();
        void Deserialize(byte[] data);

        void Serialize(ref BinaryWriter wtr);
        void Deserialize(ref BinaryReader rdr);
    }
}

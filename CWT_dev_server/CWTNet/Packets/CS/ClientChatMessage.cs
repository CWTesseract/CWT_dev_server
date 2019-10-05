using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWTNet;

namespace CWT_dev_server.CWTNet.Packets.CS
{
    public class ClientChatMessage : CSPacket
    {
        public string m_message;

        public ClientChatMessage(string message)
        {
            m_packetType = CSPacketType.CS_CLIENT_CHAT_MESSAGE;
            m_message = message;
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
            var messageBytes = Encoding.Unicode.GetBytes(m_message);
            wtr.Write((uint)(messageBytes.Length / 2)); // UTF16, len is sent in characters, not bytes.
            wtr.Write(messageBytes);
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
            var messageLength = rdr.ReadUInt32();
            var messageBytes = new byte[messageLength * 2];
            m_message = Encoding.Unicode.GetString(messageBytes);
        }
    }
}
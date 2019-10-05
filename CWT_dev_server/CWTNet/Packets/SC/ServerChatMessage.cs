using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CWTNet;

namespace CWT_dev_server.CWTNet.Packets.SC
{
    public class ServerChatMessage : SCPacket
    {
        public UInt64 m_GUID;
        public string m_message;

        public ServerChatMessage(UInt64 GUID, string message)
        {
            m_packetType = SCPacketType.SC_CHAT_MESSAGE;
            m_GUID = GUID;
            m_message = message;
        }

        public override void Serialize(ref BinaryWriter wtr)
        {
            var messageBytes = Encoding.Unicode.GetBytes(m_message);
            wtr.Write((long)m_GUID);
            //wtr.Write((int)Int32.MaxValue); // Crash client
            wtr.Write((uint)(messageBytes.Length / 2)); // UTF16, len is sent in characters, not bytes.
            wtr.Write(messageBytes);
        }

        public override void Deserialize(ref BinaryReader rdr)
        {
            m_GUID = rdr.ReadUInt64();
            var messageLength = rdr.ReadUInt32();
            var messageBytes = new byte[messageLength * 2];
            m_message = Encoding.Unicode.GetString(messageBytes);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWTNet
{

    // Server -> Client types:
    public enum SCPacketType : uint
    {
        SC_INVITATION = 0,
        /* 1 ? */
        SC_SERVER_CLOSING = 2,
        SC_CREATURE_UPDATE = 3,
        SC_SET_PLAYER_GUID = 4,
        /* 5 ? */
        SC_UNK_0x6 = 6,
        SC_SERVER_UPDATE = 7,
        SC_SET_TIME = 8,
        /* 0x9-0xD ? */
        SC_CHAT_MESSAGE = 0xE,
    };

    // Client -> Server types:
    public enum CSPacketType : uint
    {
        CS_UNK_0x0 = 0,
        CS_CLIENT_JOIN = 1,
        CS_CLIENT_CLOSING = 2, // Or revoking invitation.
        CS_CREATURE_UPDATE = 3,
        /* 4-8 ? */
        CS_UNK_0x9 = 9,
        CS_UNK_0xA = 0xA,
        CS_UNK_0xB = 0xB,
        CS_UNK_0xC = 0xC,
        CS_UNK_0xD = 0xD,
        CS_CLIENT_CHAT_MESSAGE = 0xE,
        CS_DISCOVER_ZONE = 0xF,
        /* 0x10-0x17 ? */
        CS_VERSION_MISMATCH = 0x18,
    };
}

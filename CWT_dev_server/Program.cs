using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Steamworks;
using CWTNet;
using System.Diagnostics;

namespace CWT_dev_server
{
    class Program
    {
        private static SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;
        private static void SteamAPIDebugTextHook(int nSeverity, System.Text.StringBuilder pchDebugText)
        {
            Console.WriteLine("STEAM DEBUG: {0}", pchDebugText.ToString());
        }

        static void Main(string[] args)
        { 
            // Init steam.
            var init_result = SteamAPI.Init();
            Console.WriteLine("SteamAPI.Init() result: {0}", init_result);

            // Install an warning handler.
            m_SteamAPIWarningMessageHook = new SteamAPIWarningMessageHook_t(SteamAPIDebugTextHook);
            SteamClient.SetWarningMessageHook(m_SteamAPIWarningMessageHook);


            // Switch between a fake server and a fake client.
            var runningServer = true;
            if (runningServer)
            {
                var server = new Server();
                server.Start();
            }
            else
            {
                var client = new Client(UInt64.Parse(args[0]));
                client.Start();
            }

            Thread.Sleep(5 * 1000);
        }
    }

    
}

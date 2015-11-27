using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB.net
{
    class WiFiStatus
    {
        public WiFiNetwork Network;
        public bool Connected, Active;

        #region Static
        public void Update()
        {
            bool done = false;
            bool ssid = false;
            CConsole.GCFM("wifi").OutputReceived += (output, e) =>
            {
                if (ssid == false)
                {
                    Network.SSID = output;
                    ssid = true;
                } else {
                    Network.Strength = int.Parse(output);
                }

            };
            CConsole.GCFM("wifi").ExecuteCommand(
                "adb shell \"dumpsys netstats | grep - io networkId =.* | sed 's/networkId=//;s/]]//' | head - n 1\"");

            while (!done)
                Application.DoEvents();
        }
        #endregion
    }
}

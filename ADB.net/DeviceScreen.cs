using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB.net
{
    public class DeviceScreen
    {
        public static Image TakeScreenshot()
        {
            try
            {
                bool sc = false;
                CConsole.GCFM("ss").OutputReceived += (output, e) => {
                    if (output.Contains("done"))
                        sc = true;
                };
                CConsole.GCFM("ss").ExecuteCommand(@"adb shell screencap -p | sed ""s/\r$//"" > sc.png & echo done");

                while (!sc)
                    Application.DoEvents();

                Image img = Image.FromStream(new MemoryStream(File.ReadAllBytes("./sc.png")));

                return img;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SimulateTap(int x, int y)
        {
            CConsole.GCFM("sinput").ExecuteCommand("adb shell input touchscreen tap " + x + " " + y);
        }

        public static void SimulateSwipe(int x1, int y1, int x2, int y2)
        {
            CConsole.GCFM("sinput").ExecuteCommand("adb shell input touchscreen swipe " + x1 +
                " " + y1 + " " + x2 + " " + y2);
        }
        public static void SimulateSwipe(int x1, int y1, int x2, int y2, long ms)
        {
            CConsole.GCFM("sinput").ExecuteCommand("adb shell input touchscreen swipe " + x1 +
                " " + y1 + " " + x2 + " " + y2 + " " + ms);
        }
    }
}

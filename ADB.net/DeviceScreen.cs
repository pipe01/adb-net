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
        private static CConsole consoleSS = new CConsole();
        public static Image TakeScreenshot()
        {
            bool fin = false;
            bool sc = false;
            consoleSS.OutputReceived += (output, e) => {
                if (output.Contains("fin"))
                    sc = true;
                if (output.Contains("fin2"))
                    fin = true;
            };
            consoleSS.ExecuteCommand("adb shell screencap -p /mnt/sdcard/sc.png; echo fin");

            while (!sc)
                Application.DoEvents();

            string cmd = "adb pull -p /mnt/sdcard/sc.png \"" + Path.GetDirectoryName(Application.ExecutablePath).Replace("\\", "/") + "/media\" & echo fin2";
            consoleSS.ExecuteCommand(cmd);

            while (!fin)
                Application.DoEvents();

            Image img = Image.FromStream(new MemoryStream(File.ReadAllBytes("./media/sc.png")));

            File.Delete("./media/sc.png");

            return img;
        }
        public static Image TakeScreenshot2()
        {
            try
            {
                bool sc = false;
                consoleSS.OutputReceived += (output, e) => {
                    if (output.Contains("done"))
                        sc = true;
                };
                consoleSS.ExecuteCommand(@"adb shell screencap -p | sed ""s/\r$//"" > sc.png & echo done");

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

        private static CConsole consoleInput = new CConsole();
        public static void SimulateTap(int x, int y)
        {
            consoleInput.ExecuteCommand("adb shell input touchscreen tap " + x + " " + y);
        }

        public static void SimulateSwipe(int x1, int y1, int x2, int y2)
        {
            consoleInput.ExecuteCommand("adb shell input touchscreen swipe " + x1 +
                " " + y1 + " " + x2 + " " + y2);
        }
        public static void SimulateSwipe(int x1, int y1, int x2, int y2, long ms)
        {
            consoleInput.ExecuteCommand("adb shell input touchscreen swipe " + x1 +
                " " + y1 + " " + x2 + " " + y2 + " " + ms);
        }
    }
}

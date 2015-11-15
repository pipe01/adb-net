using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB.net
{
    public class AppManager
    {
        public static List<App> GetAllApps() 
        {
            bool done = false;
            List<App> ls1 = new List<App>();
            CConsole.GCFM("apps").OutputReceived += (output, e) =>
            {
                if (output.StartsWith("package:"))
                {
                    ls1.Add(new App(output.Substring("package:".Length)));
                }
                else if (output.Contains("@done@"))
                    done = true;
            };
            CConsole.GCFM("apps").ExecuteCommand("adb shell pm list packages; echo @done@");

            while (!done)
                Application.DoEvents();

            return ls1;
        }

        public static bool PullInstalledAPK(string package)
        {
            bool done = false;
            bool errored = false;
            string apkpath = "";

            apkpath = "/data/app/" + package + "*";

            CConsole.GCFM("apps").OutputReceived += (output, e) =>
            {
                if (output == "no")
                    errored = true;
                else if (output == "done")
                    done = true;
            };
            CConsole.GCFM("apps").ExecuteCommand("");
            return false;
        }
    }
}

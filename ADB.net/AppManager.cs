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
        private static CConsole consoleApps1 = new CConsole();
        public static List<App> GetAllApps() 
        {
            bool done = false;
            List<App> ls1 = new List<App>();
            consoleApps1.OutputReceived += (output, e) =>
            {
                if (output.StartsWith("package:"))
                {
                    ls1.Add(new App(output.Substring("package:".Length - 1)));
                }
                else if (output.Contains("@done@"))
                    done = true;
            };
            consoleApps1.ExecuteCommand("adb shell pm list packages; echo @done@");

            while (!done)
                Application.DoEvents();

            return ls1;
        }
    }
}

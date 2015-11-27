using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB.net
{
    public class ConsoleLog
    {
        public delegate void LogHandler(string line, EventArgs e);
        public static event LogHandler LogWritten;
        public static List<string> Log = new List<string>();

        public static void WriteToLog(string str, string ID)
        {
            Log.Add(str);
            if (LogWritten != null)
                LogWritten(ID + ": " + str, EventArgs.Empty);
        }
    }
}

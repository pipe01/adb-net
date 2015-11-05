using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB.net
{
    public class CConsole
    {
        public static List<string> log = new List<string>();

        public static event LogHandler LogWritten;
        public delegate void LogHandler(string line, EventArgs e);
        public event OutputHandler OutputReceived;
        public delegate void OutputHandler(string output, EventArgs e);
        public EventArgs e = null;
        public void ExecuteCommand(string command, params string[] args)
        {
            string com = command;
            int i = 0;
            foreach (string item in args)
            {
                com = com.Replace("${" + i + "}", args[i]);
                i++;
            }

            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.OutputDataReceived += P_OutputDataReceived;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "CMD.exe";
            p.StartInfo.Arguments = "/c " + command;
            p.Start();
            p.BeginOutputReadLine();
        }

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (OutputReceived != null)
            {
                if (e.Data == null)
                    OutputReceived("null", e);
                else
                    OutputReceived(e.Data, e);
            }
            if (e.Data != null && e.Data != "")
            {
                log.Add(e.Data);
                LogWritten(e.Data, EventArgs.Empty);
            }
        }
    }
}

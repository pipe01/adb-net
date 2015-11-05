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

        private Process consoleP;

        public CConsole()
        {
            Init();
        }

        public void Init()
        {
            if (consoleP == null)
            {
                consoleP = new Process();

                consoleP.OutputDataReceived += P_OutputDataReceived;
                consoleP.StartInfo.UseShellExecute = false;
                consoleP.StartInfo.RedirectStandardOutput = true;
                consoleP.StartInfo.RedirectStandardInput = true;
                consoleP.StartInfo.CreateNoWindow = true;
                consoleP.StartInfo.FileName = "CMD.exe";
                consoleP.Start();
                consoleP.BeginOutputReadLine();
            }
        }

        public void ExecuteCommand(string command, params string[] args)
        {
            string com = command;
            int i = 0;
            foreach (string item in args)
            {
                com = com.Replace("${" + i + "}", args[i]);
                i++;
            }

            //consoleP.StartInfo.Arguments = "/c " + command;

            consoleP.StandardInput.WriteLine("@" + com);
            consoleP.StandardInput.Flush();

        }

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (OutputReceived != null)
            {
                if (e.Data.Split('@')[0].Contains(">")) return;
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

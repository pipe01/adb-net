using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Collections.Specialized;

namespace ADB.net
{
    public class CConsole
    {
        public static List<string> log = new List<string>();

        public static event LogHandler LogWritten;
        public delegate void LogHandler(string line, EventArgs e);
        public event OutputHandler OutputReceived;
        public delegate void OutputHandler(string output, EventArgs e);

        public bool showWindows = false;
        public bool outputToLog = true;

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
                consoleP.StartInfo.CreateNoWindow = !showWindows;
                consoleP.StartInfo.FileName = "CMD.exe";
                consoleP.Start();
                consoleP.BeginOutputReadLine();
            }
        }

        public void ExecuteCommand(string command)
        {
            consoleP.StandardInput.WriteLine("@" + command);
            consoleP.StandardInput.Flush();

        }

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (OutputReceived != null)
            {
                if (e.Data != null && e.Data.Split('@')[0].Contains(">")) return;
                if (e.Data != null)
                    OutputReceived(e.Data, e);
            }
            if (e.Data != null && e.Data != "" && outputToLog)
            {
                log.Add(e.Data);
                LogWritten(e.Data, EventArgs.Empty);
            }
        }

        public void RestartConsole()
        {
            if (consoleP != null)
            {
                consoleP.Close();
                consoleP.WaitForExit();
                consoleP = null;
                Init();
            }
        }

        #region "Static"
        private MemoryCache memCache = new MemoryCache("PathCache", new NameValueCollection()
                                    {
                                      { "CacheMemoryLimitMegabytes", "256" },
                                      { "PhysicalMemoryLimit", "50" }
                                    });
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace ADB.net
{
    public class CConsole
    {
        public delegate void LogHandler(string line, EventArgs e);
        public event OutputHandler OutputReceived;
        public delegate void OutputHandler(string output, EventArgs e);

        public string ID;

        public bool showWindows = false;
        public bool outputToLog = true;

        public string outputFilter = "[*]";

        private Process consoleP;

        public CConsole(string id)
        {
            ID = id;
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
                consoleP.StartInfo.Arguments = "/K";
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
                if (e.Data != null) //&& Regex.IsMatch(e.Data, outputFilter))
                    OutputReceived(e.Data, e);
            }
            if (e.Data != null && e.Data != "" && outputToLog)
            {
                WriteToLog(e.Data);
            }
        }

        public void RestartConsole()
        {
            if (consoleP != null)
            {
                consoleP.Kill();
                consoleP.WaitForExit();
                consoleP = null;
                Init();
            }
        }

        public void KillConsole()
        {
            if (consoleP != null)
            {
                consoleP.Kill();
                consoleP.WaitForExit();
                consoleP = null;
                memCache.Remove(ID);
            }
        }

        public void WriteToLog(string str)
        {
            log.Add(str);
            if (LogWritten != null)
                LogWritten(ID + ": " + str, EventArgs.Empty);
        }

        public void SendCntrlC()
        {
            consoleP.StandardInput.WriteLine("x3");
        }

        #region "Static"
        public static event LogHandler LogWritten;
        public static MemoryCache memCache = new MemoryCache("PathCache", new NameValueCollection()
                                    {
                                      { "CacheMemoryLimitMegabytes", "256" },
                                      { "PhysicalMemoryLimit", "50" }
                                    });
        public static CConsole GCFM(string key, bool create = true)
        {
            if (memCache.Contains(key))
            {
                return memCache[key] as CConsole;
            } else {
                if (create)
                {
                    memCache.Add(key, new CConsole(key), new CacheItemPolicy());
                    (memCache[key] as CConsole).Init();
                    return memCache[key] as CConsole;
                } else
                    return null;
            }
        }
        public static void Dispose()
        {
            memCache.Dispose();
        }
        public static void SendCntrlCAll()
        {
            foreach (var item in memCache)
            {
                (item.Value as CConsole).SendCntrlC();
            }
        }
        public static void RestartAll()
        {
            foreach (var item in memCache)
            {
                (item.Value as CConsole).RestartConsole();
            }
        }

        public static void KillAll()
        {
            foreach (var item in memCache)
            {
                (item.Value as CConsole).KillConsole();
            }
        }

        public static List<string> log = new List<string>();
        #endregion
    }
}

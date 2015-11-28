using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB.net
{
    public class FileSystem
    {
        /// <summary>
        /// Checks if the indicated path is a directory
        /// </summary>
        /// <param name="filename">Path to check</param>
        /// <returns></returns>
        public static bool IsDirectory(string filename)
        {
            bool ret = false;
            bool isd = false;
            CConsole.GCFM("fs2").OutputReceived += (output, e) =>
            {
                if (output == "yes")
                {
                    isd = true;
                    ret = true;
                }
                else if (output == "done")
                {
                    ret = true;
                }
            };
            string cmd = "cd " + filename + " && echo yes; echo done";
            if (AndroidDevice.IsRooted())
            {
                CConsole.GCFM("fs2").ExecuteCommand("adb shell");
                CConsole.GCFM("fs2").ExecuteCommand("su");
            }
            CConsole.GCFM("fs2").ExecuteCommand(cmd);

            while (!ret)
                Application.DoEvents();

            return isd;
        }

        /// <summary>
        /// Lists all files and directories
        /// </summary>
        /// <param name="path">Directory to list</param>
        /// <param name="recursive">Lists sub-directories</param>
        /// <param name="sort">Sort the returned list by alphabetical order</param>
        /// <returns></returns>
        public static List<string> GetAllEntries(string path, bool recursive = false, bool sort = true)
        {
            bool ret = false;
            List<string> entries = new List<string>();

            CConsole.GCFM("fs1").OutputReceived += (output, e) =>
            {
                if (output == "" || output == null || output == "null" ||
                                    output.Contains("Not a directory") ||
                                    output.Contains("Permission denied")) return;

                if (output == "terminado")
                {
                    ret = true;
                    return;
                }

                entries.Add(output);

                if (recursive && IsDirectory(path + "/" + output))
                {
                    entries.AddRange(GetAllEntries(path + "/" + output, true));
                }
            };
            CConsole.GCFM("fs1").ExecuteCommand("adb shell \"cd '" + path + "' && ls; echo terminado\"");

            while (!ret)
                Application.DoEvents();

            if (sort)
            {
                entries.Sort();
            }
            return entries;
        }

        public static bool Exists(string path)
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            bool exists = false;
            CConsole.GCFM("fs2").OutputReceived += (output, e) => 
            {
                if (output == "yes")
                {
                    exists = true;
                    mre.Set();
                } else if (output == "no") {
                    mre.Set();
                }
            };
            CConsole.GCFM("fs2").ExecuteCommand("adb shell [ -e " + path + "]; then echo yes; else echo no; fi;");

            mre.WaitOne();

            return exists;
        }

        public static bool PullFile(string dPath, string cPath, out int progress)
        {
            bool done = false;
            bool success = false;
            int p = 0;
            progress = p;
            CConsole.GCFM("fs2").OutputReceived += (output, e) =>
            {
                if (output.Contains("%)"))
                {
                    string tmp = output;
                    tmp = tmp.Split('(')[1];
                    tmp = tmp.Split('%')[0];
                    p = int.Parse(tmp);
                } else if (output == "done") {
                    done = true;
                    success = true;
                } else if (output == "no") {
                    done = true;
                }
            };
            CConsole.GCFM("fs2").ExecuteCommand("adb pull -p \"" + dPath + "\" \"" + cPath + "\" && echo done || echo no");

            while (!done)
            {
                progress = p;
                Application.DoEvents();
            }

            return success;
        }

        public static void PushFile(string dPath, string cPath)
        {
            CConsole.GCFM("fs2").ExecuteCommand("adb push -p \"" + cPath + "\" \"" + dPath + "\"");
        }
    }
}

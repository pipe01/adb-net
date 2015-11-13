using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            bool ret, ex;
            ret = false;
            ex = false;
            CConsole.GCFM("fs2").OutputReceived += (output, e) =>
            {
                if (output == "yes")
                {
                    ret = true;
                    ex = true;
                }
                else if (output == "no")
                {
                    ret = true;
                    ex = false;
                }
            };
            CConsole.GCFM("fs2").ExecuteCommand("adb shell if [ -d \"" + filename + "\" ]; then echo \"yes\"; else echo \"no\"; fi;");
            //consoleFS1.ExecuteCommand("adb shell [ -d \"${0}\" ] && echo \"yes\" || echo \"no\"", filename);

            while (!ret)
                Application.DoEvents();

            return ex;
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
                if (output == "" || output == null || output == "null") return;
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
            CConsole.GCFM("fs1").ExecuteCommand("adb shell cd " + path + ";ls; echo terminado");

            while (!ret)
                Application.DoEvents();

            if (sort)
            {
                entries.Sort();
            }
            return entries;
        }

        public static void PullFile(string dPath, string cPath)
        {
            CConsole.GCFM("fs2").ExecuteCommand("adb pull -p \"" + dPath + "\" \"" + cPath + "\"");
        }

        public static void PushFile(string dPath, string cPath)
        {
            CConsole.GCFM("fs2").ExecuteCommand("adb push -p \"" + cPath + "\" \"" + dPath + "\"");
        }
    }
}

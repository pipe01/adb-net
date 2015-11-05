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
        private static CConsole consoleFS1 = new CConsole();
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
            consoleFS1.OutputReceived += (output, e) =>
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
            consoleFS1.ExecuteCommand("adb shell if [ -d \"" + filename + "\" ]; then echo \"yes\"; else echo \"no\"; fi;");
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
            consoleFS1.OutputReceived += (output, e) =>
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
            consoleFS1.ExecuteCommand("adb shell cd " + path + ";ls; echo terminado");

            while (!ret)
                Application.DoEvents();

            if (sort)
            {
                entries.Sort();
            }
            return entries;
        }
        public static List<string> GetAllEntries2(string path)
        {
            List<string> entries = new List<string>();
            string currDir = path;
            bool fin = false;
            consoleFS1.OutputReceived += (output, e) =>
              {
                  if (output == "OK") fin = true;
                  if (output.Contains("opendir failed")) return;
                  if (output.StartsWith("./"))
                  {
                      currDir = path + output.Substring(2);
                      //entries.Remove(output.Substring(2));
                  } else if (output != "null")
                  {
                      entries.Add(currDir + "/" + output);
                  }
              };
            //if (AndroidDevice.IsRooted())
            //{
                consoleFS1.ExecuteCommand("adb shell su;ls -R;echo OK");
            //}
            //else
            //{
            //    consoleFS1.ExecuteCommand("adb shell ls -R;echo OK");
            //}

            while (!fin)
                Application.DoEvents();

            return entries;
            
        }

        private static CConsole consoleFS2 = new CConsole();
        public static void PullFile(string dPath, string cPath)
        {
            consoleFS2.ExecuteCommand("adb pull -p \"" + dPath + "\" \"" + cPath + "\"");
        }

        public static void PushFile(string dPath, string cPath)
        {
            consoleFS2.ExecuteCommand("adb push -p \"" + cPath + "\" \"" + dPath + "\"");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB.net
{
    public class AndroidDevice
    {
        /// <summary>  
        /// Connects to a device over WiFi ADB.
        /// </summary>  
        /// <param name="ip">IP of the device to connect.</param>  
        /// <returns>True if succesfully connected</returns>  
        public static bool ConnectOverWifi(string ip)
        {
            string ret = "";
            CConsole.GCFM("connect").OutputReceived += (output, e) =>
            {
                ret = output;
            };
            CConsole.GCFM("connect").ExecuteCommand("adb connect " + ip);

            while (!ret.Contains("connect"))
            {
                Application.DoEvents();
            }

            if (ret.Contains("connected"))
            {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>  
        /// Disconnects from the current WiFi ADB device (if any).
        /// No output will be shown on log.
        /// </summary>  
        /// <returns></returns>  
        public static void Disconnect()
        {
            CConsole.GCFM("connect").ExecuteCommand("adb disconnect");
        }

        /// <summary>  
        /// Gets the current device's battery status.
        /// See <seealso cref="BatteryStatus"/>.
        /// </summary>  
        /// <returns>A BatteryStatus object with the battery's current status.</returns>  
        public static BatteryStatus GetBatteryStatus()
        {
            BatteryStatus status = new BatteryStatus();
            string lvl = null;
            string ac = null;

            CConsole.GCFM("battery").OutputReceived += (output, e) =>
            {
                if (output.Contains("level:") && !output.Contains("level: 50"))
                    lvl = output.Trim();
                else if (output.Contains("AC powered:"))
                    ac = output.Trim().Split()[2];
            };
            CConsole.GCFM("battery").ExecuteCommand("adb shell dumpsys battery");

            while (lvl == null)
                Application.DoEvents();

            status.Level = int.Parse(lvl.Split()[1]);

            while (ac == null)
                Application.DoEvents();

            status.ACConnected = bool.Parse(ac);

            return status;
        }

        /// <summary>
        /// Detects if any device is connected and online, either WiFi or USB.
        /// </summary>
        /// <returns></returns>
        public static bool IsDevicePresent()
        {
            bool present = false;
            bool ret = false;
            CConsole.GCFM("devices").OutputReceived += (output, e) =>
            {
                if (output.Contains("\t") && output.Contains("device"))
                {
                    present = true;
                    ret = true;
                }
                else if (output == "done" && present == false)
                {
                    ret = true;
                }
            };
            CConsole.GCFM("devices").ExecuteCommand("adb devices & echo done");

            while (!ret)
                Application.DoEvents();

            return present;
        }

        /// <summary>
        /// Waits until a device is connected and up
        /// </summary>
        /// <returns></returns>
        public static void WaitForDevice()
        {
            bool done = false;
            CConsole.GCFM("devices").OutputReceived += (output, e) =>
            {
                if (output == "done") done = true;
            };
            CConsole.GCFM("devices").ExecuteCommand("adb wait-for-device & echo done");

            while (!done)
                Application.DoEvents();
        }

        /// <summary>
        /// If there is a device connected, returns the device's model (ro.product.model)
        /// </summary>
        /// <returns></returns>
        public static string GetDeviceModel()
        {
            bool ret = false;
            string model = null;
            CConsole.GCFM("devices").OutputReceived += (output, e) =>
            {
                if (output.Contains("error"))
                {
                    model = "error";
                    ret = true;
                }
                else if (output != "" && output != null && output != "null")
                {
                    model = output;
                    ret = true;
                }
            };
            CConsole.GCFM("devices").ExecuteCommand("adb shell getprop ro.product.model");

            while (!ret)
                Application.DoEvents();

            return model;
        }

        /// <summary>
        /// Checks if the device is rooted by executing "su"
        /// </summary>
        /// <returns></returns>
        public static bool IsRooted()
        {
            bool root = false;
            bool ret = false;
            CConsole.GCFM("devices").OutputReceived += (output, e) =>
            {
                if (output.Contains("#"))
                {
                    root = true;
                    ret = true;
                } else {
                    root = false;
                    ret = true;
                }
            };
            CConsole.GCFM("devices").ExecuteCommand("adb shell su");

            while (!ret)
                Application.DoEvents();

            return root;
        }

        /// <summary>
        /// Simulates a soft/hard key event on the device.
        /// </summary>
        /// <param name="keyevent">Key to be simulated. See http://developer.android.com/reference/android/view/KeyEvent.html </param>
        public static void SimulateKeyEvent(string keyevent)
        {
            CConsole.GCFM("input").ExecuteCommand("adb shell input keyevent " + keyevent);
        }

        /// <summary>
        /// Types the passed string in a simulated hard keyboard
        /// </summary>
        /// <param name="str">String to type</param>
        public static void TypeString(string str, string keycode_space = "KEYCODE_SPACE")
        {
            string[] split = str.Split(' ');
            for (int i = 0; i < split.Length; i++)
            {
                CConsole.GCFM("input").ExecuteCommand("adb shell input text \"" + split[i] + "\"");
                if (i != split.Length - 1) SimulateKeyEvent(keycode_space);
            }
        }
    }
}

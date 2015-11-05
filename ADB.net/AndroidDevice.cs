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
        private static CConsole consoleConnect;
        /// <summary>  
        /// Connects to a device over WiFi ADB.
        /// </summary>  
        /// <param name="ip">IP of the device to connect.</param>  
        /// <returns>True if succesfully connected</returns>  
        public static bool ConnectOverWifi(string ip)
        {
            string ret = "";
            consoleConnect = new CConsole();
            consoleConnect.OutputReceived += (output, e) =>
            {
                ret = output;
            };
            consoleConnect.ExecuteCommand("adb connect " + ip);

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

        private static CConsole consoleDisconnect = new CConsole();
        /// <summary>  
        /// Disconnects from the current WiFi ADB device (if any).
        /// No output will be shown on log.
        /// </summary>  
        /// <returns></returns>  
        public static void Disconnect()
        {
            consoleDisconnect.ExecuteCommand("adb disconnect");
        }

        private static CConsole consoleBattery = new CConsole();
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
            
            consoleBattery.OutputReceived += (output, e) =>
            {
                if (output.Contains("level:") && !output.Contains("level: 50"))
                    lvl = output.Trim();
                else if (output.Contains("AC powered:"))
                    ac = output.Trim().Split()[2];
            };
            consoleBattery.ExecuteCommand("adb shell dumpsys battery");

            while (lvl == null)
                Application.DoEvents();

            status.Level = int.Parse(lvl.Split()[1]);

            while (ac == null)
                Application.DoEvents();

            status.ACConnected = bool.Parse(ac);

            return status;
        }

        private static CConsole consoleDevices = new CConsole();
        /// <summary>
        /// Detects if any device is connected and online, either WiFi or USB.
        /// </summary>
        /// <returns></returns>
        public static bool IsDevicePresent()
        {
            bool present = false;
            bool ret = false;
            consoleDevices.OutputReceived += (output, e) =>
            {
                if (output.Contains("\t") && output.Contains("device"))
                {
                    present = true;
                    ret = true;
                }
                else if (output == "null" && present == false)
                {
                    ret = true;
                }
            };
            consoleDevices.ExecuteCommand("adb devices");

            while (!ret)
                Application.DoEvents();

            return present;
        }

        public static string GetDeviceModel()
        {
            bool ret = false;
            string model = null;
            consoleDevices.OutputReceived += (output, e) =>
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
            consoleDevices.ExecuteCommand("adb shell getprop ro.product.model");

            while (!ret)
                Application.DoEvents();

            return model;
        }

        public static bool IsRooted()
        {
            CConsole console = new CConsole();
            bool root = false;
            bool ret = false;
            console.OutputReceived += (output, e) =>
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
            console.ExecuteCommand("adb shell su");

            while (!ret)
                Application.DoEvents();

            return root;
        }
    }
}

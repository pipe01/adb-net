using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB.net
{
    public class AndroidDevice
    {
        #region Private Stuff
        private static bool AnyDevice = false;
        private static void Update()
        {
            if (GetState() == AdbState.Device)
            {
                AnyDevice = true;
            }
            else
            {
                AnyDevice = false;
                SelectedDeviceSerial = null;
            }

            if (AnyDevice && SelectedDeviceSerial != null && IsDevicePresent(SelectedDeviceSerial)) ; // Any better way of doing this?
            else
            {
                if (AnyDevice)
                    SelectedDeviceSerial = GetAllDevices()[0];
                else SelectedDeviceSerial = null;
            }
        }
        #endregion

        /// <summary>
        /// The device in which all the adb commands will be executed on (-s).
        /// If SelectedDeviceSerial is not set/the device doesnt exist and there is at
        /// least one device connected, SelectedDeviceSerial will be set to the first
        /// detected device
        /// </summary>
        public static string SelectedDeviceSerial;

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
            Update();
            if (!AnyDevice) return null;

            ManualResetEvent mre = new ManualResetEvent(false);
            BatteryStatus status = new BatteryStatus();
            string lvl = null;
            string ac = null;

            CConsole.GCFM("battery").OutputReceived += (output, e) =>
            {
                if (output.Contains("level:") && !output.Contains("level: 50"))
                {
                    lvl = output.Trim();
                    mre.Set();
                }
                else if (output.Contains("AC powered:"))
                {
                    ac = output.Trim().Split()[2];
                    mre.Set();
                }
            };
            CConsole.GCFM("battery").ExecuteCommand("adb -s " + SelectedDeviceSerial +"  shell dumpsys battery");

            mre.WaitOne();

            status.ACConnected = bool.Parse(ac);

            mre.Reset();
            mre.WaitOne();

            status.Level = int.Parse(lvl.Split()[1]);
            
            return status;
        }

        public enum AdbState
        {
            Offline,
            Bootloader,
            Device,
            Unknown
        }
        /// <summary>
        /// Returns the current ADB state
        /// </summary>
        /// <returns></returns>
        public static AdbState GetState()
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            AdbState ret = AdbState.Unknown;
            CConsole.GCFM("devices").OutputReceived += (output, e) =>
            {
                switch(output)
                {
                    case "offline": ret = AdbState.Offline; mre.Set(); break;
                    case "bootloader": ret = AdbState.Bootloader; mre.Set(); break;
                    case "device": ret = AdbState.Device; mre.Set(); break;
                }
            };
            CConsole.GCFM("devices").ExecuteCommand("adb get-state");

            mre.WaitOne();

            return ret;
        }

        /// <summary>
        /// Checks if the device is connected and online.
        /// </summary>
        /// <param name="Serial">Serial of the device to check</param>
        /// <returns></returns>
        public static bool IsDevicePresent(string Serial)
        {
            bool present = false;
            ManualResetEvent mre = new ManualResetEvent(false);
            CConsole.GCFM("devices").OutputReceived += (output, e) =>
            {
                if (output.Contains(Serial) && output.Contains("device"))
                {
                    present = true;
                    mre.Set();
                }
                else if (output == "done" && present == false)
                {
                    mre.Set();
                }
            };
            CConsole.GCFM("devices").ExecuteCommand("adb devices & echo done");

            mre.WaitOne();

            return present;
        }

        /// <summary>
        /// Returns a list with all connected devices and emulators, if any
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllDevices()
        {
            List<string> devs = new List<string>();
            ManualResetEvent mre = new ManualResetEvent(false);

            CConsole.GCFM("devices").OutputReceived += (output, e) =>
            {
                if (output.Contains("\t"))
                {
                    string[] split = output.Split('\t');
                    if (split[1] == "device")
                        devs.Add(split[0]);
                } else if (output == "done")
                    mre.Set();
            };
            CConsole.GCFM("devices").ExecuteCommand("adb devices & echo done");

            mre.WaitOne();

            return devs;
        }

        /// <summary>
        /// Waits until a device is connected
        /// </summary>
        /// <returns></returns>
        public static void WaitForDevice()
        {
            ManualResetEvent mre = new ManualResetEvent(false);
            CConsole.GCFM("devices").OutputReceived += (output, e) =>
            {
                if (output == "done") mre.Set();
            };
            CConsole.GCFM("devices").ExecuteCommand("adb wait-for-device & echo done");

            mre.WaitOne();
        }

        /// <summary>
        /// If there is a device connected, returns the device's model (ro.product.model)
        /// </summary>
        /// <returns></returns>
        public static string GetDeviceModel()
        {
            Update();
            if (!AnyDevice) return null;

            ManualResetEvent mre = new ManualResetEvent(false);
            string model = null;
            CConsole.GCFM("devices2").OutputReceived += (output, e) =>
            {
                if (output.Contains("error"))
                {
                    model = "error";
                    mre.Set();
                }
                else if (output != "" && output != null && output != "null")
                {
                    model = output;
                    mre.Set();
                }
            };
            CConsole.GCFM("devices2").ExecuteCommand("adb -s " + SelectedDeviceSerial +
                                                    " shell getprop ro.product.model");

            mre.WaitOne();

            return model;
        }

        /// <summary>
        /// Checks if the device is rooted by executing "su"
        /// </summary>
        /// <returns></returns>
        public static bool IsRooted()
        {
            Update();
            if (!AnyDevice) return false;

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
            CConsole.GCFM("devices").ExecuteCommand("adb -s " + SelectedDeviceSerial + 
                                                                            " shell su");

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
            Update();
            if (!AnyDevice) return;

            CConsole.GCFM("input").ExecuteCommand("adb -s " + SelectedDeviceSerial +
                                                " shell input keyevent " + keyevent);
        }

        /// <summary>
        /// Types the passed string in a simulated hard keyboard
        /// </summary>
        /// <param name="str">String to type</param>
        public static void TypeString(string str, string keycode_space = "KEYCODE_SPACE")
        {
            Update();
            if (!AnyDevice) return;

            string[] split = str.Split(' ');
            for (int i = 0; i < split.Length; i++)
            {
                CConsole.GCFM("input").ExecuteCommand("adb -s " + SelectedDeviceSerial + 
                                            " shell input text \"" + split[i] + "\"");

                if (i != split.Length - 1) SimulateKeyEvent(keycode_space);
            }
        }
    }
}

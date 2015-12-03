using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADB.net;
using PiConfig;
using System.IO;

namespace ADB_Helper
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public ConfigFile config = new ConfigFile();
        private bool ListeningLogcat = false;

        private void LoadConfig()
        {
            config.Load();
            updDevices.Interval = int.Parse(config.Get("updateInterval")) * 1000;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            trayIcon.Icon = this.Icon;
            ConsoleLog.LogWritten += Cconsole_LogWritten;
            LoadConfig();
            //updDevices_Tick(sender, e);
        }

        private delegate void AddLineDelegate(string line);
        private void AddLine(string line)
        {
            listBox1.Items.Add(line);
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        StreamWriter stream = File.AppendText("log.txt");
        private void Cconsole_LogWritten(string line, EventArgs e)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new AddLineDelegate(AddLine), line);
                stream.WriteLine(line);
            }
        }

        private void updDevices_Tick(object sender, EventArgs e)
        {
            if (!updTask.IsBusy)
                updTask.RunWorkerAsync();
        }

        private delegate void UpdDeviceDelegate(string txt);
        private void UpdDevice(string txt)
        {
            Device dev = Device.GetDeviceByName(txt);
            if (dev == null)
            {
                this.Text = "Pipe's ADB Helper";
                lblDeviceModel.Text = "-";
            }
            else
            {
                this.Text = "Pipe's ADB Helper - " + dev.vendor + " " + dev.name;
                lblDeviceModel.Text = dev.vendor + " " + dev.name;
                if (pAC != AC)
                {
                    batteryForm.batteryDisplay1.AC = AC;
                    batteryForm.batteryDisplay1.BatteryLevel = blvl;
                    batteryForm.Show();
                    tFormBattery.Start();
                }
                batteryDisplay1.AC = AC;
                batteryDisplay1.BatteryLevel = blvl;
                batteryDisplay1.RefreshImg();
                batteryDisplay1.Refresh();
                trayIcon.Text = dev.vendor + " " + dev.name + " (" + blvl.ToString() + "%)";
            }
        }

        frmBatteryDisplay batteryForm = new frmBatteryDisplay();
        List<string> devices = new List<string>();
        int blvl;
        bool AC,pAC;
        private void updTask_DoWork(object sender, DoWorkEventArgs e)
        {
            AndroidDevice.AdbState present = AndroidDevice.GetState();
            if (present == AndroidDevice.AdbState.Device)
            {
                BatteryStatus status = AndroidDevice.GetBatteryStatus();
                blvl = status.Level;
                pAC = AC;
                AC = status.ACConnected;
                this.Invoke(new UpdDeviceDelegate(UpdDevice), AndroidDevice.GetDeviceModel());
            }
            else
            {
                this.Invoke(new UpdDeviceDelegate(UpdDevice), "null");
                blvl = 0;
                AC = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updTask.RunWorkerAsync();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (config.Get("disconnectAtExit") == "true")
                AndroidDevice.Disconnect();
            trayIcon.Visible = false;
            stream.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AndroidDevice.Disconnect();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
            Application.ExitThread();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmConfig().ShowDialog();
            config.Load();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (config.Get("connectAtStartup") == "true")
            {
                string ip = config.Get("defaultDeviceIp");
                if (ip != null)
                    AndroidDevice.ConnectOverWifi(ip);
                updDevices_Tick(sender, e);
            }
        }

        private void tFormBattery_Tick(object sender, EventArgs e)
        {
            batteryForm.Hide();
            tFormBattery.Stop();
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new frmFileExplorer().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmRemoteControl frm = new frmRemoteControl();
            //frm.pictureBox1.BackgroundImage = AndroidDevice.TakeScreenshot();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new frmAppManager().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CConsole.RestartAll();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (AndroidDevice.ConnectOverWifi(config.Get("defaultDeviceIp")))
            {
                updTask.RunWorkerAsync();
            }
        }

        private void btnLogcat_Click(object sender, EventArgs e)
        {
            ListeningLogcat = !ListeningLogcat;
            if (ListeningLogcat)
            {
                AndroidDevice.NotificationEvent += AndroidDevice_NotificationEvent;
                AndroidDevice.StartLogcatListener();
                btnLogcat.Text = "Logcat On";
            }
            else
            {
                AndroidDevice.StopLogcatListener();
                btnLogcat.Text = "Logcat Off";
            }
        }

        private void AndroidDevice_NotificationEvent(Notification notification)
        {
            MessageBox.Show(notification.PackageName);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            CConsole.KillAll();
        }
    }
}

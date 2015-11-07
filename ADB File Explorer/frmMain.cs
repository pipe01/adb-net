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
    public partial class btnScreenshot : Form
    {
        public btnScreenshot()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public ConfigFile config = new ConfigFile();
        private void LoadConfig()
        {
            config.Load();
            updDevices.Interval = int.Parse(config.Get("updateInterval")) * 1000;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            trayIcon.Icon = this.Icon;
            CConsole.LogWritten += Cconsole_LogWritten;
            LoadConfig();
            updDevices_Tick(sender, e);
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

        private delegate void UpdDeviceModelDelegate(string txt);
        private void UpdDeviceModel(string txt)
        {
            Device dev = Device.GetDeviceByName(txt);
            if (dev == null)
            {
                this.Text = "Pipe's ADB Helper" + (txt == "null" ? null : " - " + txt);
                lblDeviceModel.Text = txt == "null" ? "-" : txt;
            }
            else
            {
                this.Text = "Pipe's ADB Helper" + dev.vendor + " " + dev.name;
                lblDeviceModel.Text = dev.vendor + " " + dev.name;
            }
        }

        frmBatteryDisplay batteryForm = new frmBatteryDisplay();
        List<string> devices = new List<string>();
        int blvl;
        bool AC,pAC;
        private void updTask_DoWork(object sender, DoWorkEventArgs e)
        {
            if (AndroidDevice.IsDevicePresent())
            {
                BatteryStatus status = AndroidDevice.GetBatteryStatus();
                blvl = status.Level;
                pAC = AC;
                AC = status.ACConnected;
                this.Invoke(new UpdDeviceModelDelegate(UpdDeviceModel), AndroidDevice.GetDeviceModel());
                updTask.ReportProgress(0);
            }
            else
            {
                this.Invoke(new UpdDeviceModelDelegate(UpdDeviceModel), "null");
                blvl = 0;
                AC = false;
            }

        }

        private void updTask_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (pAC != AC)
            {
                batteryForm.batteryDisplay1.AC = AC;
                batteryForm.batteryDisplay1.BatteryLevel = blvl;
                batteryForm.Show();
                tFormBattery.Start();
            }
            batteryDisplay1.AC = AC;
            batteryDisplay1.BatteryLevel = blvl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updDevices_Tick(sender, e);
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
            string ip = config.Get("defaultDeviceIp");
            if (ip != null)
                AndroidDevice.ConnectOverWifi(ip);
            updDevices_Tick(sender, e);
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

        private void txbConnect_OKClicked(object sender, EventArgs e)
        {
            if (AndroidDevice.ConnectOverWifi(txbConnect.Value))
            {
                Application.Restart();
            }
        }
    }
}

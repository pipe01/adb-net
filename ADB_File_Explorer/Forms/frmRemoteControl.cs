using ADB.net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB_Helper
{
    public partial class frmRemoteControl : Form
    {
        public frmRemoteControl()
        {
            InitializeComponent();
        }

        private bool Work = false;

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!Work)
            {
                Work = true;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                Work = false;
            }
        }

        private delegate void UpdatePicDelegate();
        private void UpdatePic()
        {
            touchScreen1.RefreshScreen();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Work)
            {
                touchScreen1.Invoke(new UpdatePicDelegate(UpdatePic));
            }
        }

        private void frmScreenshot_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdatePic();
        }

        private void frmScreenshot_Load(object sender, EventArgs e)
        {
            Dictionary<string, NavBar> navBars = NavBar.GetAllAvailable();
            navBar1.NavBar = navBars.Values.First();
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            AndroidDevice.SimulateKeyEvent("KEYCODE_POWER");
        }

        private void btnVolUp_Click(object sender, EventArgs e)
        {
            AndroidDevice.SimulateKeyEvent("KEYCODE_VOLUME_UP");
        }

        private void btnVolDown_Click(object sender, EventArgs e)
        {
            AndroidDevice.SimulateKeyEvent("KEYCODE_VOLUME_DOWN");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            AndroidDevice.TypeString(txtInputText.Text);
        }

        private void touchScreen1_Resize(object sender, EventArgs e)
        {
            navBar1.Width = touchScreen1.Width;
            navBar1.Top = touchScreen1.Height;
        }
    }
}

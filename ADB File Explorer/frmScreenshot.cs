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
    public partial class frmScreenshot : Form
    {
        public frmScreenshot()
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

        }
    }
}

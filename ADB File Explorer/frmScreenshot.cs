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

        private delegate void UpdatePicDelegate(Image pic);
        private void UpdatePic(Image pic)
        {
            picScreen.BackgroundImage = null;
            picScreen.BackgroundImage = pic;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Work)
            {
                Image sc = AndroidDevice.TakeScreenshot();
                picScreen.Invoke(new UpdatePicDelegate(UpdatePic), sc);
            }
        }

        private void frmScreenshot_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("./media/sc.png")) File.Delete("./media/sc.png");
            Image sc = AndroidDevice.TakeScreenshot();
            UpdatePic(sc);
        }
    }
}

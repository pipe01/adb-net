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

namespace ADB_Helper
{
    public partial class frmBatteryDisplay : Form
    {
        public frmBatteryDisplay()
        {
            InitializeComponent();
        }

        private void frmBatteryDisplay_Shown(object sender, EventArgs e)
        {
            //Determine "rightmost" screen
            Screen rightmost = Screen.AllScreens[0];
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
                    rightmost = screen;
            }

            this.Left = rightmost.WorkingArea.Right - this.Width;
            this.Top = rightmost.WorkingArea.Bottom - this.Height;
        }

        private void frmBatteryDisplay_Load(object sender, EventArgs e)
        {
            //BatteryStatus status = AndroidDevice.GetBatteryStatus();
            //batteryDisplay1.BatteryLevel = status.Level;
            //batteryDisplay1.AC = status.ACConnected;
        }

        private void batteryDisplay1_Load(object sender, EventArgs e)
        {

        }
    }
}

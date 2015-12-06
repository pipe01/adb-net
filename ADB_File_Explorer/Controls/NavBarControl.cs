using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADB.net;
using System.Diagnostics;

namespace ADB_Helper
{
    public partial class NavBarControl : UserControl
    {
        public NavBarControl()
        {
            InitializeComponent();
        }

        private const string KEY_HOME = "HOME";
        private const string KEY_BACK = "BACK";
        private const string KEY_RECENT = "APP_SWITCH";

        private NavBar navBar;
        public NavBar NavBar
        {
            get { return navBar; }
            set
            {
                navBar = value;
                RefreshNav();
            }
        }

        private void RefreshNav()
        {
            if (navBar == null) return;
            picBtn1.BackgroundImage = navBar.buttonRecent;
            picBtn2.BackgroundImage = navBar.buttonHome;
            picBtn3.BackgroundImage = navBar.buttonBack;

            picBtn1.BackColor = navBar.bgColor;
            picBtn2.BackColor = navBar.bgColor;
            picBtn3.BackColor = navBar.bgColor;
        }

        private void NavBar_Resize(object sender, EventArgs e)
        {
            picBtn1.Width = this.Width / 3;
            picBtn2.Width = this.Width / 3;
            picBtn3.Width = this.Width / 3;

            picBtn1.Left = 0;
            picBtn2.Left = picBtn1.Width;
            picBtn3.Left = this.Width - picBtn3.Width;
        }

        private Stopwatch sw1 = new Stopwatch();
        private void picBtn1_MouseDown(object sender, MouseEventArgs e)
        {
            sw1.Reset();
            sw1.Start();
        }
        private void picBtn1_MouseUp(object sender, MouseEventArgs e)
        {
            sw1.Stop();
            AndroidDevice.SimulateKeyEvent("KEYCODE_" + KEY_RECENT,
                sw1.ElapsedMilliseconds >= 500 ? true : false);
        }

        private Stopwatch sw2 = new Stopwatch();
        private void picBtn2_MouseDown(object sender, MouseEventArgs e)
        {
            sw2.Reset();
            sw2.Start();
        }
        private void picBtn2_MouseUp(object sender, MouseEventArgs e)
        {
            sw2.Stop();
            AndroidDevice.SimulateKeyEvent("KEYCODE_" + KEY_HOME,
                sw2.ElapsedMilliseconds >= 500 ? true : false);
        }

        private Stopwatch sw3 = new Stopwatch();
        private void picBtn3_MouseDown(object sender, MouseEventArgs e)
        {
            sw3.Reset();
            sw3.Start();
        }
        private void picBtn3_MouseUp(object sender, MouseEventArgs e)
        {
            sw3.Stop();
            AndroidDevice.SimulateKeyEvent("KEYCODE_" + KEY_BACK,
                sw3.ElapsedMilliseconds >= 500 ? true : false);
        }
    }
}

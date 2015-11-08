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

        private void picBtn1_Click(object sender, EventArgs e)
        {
            AndroidDevice.SimulateKeyEvent("KEYCODE_" + KEY_RECENT);
        }

        private void picBtn2_Click(object sender, EventArgs e)
        {
            AndroidDevice.SimulateKeyEvent("KEYCODE_" + KEY_HOME);
        }

        private void picBtn3_Click(object sender, EventArgs e)
        {
            AndroidDevice.SimulateKeyEvent("KEYCODE_" + KEY_BACK);
        }
    }
}

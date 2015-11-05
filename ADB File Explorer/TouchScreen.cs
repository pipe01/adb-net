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
    public partial class TouchScreen : UserControl
    {
        public TouchScreen()
        {
            InitializeComponent();
        }

        private void TouchScreen_Load(object sender, EventArgs e)
        {

        }

        public void RefreshScreen()
        {
            Image img = AndroidDevice.TakeScreenshot();
            this.BackgroundImage = img;
        }

        private void TouchScreen_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}

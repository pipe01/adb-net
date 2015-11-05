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
            Image img = DeviceScreen.TakeScreenshot();
            this.BackgroundImage = img;
        }

        int x, y, x2, y2;
        bool down = false;

        private void TouchScreen_MouseDown(object sender, MouseEventArgs e)
        {
            x2 = 0;
            y2 = 0;
            x = e.X;
            y = e.Y;
            down = true;
        }

        private void TouchScreen_MouseMove(object sender, MouseEventArgs e)
        {
            if (down)
            {
                if (x2 != 0 && y2 != 0)
                {
                    DeviceScreen.SimulateSwipe(x2, y2, e.X, e.Y);
                }
                x2 = e.X;
                y2 = e.Y;
            }
        }

        private void TouchScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.X == x && e.Y == y) { DeviceScreen.SimulateTap(x * 2, y * 2); }
            down = false;
        }
    }
}

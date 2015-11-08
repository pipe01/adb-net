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
            Image img = DeviceScreen.TakeScreenshot2();
            this.BackgroundImage = img;
        }

        bool swipe = false;
        int sX, sY;
        Stopwatch mouseTimer = new Stopwatch();

        private void TouchScreen_MouseDown(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Left)
            {
                x2 = 0;
                y2 = 0;
                x = e.X;
                y = e.Y;
                down = true;
            } else */if (e.Button == MouseButtons.Left)
            {
                sX = e.X;
                sY = e.Y;
                swipe = true;
                mouseTimer.Reset();
                mouseTimer.Start();
            }
        }

        private void TouchScreen_MouseMove(object sender, MouseEventArgs e)
        {
            /*if (down)
            {
                if (x2 != 0 && y2 != 0)
                {
                    DeviceScreen.SimulateSwipe(x2, y2, e.X, e.Y);
                }
                x2 = e.X;
                y2 = e.Y;
            }*/
        }

        private void TouchScreen_MouseUp(object sender, MouseEventArgs e)
        {
            if (swipe)
            {
                mouseTimer.Stop();
                swipe = false;
                DeviceScreen.SimulateSwipe(sX * 2, sY * 2, e.X * 2, e.Y * 2, mouseTimer.ElapsedMilliseconds);
            }
            /*else
            {
                if (e.X == x && e.Y == y) { DeviceScreen.SimulateTap(x * 2, y * 2); }
                down = false;
            }*/
        }
    }
}

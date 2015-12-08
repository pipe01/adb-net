using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB_Helper
{
    public partial class CustomButton : UserControl
    {
        public CustomButton()
        {
            InitializeComponent();
        }

        private Color insideColor = Color.Black;
        public Color InsideColor
        {
            get { return insideColor; }
            set { insideColor = value; this.Refresh(); }
        }
        private Color borderColor = Color.White;
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Refresh(); }
        }
        private int borderWidth = 5;
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; this.Refresh(); }
        }
        private string text = "";
        public string ButtonText
        {
            get { return text; }
            set { text = value; this.Refresh(); }
        }

        private bool Hovering = false;
        private bool mDown = false;

        public event EventHandler Clicked;

        private void CustomButton_Load(object sender, EventArgs e)
        {

        }

        private void CustomButton_Paint(object sender, PaintEventArgs e)
        {
            Color iColor;
            if (mDown)
            {
                iColor = BlendColor(insideColor, Color.Black, 0.8);
            }
            else
            {
                iColor = insideColor;
            }

            if (!mDown)
                if (Hovering)
                {
                    iColor = BlendColor(insideColor, Color.White, 0.8);
                } else {
                    iColor = insideColor;
                }

            Graphics g = e.Graphics;

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            g.FillRectangle(new SolidBrush(iColor), new Rectangle(new Point(0, 0), this.Size));
            g.DrawRectangle(new Pen(borderColor),
                new Rectangle(0, 0, this.Width - 1, this.Height - 1));

            StringFormat strFormat = new StringFormat();
            strFormat.Alignment = StringAlignment.Center;
            strFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(text, this.Font, new SolidBrush(this.ForeColor),
                new RectangleF(0, 0, this.Width, this.Height), strFormat);
        }

        private Color BlendColor(Color color, Color backColor, double amount = 1)
        {
            byte r = (byte)((color.R * amount) + backColor.R * (1 - amount));
            byte g = (byte)((color.G * amount) + backColor.G * (1 - amount));
            byte b = (byte)((color.B * amount) + backColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }

        private void CustomButton_MouseEnter(object sender, EventArgs e)
        {
            Hovering = true;
            Refresh();
        }

        private void CustomButton_MouseLeave(object sender, EventArgs e)
        {
            Hovering = false;
            Refresh();
        }

        private void CustomButton_MouseDown(object sender, MouseEventArgs e)
        {
            mDown = true;
            Refresh();
        }

        private void CustomButton_MouseUp(object sender, MouseEventArgs e)
        {
            mDown = false;
            Refresh();
            Clicked(sender, EventArgs.Empty);
        }
    }
}

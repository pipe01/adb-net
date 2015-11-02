using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;

namespace ADB_Helper
{
    public partial class BatteryDisplay : UserControl
    {
        public BatteryDisplay()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private string root;

        private bool makeTrans = true;
        public bool MakeTransparent
        {
            get { return makeTrans; }
            set { makeTrans = value; RefreshImg(); }
        }

        private int batteryLevel = 50;
        public int BatteryLevel
        {
            get { return batteryLevel; }
            set
            {
                batteryLevel = value;
                RefreshImg();
            }
        }

        private bool ac;
        public bool AC
        {
            get { return ac; }
            set
            {
                ac = value;
                RefreshImg();
            }
        }

        private void BatteryDisplay_Load(object sender, EventArgs e)
        {
            Init();
            RefreshImg();
        }

        private void Init()
        {
            var trace = new StackTrace(true);
            var frame = trace.GetFrame(0);
            var sourceCodeFile = Path.GetDirectoryName(frame.GetFileName());
            root = Path.Combine( sourceCodeFile, "bin/Debug/");
        }

        public void RefreshImg()
        {
            if (root == null) { Init(); }

            Bitmap res = new Bitmap(231, 134);
            Bitmap batLevel = Image.FromFile(root + "/media/batteryLevel.png") as Bitmap;
            Bitmap battery = Image.FromFile(root + "/media/batteryOverlay.png") as Bitmap;
            Graphics g = Graphics.FromImage(res);

            if (makeTrans)
                battery.MakeTransparent();

            //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            float w = (batLevel.Width / 100) * batteryLevel;
            w += 0.05f * w;

            g.DrawImage(battery, new Point(0, 0));
            g.DrawImage(cropImage(batLevel, new RectangleF(0, 0, w, batLevel.Height)), new Point(11, 11));
            
            if (drawPerc)
            { 
                FontFamily fontF = new FontFamily("Arial");
                Font font = new Font(fontF, 15);
                PointF textPos = new PointF(11 + w - (BatteryLevel >= 88 ? (BatteryLevel == 100 ? 40 : 28) : 0),
                    this.Height / 2 - font.Size / 2 - 3);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.DrawString(batteryLevel.ToString(), font, Brushes.Black, textPos);
            }
            if (ac)
            {
                Bitmap acIcon = Image.FromFile(root + "/media/batteryAC.png") as Bitmap;
                int x, y, w1, h;
                w1 = acIcon.Width / 2;
                h = acIcon.Height / 2;
                x = this.Width / 2 - w1 / 2;
                y = this.Height / 2 - h / 2;
                g.DrawImage(SetImageOpacity(acIcon,0.5f), new Rectangle(x, y, w1, h));
            }

            this.BackgroundImage = res as Image;
            
        }
        private Image cropImage(Bitmap img, RectangleF cropArea)
        {
            if (cropArea.Width == 0 || cropArea.Height == 0)
                return new Bitmap(1, 1);
            return img.Clone(cropArea, img.PixelFormat);
        }
        /// <summary>  
        /// method for changing the opacity of an image  
        /// </summary>  
        /// <param name="image">image to set opacity on</param>  
        /// <param name="opacity">percentage of opacity</param>  
        /// <returns></returns>  
        public Image SetImageOpacity(Image image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = opacity;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private bool drawPerc = true;
        public bool DrawPercNumber
        {
            get { return drawPerc; }
            set { drawPerc = value; RefreshImg(); }
        }

        private void BatteryDisplay_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}

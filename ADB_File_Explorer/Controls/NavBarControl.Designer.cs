namespace ADB_Helper
{
    partial class NavBarControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBtn1 = new System.Windows.Forms.PictureBox();
            this.picBtn2 = new System.Windows.Forms.PictureBox();
            this.picBtn3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn3)).BeginInit();
            this.SuspendLayout();
            // 
            // picBtn1
            // 
            this.picBtn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.picBtn1.BackColor = System.Drawing.Color.Gray;
            this.picBtn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBtn1.Location = new System.Drawing.Point(0, 0);
            this.picBtn1.Name = "picBtn1";
            this.picBtn1.Size = new System.Drawing.Size(100, 67);
            this.picBtn1.TabIndex = 0;
            this.picBtn1.TabStop = false;
            this.picBtn1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBtn1_MouseDown);
            this.picBtn1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBtn1_MouseUp);
            // 
            // picBtn2
            // 
            this.picBtn2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.picBtn2.BackColor = System.Drawing.Color.Maroon;
            this.picBtn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBtn2.Location = new System.Drawing.Point(100, 0);
            this.picBtn2.Name = "picBtn2";
            this.picBtn2.Size = new System.Drawing.Size(100, 67);
            this.picBtn2.TabIndex = 1;
            this.picBtn2.TabStop = false;
            this.picBtn2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBtn2_MouseDown);
            this.picBtn2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBtn2_MouseUp);
            // 
            // picBtn3
            // 
            this.picBtn3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.picBtn3.BackColor = System.Drawing.Color.LightCoral;
            this.picBtn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBtn3.Location = new System.Drawing.Point(200, 0);
            this.picBtn3.Name = "picBtn3";
            this.picBtn3.Size = new System.Drawing.Size(100, 67);
            this.picBtn3.TabIndex = 1;
            this.picBtn3.TabStop = false;
            this.picBtn3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBtn3_MouseDown);
            this.picBtn3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBtn3_MouseUp);
            // 
            // NavBarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.picBtn3);
            this.Controls.Add(this.picBtn2);
            this.Controls.Add(this.picBtn1);
            this.Name = "NavBarControl";
            this.Size = new System.Drawing.Size(300, 67);
            this.Resize += new System.EventHandler(this.NavBar_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picBtn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBtn3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBtn1;
        private System.Windows.Forms.PictureBox picBtn2;
        private System.Windows.Forms.PictureBox picBtn3;
    }
}

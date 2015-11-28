namespace ADB_Helper
{
    partial class frmBatteryDisplay
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatteryDisplay));
            this.batteryDisplay1 = new ADB_Helper.BatteryDisplay();
            this.SuspendLayout();
            // 
            // batteryDisplay1
            // 
            this.batteryDisplay1.AC = false;
            this.batteryDisplay1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("batteryDisplay1.BackgroundImage")));
            this.batteryDisplay1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.batteryDisplay1.BatteryLevel = 50;
            this.batteryDisplay1.DrawPercNumber = true;
            this.batteryDisplay1.Location = new System.Drawing.Point(0, 0);
            this.batteryDisplay1.MakeTransparent = true;
            this.batteryDisplay1.Name = "batteryDisplay1";
            this.batteryDisplay1.Size = new System.Drawing.Size(231, 134);
            this.batteryDisplay1.TabIndex = 0;
            this.batteryDisplay1.Load += new System.EventHandler(this.batteryDisplay1_Load);
            // 
            // frmBatteryDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Fuchsia;
            this.ClientSize = new System.Drawing.Size(231, 134);
            this.Controls.Add(this.batteryDisplay1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBatteryDisplay";
            this.Text = "frmBattery";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.frmBatteryDisplay_Load);
            this.Shown += new System.EventHandler(this.frmBatteryDisplay_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        public BatteryDisplay batteryDisplay1;
    }
}
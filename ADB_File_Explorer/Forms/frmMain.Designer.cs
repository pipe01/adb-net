namespace ADB_Helper
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.updDevices = new System.Windows.Forms.Timer(this.components);
            this.updTask = new System.ComponentModel.BackgroundWorker();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tFormBattery = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblDeviceModel = new System.Windows.Forms.Label();
            this.btnLogcat = new ADB_Helper.CustomButton();
            this.button8 = new ADB_Helper.CustomButton();
            this.batteryDisplay1 = new ADB_Helper.BatteryDisplay();
            this.button7 = new ADB_Helper.CustomButton();
            this.button6 = new ADB_Helper.CustomButton();
            this.button4 = new ADB_Helper.CustomButton();
            this.button2 = new ADB_Helper.CustomButton();
            this.btnConnect = new ADB_Helper.CustomButton();
            this.button5 = new ADB_Helper.CustomButton();
            this.button3 = new ADB_Helper.CustomButton();
            this.button1 = new ADB_Helper.CustomButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // updDevices
            // 
            this.updDevices.Interval = 60000;
            this.updDevices.Tick += new System.EventHandler(this.updDevices_Tick);
            // 
            // updTask
            // 
            this.updTask.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updTask_DoWork);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 292);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(613, 108);
            this.listBox1.TabIndex = 14;
            // 
            // tFormBattery
            // 
            this.tFormBattery.Interval = 3000;
            this.tFormBattery.Tick += new System.EventHandler(this.tFormBattery_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 79);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "WiFi";
            // 
            // trayIcon
            // 
            this.trayIcon.Text = "Pipe\'s ADB Helper";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // lblDeviceModel
            // 
            this.lblDeviceModel.AutoSize = true;
            this.lblDeviceModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceModel.Location = new System.Drawing.Point(14, 94);
            this.lblDeviceModel.Name = "lblDeviceModel";
            this.lblDeviceModel.Size = new System.Drawing.Size(17, 22);
            this.lblDeviceModel.TabIndex = 22;
            this.lblDeviceModel.Text = "-";
            // 
            // btnLogcat
            // 
            this.btnLogcat.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnLogcat.BorderWidth = 5;
            this.btnLogcat.ButtonText = "Logcat Off";
            this.btnLogcat.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogcat.InsideColor = System.Drawing.Color.Black;
            this.btnLogcat.Location = new System.Drawing.Point(107, 31);
            this.btnLogcat.Name = "btnLogcat";
            this.btnLogcat.Size = new System.Drawing.Size(75, 23);
            this.btnLogcat.TabIndex = 28;
            this.btnLogcat.Clicked += new System.EventHandler(this.btnLogcat_Click);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.BorderColor = System.Drawing.Color.DarkCyan;
            this.button8.BorderWidth = 5;
            this.button8.ButtonText = "Kill all consoles";
            this.button8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button8.InsideColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(93, 252);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 34);
            this.button8.TabIndex = 27;
            this.button8.Clicked += new System.EventHandler(this.button8_Click_1);
            // 
            // batteryDisplay1
            // 
            this.batteryDisplay1.AC = false;
            this.batteryDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.batteryDisplay1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("batteryDisplay1.BackgroundImage")));
            this.batteryDisplay1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.batteryDisplay1.BatteryLevel = 40;
            this.batteryDisplay1.DrawPercNumber = true;
            this.batteryDisplay1.Location = new System.Drawing.Point(394, 12);
            this.batteryDisplay1.MakeTransparent = true;
            this.batteryDisplay1.Name = "batteryDisplay1";
            this.batteryDisplay1.Size = new System.Drawing.Size(231, 134);
            this.batteryDisplay1.TabIndex = 26;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.BorderColor = System.Drawing.Color.DarkCyan;
            this.button7.BorderWidth = 5;
            this.button7.ButtonText = "Restart all consoles";
            this.button7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button7.InsideColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(12, 252);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 34);
            this.button7.TabIndex = 25;
            this.button7.Clicked += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BorderColor = System.Drawing.Color.DarkCyan;
            this.button6.BorderWidth = 5;
            this.button6.ButtonText = "App manager";
            this.button6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button6.InsideColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(550, 252);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 34);
            this.button6.TabIndex = 24;
            this.button6.Clicked += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BorderColor = System.Drawing.Color.DarkCyan;
            this.button4.BorderWidth = 5;
            this.button4.ButtonText = "Remote control";
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.InsideColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(469, 252);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 34);
            this.button4.TabIndex = 23;
            this.button4.Clicked += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BorderColor = System.Drawing.Color.DarkCyan;
            this.button2.BorderWidth = 5;
            this.button2.ButtonText = "FileXplorer";
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.InsideColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(388, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 21;
            this.button2.Clicked += new System.EventHandler(this.button2_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnConnect.BorderWidth = 5;
            this.btnConnect.ButtonText = "Connect";
            this.btnConnect.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConnect.InsideColor = System.Drawing.Color.Black;
            this.btnConnect.Location = new System.Drawing.Point(6, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 16;
            this.btnConnect.Clicked += new System.EventHandler(this.btnConnect_Click);
            // 
            // button5
            // 
            this.button5.BorderColor = System.Drawing.Color.DarkCyan;
            this.button5.BorderWidth = 5;
            this.button5.ButtonText = "Disconnect";
            this.button5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button5.InsideColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(6, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 15;
            this.button5.Clicked += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.BorderColor = System.Drawing.Color.DarkCyan;
            this.button3.BorderWidth = 5;
            this.button3.ButtonText = "Configuration";
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.InsideColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(206, 252);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 34);
            this.button3.TabIndex = 18;
            this.button3.Clicked += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BorderColor = System.Drawing.Color.DarkCyan;
            this.button1.BorderWidth = 5;
            this.button1.ButtonText = "Refresh";
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.InsideColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(313, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Clicked += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(637, 412);
            this.Controls.Add(this.btnLogcat);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.batteryDisplay1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lblDeviceModel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Pipe\'s ADB Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.Resize += new System.EventHandler(this.frmMain_ResizeEnd);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer updDevices;
        private System.ComponentModel.BackgroundWorker updTask;
        private CustomButton button1;
        private System.Windows.Forms.ListBox listBox1;
        private CustomButton button5;
        private CustomButton button3;
        private System.Windows.Forms.Timer tFormBattery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private CustomButton button2;
        private System.Windows.Forms.Label lblDeviceModel;
        private CustomButton button4;
        private CustomButton button6;
        private CustomButton button7;
        private CustomButton btnConnect;
        public BatteryDisplay batteryDisplay1;
        private CustomButton button8;
        private CustomButton btnLogcat;
    }
}
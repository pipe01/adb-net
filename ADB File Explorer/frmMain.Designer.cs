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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tFormBattery = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.lblDeviceModel = new System.Windows.Forms.Label();
            this.txbConnect = new ADB_Helper.TextButton();
            this.batteryDisplay1 = new ADB_Helper.BatteryDisplay();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // updDevices
            // 
            this.updDevices.Enabled = true;
            this.updDevices.Interval = 60000;
            this.updDevices.Tick += new System.EventHandler(this.updDevices_Tick);
            // 
            // updTask
            // 
            this.updTask.WorkerReportsProgress = true;
            this.updTask.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updTask_DoWork);
            this.updTask.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.updTask_ProgressChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 152);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(450, 147);
            this.listBox1.TabIndex = 14;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Disconnect";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(158, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Configurate";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tFormBattery
            // 
            this.tFormBattery.Interval = 3000;
            this.tFormBattery.Tick += new System.EventHandler(this.tFormBattery_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbConnect);
            this.groupBox1.Controls.Add(this.button5);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "FileXplorer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblDeviceModel
            // 
            this.lblDeviceModel.AutoSize = true;
            this.lblDeviceModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceModel.Location = new System.Drawing.Point(9, 96);
            this.lblDeviceModel.Name = "lblDeviceModel";
            this.lblDeviceModel.Size = new System.Drawing.Size(17, 22);
            this.lblDeviceModel.TabIndex = 22;
            this.lblDeviceModel.Text = "-";
            // 
            // txbConnect
            // 
            this.txbConnect.ButtonText = "Connect to";
            this.txbConnect.Location = new System.Drawing.Point(6, 19);
            this.txbConnect.Name = "txbConnect";
            this.txbConnect.Size = new System.Drawing.Size(75, 23);
            this.txbConnect.TabIndex = 19;
            this.txbConnect.Value = "";
            this.txbConnect.OKClicked += new System.EventHandler(this.txbConnect_OKClicked);
            // 
            // batteryDisplay1
            // 
            this.batteryDisplay1.AC = false;
            this.batteryDisplay1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("batteryDisplay1.BackgroundImage")));
            this.batteryDisplay1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.batteryDisplay1.BatteryLevel = 0;
            this.batteryDisplay1.DrawPercNumber = true;
            this.batteryDisplay1.Location = new System.Drawing.Point(239, 12);
            this.batteryDisplay1.MakeTransparent = true;
            this.batteryDisplay1.Name = "batteryDisplay1";
            this.batteryDisplay1.Size = new System.Drawing.Size(231, 134);
            this.batteryDisplay1.TabIndex = 9;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 314);
            this.Controls.Add(this.lblDeviceModel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.batteryDisplay1);
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
        private BatteryDisplay batteryDisplay1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private TextButton txbConnect;
        private System.Windows.Forms.Timer tFormBattery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblDeviceModel;
    }
}
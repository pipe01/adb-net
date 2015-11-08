namespace ADB_Helper
{
    partial class frmRemoteControl
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
            this.btnStartStop = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.touchScreen1 = new ADB_Helper.TouchScreen();
            this.navBar1 = new ADB_Helper.NavBarControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVolDown = new System.Windows.Forms.Button();
            this.btnVolUp = new System.Windows.Forms.Button();
            this.btnPower = new System.Windows.Forms.Button();
            this.txtInputText = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(12, 527);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(190, 23);
            this.btnStartStop.TabIndex = 1;
            this.btnStartStop.Text = "Start/Stop";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 527);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // touchScreen1
            // 
            this.touchScreen1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.touchScreen1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.touchScreen1.Location = new System.Drawing.Point(13, 12);
            this.touchScreen1.Name = "touchScreen1";
            this.touchScreen1.Size = new System.Drawing.Size(270, 480);
            this.touchScreen1.TabIndex = 3;
            // 
            // navBar1
            // 
            this.navBar1.BackColor = System.Drawing.Color.Black;
            this.navBar1.Location = new System.Drawing.Point(13, 492);
            this.navBar1.Name = "navBar1";
            this.navBar1.NavBar = null;
            this.navBar1.Size = new System.Drawing.Size(270, 27);
            this.navBar1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnVolDown);
            this.groupBox1.Controls.Add(this.btnVolUp);
            this.groupBox1.Controls.Add(this.btnPower);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(289, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(88, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hard buttons";
            // 
            // btnVolDown
            // 
            this.btnVolDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVolDown.Location = new System.Drawing.Point(6, 91);
            this.btnVolDown.Name = "btnVolDown";
            this.btnVolDown.Size = new System.Drawing.Size(75, 23);
            this.btnVolDown.TabIndex = 2;
            this.btnVolDown.Text = "Vol. Down";
            this.btnVolDown.UseVisualStyleBackColor = true;
            this.btnVolDown.Click += new System.EventHandler(this.btnVolDown_Click);
            // 
            // btnVolUp
            // 
            this.btnVolUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVolUp.Location = new System.Drawing.Point(6, 62);
            this.btnVolUp.Name = "btnVolUp";
            this.btnVolUp.Size = new System.Drawing.Size(75, 23);
            this.btnVolUp.TabIndex = 1;
            this.btnVolUp.Text = "Volume Up";
            this.btnVolUp.UseVisualStyleBackColor = true;
            this.btnVolUp.Click += new System.EventHandler(this.btnVolUp_Click);
            // 
            // btnPower
            // 
            this.btnPower.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPower.Location = new System.Drawing.Point(6, 19);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(75, 23);
            this.btnPower.TabIndex = 0;
            this.btnPower.Text = "Power";
            this.btnPower.UseVisualStyleBackColor = true;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // txtInputText
            // 
            this.txtInputText.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtInputText.Location = new System.Drawing.Point(383, 12);
            this.txtInputText.Name = "txtInputText";
            this.txtInputText.Size = new System.Drawing.Size(193, 20);
            this.txtInputText.TabIndex = 6;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(501, 38);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // frmScreenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(588, 558);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtInputText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.navBar1);
            this.Controls.Add(this.touchScreen1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStartStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScreenshot";
            this.Text = "Screenshot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmScreenshot_FormClosing);
            this.Load += new System.EventHandler(this.frmScreenshot_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStartStop;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private TouchScreen touchScreen1;
        private NavBarControl navBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVolDown;
        private System.Windows.Forms.Button btnVolUp;
        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.TextBox txtInputText;
        private System.Windows.Forms.Button btnSend;
    }
}
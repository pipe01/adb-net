namespace ADB_Helper
{
    partial class frmAppManager
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
            this.lvApps = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.colPackageName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUninstall = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvApps
            // 
            this.lvApps.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lvApps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPackageName});
            this.lvApps.Location = new System.Drawing.Point(12, 25);
            this.lvApps.Name = "lvApps";
            this.lvApps.Size = new System.Drawing.Size(444, 316);
            this.lvApps.TabIndex = 0;
            this.lvApps.UseCompatibleStateImageBehavior = false;
            this.lvApps.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Currently installed apps:";
            // 
            // colPackageName
            // 
            this.colPackageName.Text = "Package Name";
            this.colPackageName.Width = 200;
            // 
            // btnUninstall
            // 
            this.btnUninstall.Location = new System.Drawing.Point(12, 347);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(75, 23);
            this.btnUninstall.TabIndex = 2;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(381, 347);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // frmAppManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 379);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUninstall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvApps);
            this.Name = "frmAppManager";
            this.Text = "frmAppManager";
            this.Load += new System.EventHandler(this.frmAppManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvApps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colPackageName;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Button btnRefresh;
    }
}
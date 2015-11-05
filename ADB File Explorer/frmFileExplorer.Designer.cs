namespace ADB_Helper
{
    partial class frmFileExplorer
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
            this.tvFileTree = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPull = new System.Windows.Forms.Button();
            this.btnPush = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tvFileTree
            // 
            this.tvFileTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFileTree.Location = new System.Drawing.Point(12, 12);
            this.tvFileTree.Name = "tvFileTree";
            this.tvFileTree.Size = new System.Drawing.Size(455, 356);
            this.tvFileTree.TabIndex = 0;
            this.tvFileTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvFileTree_AfterExpand);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(392, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPull
            // 
            this.btnPull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPull.Location = new System.Drawing.Point(12, 374);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(89, 23);
            this.btnPull.TabIndex = 2;
            this.btnPull.Text = "Pull (download)";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // btnPush
            // 
            this.btnPush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPush.Location = new System.Drawing.Point(107, 374);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(89, 23);
            this.btnPush.TabIndex = 3;
            this.btnPush.Text = "Push (upload)";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.AddExtension = false;
            this.saveFileDialog.FileName = "Save Here";
            this.saveFileDialog.Filter = "All files|*.*";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(202, 374);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(184, 23);
            this.progressBar.TabIndex = 4;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All files|*.*";
            // 
            // frmFileExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 403);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnPush);
            this.Controls.Add(this.btnPull);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tvFileTree);
            this.Name = "frmFileExplorer";
            this.Text = "Pipe\'s ADB Helper - FileXplorer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvFileTree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Button btnPush;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADB.net;
using System.IO;

namespace ADB_Helper
{
    public partial class frmFileExplorer : Form
    {
        public frmFileExplorer()
        {
            InitializeComponent();
        }

        private bool Working, Stop = false;

        private void UpdateFileTree()
        {
            Working = true;
            List<string> entries = new List<string>();
            entries.AddRange(FileSystem.GetAllEntries("/"));

            tvFileTree.Nodes.Clear();

            progressBar.Maximum = entries.Count;

            foreach(string entry in entries)
            {
                if (Stop) break;
                TreeNode node = tvFileTree.Nodes.Add(entry, entry);
            }

            foreach (TreeNode item in tvFileTree.Nodes)
            {
                if (Stop) break;
                if (FileSystem.IsDirectory(item.Text))
                    item.Nodes.Add("Loading...");
                progressBar.Value++;
            }

            progressBar.Value = 0;
            Working = false;
        }

        private void ExpandNode(TreeNode nodeE)
        {
            Working = true;
            string fullpath = "/" + nodeE.FullPath.Replace("\\", "/");

            List<string> entries = new List<string>();
            entries.AddRange(FileSystem.GetAllEntries(fullpath));

            int m = entries.Count;

            nodeE.Nodes.Clear();

            progressBar.Maximum = entries.Count;

            foreach (string item in entries)
            {
                if (Stop) break;
                TreeNode n = new TreeNode(item);
                nodeE.Nodes.Add(n);
            }

            foreach (TreeNode item in nodeE.Nodes)
            {
                if (Stop) break;
                if (FileSystem.IsDirectory(fullpath + "/" + item.Text))
                    item.Nodes.Add("Loading...");
                progressBar.Value++;
            }

            progressBar.Value = 0;
            Working = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Working)
            {
                button1.Text = "Stop";
                UpdateFileTree();
            }
            else
            {
                button1.Text = "Refresh";
                Stop = true;
            }
        }

        private void tvFileTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (!Working)
                ExpandNode(e.Node);
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            int progress = 0;
            if (tvFileTree.SelectedNode != null || tvFileTree.SelectedNode.Nodes.Count > 0)
            {
                string fullpath = "/" + tvFileTree.SelectedNode.FullPath.Replace("\\", "/");
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileSystem.PullFileAlt(fullpath, Path.GetDirectoryName(saveFileDialog.FileName), true);
                    /*progressBar.Maximum = 100;
                    while (progress < 100)
                    {
                        progressBar.Value = progress;
                    }*/
                }
            }
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            if (tvFileTree.SelectedNode != null)
            {
                string fullpath;
                if (tvFileTree.SelectedNode.Nodes.Count == 0)
                    fullpath = "/" + Path.GetDirectoryName(tvFileTree.SelectedNode.FullPath).Replace("\\", "/");
                else
                    fullpath = "/" + tvFileTree.SelectedNode.FullPath.Replace("\\", "/");
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileSystem.PushFile(openFileDialog.FileName.Substring(2), fullpath);
                }
            }
        }
    }
}

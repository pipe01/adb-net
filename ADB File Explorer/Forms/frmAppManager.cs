using ADB.net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB_Helper
{
    public partial class frmAppManager : Form
    {
        public frmAppManager()
        {
            InitializeComponent();
        }

        private void RefreshApps()
        {
            foreach (App app in AppManager.GetAllApps())
            {
                lvApps.Items.Add(app.PackageName);
            }
        }

        private void frmAppManager_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshApps();
        }

        private void btnPullAPK_Click(object sender, EventArgs e)
        {
            if (lvApps.SelectedItems.Count == 0) return;
            foreach (ListViewItem item in lvApps.SelectedItems)
            {
                if (FileSystem.Exists("/data/app/" + item.Text + "-1"))
                {

                }
            }
        }
    }
}

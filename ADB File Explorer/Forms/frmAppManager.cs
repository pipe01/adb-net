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
    }
}

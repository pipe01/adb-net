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
    public partial class frmWaiting : Form
    {
        Form parent;

        public frmWaiting(Form parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void frmWaiting_Load(object sender, EventArgs e)
        {
            
        }

        private void frmWaiting_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            AndroidDevice.WaitForDevice();
            parent.Show();
            this.Close();
        }
    }
}

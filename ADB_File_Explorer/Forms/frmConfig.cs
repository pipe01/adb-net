using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PiConfig;

namespace ADB_Helper
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        ConfigFile config = new ConfigFile();

        public List<Control> GetAllControls(Control root)
        {
            List<Control> tmp = new List<Control>();
            foreach (Control item in root.Controls)
            {
                tmp.Add(item);
                if (item.HasChildren)
                {
                    tmp.AddRange(GetAllControls(item));
                }
            }
            return tmp;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            config.Save();
            this.Close();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            config.Load();
            foreach (Control item in GetAllControls(this))
            {
                if (item.Tag == null) continue;
                string tag = item.Tag.ToString();
                if (tag.StartsWith("."))
                {
                    item.Text = config.Get(tag.Remove(0, 1));
                }
                else if (tag.StartsWith(":"))
                {
                    ((CheckBox)item).Checked = bool.Parse(config.Get(tag.Remove(0, 1)));
                }
                else if (tag.StartsWith("-"))
                {
                    ((NumericUpDown)item).Value = int.Parse(config.Get(tag.Remove(0, 1)));
                }
            }
        }

        private void txtDeviceIP_TextChanged(object sender, EventArgs e)
        {
            config.Modify("defaultDeviceIp", txtDeviceIP.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbDisconnectExit_CheckedChanged(object sender, EventArgs e)
        {
            config.Modify("disconnectAtExit", cbDisconnectExit.Checked.ToString());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            config.Modify("updateInterval", numericUpDown1.Value.ToString());
        }

        private void cbEnableDevice_CheckedChanged(object sender, EventArgs e)
        {
            config.Modify("connectAtStartup", cbEnableDevice.Checked.ToString());
        }
    }
}

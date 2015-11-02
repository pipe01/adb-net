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

namespace ADB_Helper
{
    public partial class frmConsole : Form
    {
        public frmConsole()
        {
            InitializeComponent();
        }

        CConsole adb;

        private string Output
        {
            set
            {
                textBox1.Text += "\n" + value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adb.ExecuteCommand(textBox2.Text);
            textBox2.Text = null;
        }

        private void frmConsole_Load(object sender, EventArgs e)
        {
            adb = new CConsole();
            adb.OutputReceived += Adb_OutputReceived;
        }

        delegate void SetTextCallback(string text);
        private void AddText(string text)
        {
            StringBuilder str = new StringBuilder(textBox1.Text);
            str.AppendLine(text);
            textBox1.Text = str.ToString();
        }
        private void Adb_OutputReceived(string output, EventArgs e)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AddText);
                this.Invoke(d, new object[] { output });
            }
            else
            {
                AddText(output);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}

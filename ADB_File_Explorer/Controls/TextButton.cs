using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB_Helper
{
    public partial class TextButton : UserControl
    {
        public TextButton()
        {
            InitializeComponent();
        }

        private bool opened = false;

        public event EventHandler ValueChanged;
        public event EventHandler OKClicked;

        public string Value
        {
            get { return txtText.Text; }
            set { txtText.Text = value; }
        }
        private string buttonText;
        public string ButtonText
        {
            get { return buttonText; }
            set {
                buttonText = value;
                if (!opened)
                    btnButton.Text = buttonText;
            }
        }

        private void btnButton_Click(object sender, EventArgs e)
        {
            opened = !opened;
            if (opened)
            {
                btnButton.Text = "Cancel";
                this.Width = btnButton.Width + txtText.Width + 1;
            } else
            {
                btnButton.Text = buttonText;
                this.Width = btnButton.Width;
            }
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void txtText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                OKClicked(sender, EventArgs.Empty);
                btnButton_Click(sender, EventArgs.Empty);
            }
        }
    }
}

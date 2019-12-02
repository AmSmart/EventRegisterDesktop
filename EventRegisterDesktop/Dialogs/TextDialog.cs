using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EventRegisterDesktop.Windows;

namespace EventRegisterDesktop.Dialogs
{
    public partial class TextDialog : Form
    {
        private readonly NewProjectWindow npw;

        //Pass data through OOP
        public TextDialog(NewProjectWindow npw)
        {
            InitializeComponent();
            this.npw = npw;
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox) sender;
            if (tb.Text.Length > 0)
            {
                label1.Visible = false;
            }
            else
            {
                label1.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textName.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (textName.Text.Length > 1)
            {
                npw.ItemList.Add("TextBox:" + textName.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Invalid Entry");
            }
        }
    }
}

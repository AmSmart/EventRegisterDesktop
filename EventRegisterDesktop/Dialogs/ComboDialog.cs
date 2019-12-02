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
    public partial class ComboDialog : Form
    {
        private readonly NewProjectWindow npw;

        public ComboDialog(NewProjectWindow npw)
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

        //Code not well written for future understanding
        private void btnOkay_Click(object sender, EventArgs e)
        {
            if (textName.Text.Length > 1)
            {
                if (radioStatic.Checked)
                {
                    npw.ItemList.Add("ComboBox:" + textName.Text + ":Static");
                    this.Close();
                    return;
                }

                if (radioDyanmic.Checked)
                {

                    foreach (var item in npw.ItemList)
                    {
                        if (item.Split(':')[1] == textLink.Text)
                        {
                            npw.ItemList.Add("ComboBox:" + textName.Text + ":Dynamic:" + textLink.Text);
                            Close();
                            return;
                        }
                    }
                    MessageBox.Show(this, "Link does not exist");
                    return;
                }
                MessageBox.Show(this, "Control must be Static or Dynamic");
            }
            else
            {
                MessageBox.Show(this, "Invalid Name");
            }
        }

        private void radioStatic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioStatic.Checked)
            {
                label2.Visible = false;
                textLink.Enabled = false;
            }
            else
            {
                label2.Visible = true;
                textLink.Enabled = true;
            }
        }

        private void radioDyanmic_CheckedChanged(object sender, EventArgs e)
        {
            if (radioStatic.Checked)
            {
                label2.Visible = false;
                textLink.Enabled = false;
            }
            else
            {
                label2.Visible = true;
                textLink.Enabled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textLink.Focus();
        }

        private void textLink_TextChanged(object sender, EventArgs e)
        {
            if (textLink.Text.Length > 0)
            {
                label2.Visible = false;
            }
            else
            {
                label2.Visible = true;
            }
        }
    }
}

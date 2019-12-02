using EventRegisterDesktop.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventRegisterDesktop.Dialogs
{
    public partial class CreateNew : Form
    {
        private readonly MainWindow mw;

        public CreateNew(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length <= 2)
            {
                MessageBox.Show(this, "Invalid Name", "Error!");
                return;
            }


            Properties.Settings.Default.Reload();
            string appDirectory = (string)Properties.Settings.Default["AppDirectory"];
            string newFolderPath = Path.Combine(appDirectory, textBox1.Text);
            if(Directory.Exists(Path.Combine(appDirectory, textBox1.Text)))
            {
                MessageBox.Show("The chosen name has been used\nChoose another project name");
                return;
            }
            
            Directory.CreateDirectory(newFolderPath);
            NewProjectWindow x = new NewProjectWindow(textBox1.Text) { Owner = mw };
            x.ShowDialog();
            Close();

        }
    }
}

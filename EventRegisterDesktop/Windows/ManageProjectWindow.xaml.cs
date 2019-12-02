using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EventRegisterDesktop.Annotations;
using EventRegisterDesktop.Pages;

namespace EventRegisterDesktop.Windows
{
    /// <summary>
    /// Interaction logic for ManageProjectWindow.xaml
    /// </summary>
    public partial class ManageProjectWindow : Window, INotifyPropertyChanged
    {
        private readonly string projFolderPath;

        public ManageProjectWindow(string folderPath)
        {
            InitializeComponent();
            this.projFolderPath = folderPath;
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var items = LayoutItemHelper.GenerateItemList(projFolderPath);
                var addPage = new AddPage(items, projFolderPath);
                MyFrame.Navigate(addPage);
                BtnAdd.IsEnabled = false;
                BtnExport.IsEnabled = BtnReceive.IsEnabled = BtnShare.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show(this, "Invalid Configuration");
                return;
            }
        }

        private void BtnShare_OnClick(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new SharePage());
            BtnShare.IsEnabled = false;
            BtnExport.IsEnabled = BtnReceive.IsEnabled = BtnAdd.IsEnabled = true;
        }

        private void BtnReceive_OnClick(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new ReceivePage());
            BtnReceive.IsEnabled = false;
            BtnExport.IsEnabled = BtnShare.IsEnabled = BtnAdd.IsEnabled = true;
        }

        private void BtnExport_OnClick(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(new ExportPage());
            BtnExport.IsEnabled = false;
            BtnShare.IsEnabled = BtnReceive.IsEnabled = BtnAdd.IsEnabled = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using EventRegisterDesktop.Dialogs;

namespace EventRegisterDesktop.Windows
{
    /// <summary>
    /// Interaction logic for NewProjectWindow.xaml
    /// </summary>
    public partial class NewProjectWindow : Window
    {
        private readonly string projName;

        public  ObservableCollection<string> ItemList  { get; set;}
        public NewProjectWindow(string projName)
        {
            InitializeComponent();
            ItemList = new ObservableCollection<string>();
            MyListView.ItemsSource = ItemList;
            this.projName = projName;
        }

        private void BtnReset_OnClick(object sender, RoutedEventArgs e)
        {
            ItemList.Clear();
        }

        private void BtnCreate_OnClick(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reload();
            string appDirectory = (string)Properties.Settings.Default["AppDirectory"];
            using (StreamWriter sw = new StreamWriter(Path.Combine(appDirectory, projName, "Layout.txt")))
            {
                foreach (var line in ItemList)
                {
                    sw.WriteLine(line);
                }
            }

            ManageProjectWindow mpw = new ManageProjectWindow(Path.Combine(appDirectory,projName)) { Owner = this };
            mpw.ShowDialog();
            this.Close();
        }

        private void BtnText_OnClick(object sender, RoutedEventArgs e)
        {
            var x = new TextDialog(this);
            x.ShowDialog();
        }

        private void BtnCombo_OnClick(object sender, RoutedEventArgs e)
        {
            var x = new ComboDialog(this);
            x.ShowDialog();
        }
    }
}

using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using EventRegisterDesktop.Dialogs;
using Path = System.IO.Path;

namespace EventRegisterDesktop.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly string AppDirectory = Path.Combine(new string[]
            {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"EventRegister"});
        public MainWindow()
        {
            InitializeComponent();
            if (!Directory.Exists(AppDirectory))
            {
                Directory.CreateDirectory(AppDirectory);
            }

            System.Configuration.SettingsProperty property = new System.Configuration.SettingsProperty("AppDirectory");
            property.DefaultValue = "Default";
            property.IsReadOnly = false;
            property.PropertyType = typeof(string);
            property.Provider = Properties.Settings.Default.Providers["LocalFileSettingsProvider"];
            property.Attributes.Add(typeof(System.Configuration.UserScopedSettingAttribute), new System.Configuration.UserScopedSettingAttribute());
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Properties.Add(property);
            Properties.Settings.Default["AppDirectory"] = AppDirectory;
            Properties.Settings.Default.Save();

        }


        private void BtnNew_OnClick(object sender, RoutedEventArgs e)
        {
            var newProj = new CreateNew(this);
            newProj.ShowDialog();
        }

        private void BtnOpen_OnClick(object sender, RoutedEventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string folderPath = fbd.SelectedPath;
            if (string.IsNullOrEmpty(folderPath))
            {
                System.Windows.MessageBox.Show("Invalid folder selected");
                return;
            }
            var mpw = new ManageProjectWindow(folderPath)
            { Owner = this };
            mpw.ShowDialog();
        }

        private void BtnNotes_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

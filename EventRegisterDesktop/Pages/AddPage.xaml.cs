using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using EventRegisterDesktop.Windows;

namespace EventRegisterDesktop.Pages
{
    /// <summary>
    /// Interaction logic for AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        private readonly List<LayoutItem> _items;
        private readonly string projFolderPath;

        public AddPage(List<LayoutItem> items, string projFolderPath)
        {
            InitializeComponent();
            _items = items;
            this.projFolderPath = projFolderPath;
            foreach (var item in items)
            {
                MyPanel.Children.Add(LayoutItemHelper.GenerateLayout(item, projFolderPath));
                if (item.Type == "ComboBox")
                {
                    var cb = item.ControlItem as ComboBox;

                    cb.DropDownClosed += delegate
                    {
                        if(cb.SelectedIndex >= 0)
                            UpdateItemSource();
                    };
                }
            }
            
        }


        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _items)
            {
                item.Clear();
            }
        }

        public void UpdateItemSource()
        {
            List<LayoutItem> dynamicCboxes = _items.Where(e => e.State == "Dynamic").ToList();
            foreach (var cBox in dynamicCboxes)
            {
                var path = Path.Combine(new string[] { /*MainWindow.AppDirectory*/projFolderPath, cBox.LabelName + ".txt" });
                string[] fileContents = File.ReadAllLines(path);
                string[][] list = (from f in fileContents select f.Split(':')).ToArray();
                int index = _items.First(x => x.LabelName == cBox.LinkedTo).CurrentIndex;
                var cb = cBox.ControlItem as ComboBox;
                cb.ItemsSource = list[index].ToList(); ;
            }
        }
        
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

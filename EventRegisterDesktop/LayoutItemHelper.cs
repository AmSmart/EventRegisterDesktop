using EventRegisterDesktop.Windows;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
using System.Windows.Controls;

namespace EventRegisterDesktop
{
    public class LayoutItemHelper
    {
        static readonly Thickness _margin = new Thickness(5, 5, 5, 5);
        static readonly Thickness _padding = new Thickness(3, 3, 3, 3);


        public static List<LayoutItem> GenerateItemList(string projFolderPath)
        {
            List<LayoutItem> itemList = new List<LayoutItem>();
            //Remove reference to mainwindow, add path to app resoureces
            string[] allItems = File.ReadAllLines(Path.Combine(/*MainWindow.AppDirectory*/projFolderPath, "Layout.txt"));

            foreach (var item in allItems)
            {
                string type = item.Split(':')[0];
                string labelName = item.Split(':')[1];
                string state = null;
                string linkedTo = null;
                if (type == "ComboBox")
                {
                    state = item.Split(':')[2];
                    if (state == "Dynamic")
                    {
                        linkedTo = item.Split(':')[3];
                    }   
                }
                else { state = null; }
                LayoutItem layoutItem = new LayoutItem(type, labelName, state, linkedTo);
                
                

                itemList.Add(layoutItem);
            }
            return itemList;
        }


        public static StackPanel GenerateLayout(LayoutItem item, string projFolderPath)
        {
            var sp = new StackPanel() { Orientation = Orientation.Horizontal };
            var label = new TextBlock() { Text = item.LabelName, Padding = _padding, Margin = _margin };
            if(item.Type == "ComboBox")
            {
                var path = Path.Combine(new string[] { /*MainWindow.AppDirectory*/projFolderPath, item.LabelName + ".txt" });
                if (item.State == "Static")
                {
                    string[] list = File.ReadAllLines(path);
                    var cb = item.ControlItem as ComboBox;
                    cb.ItemsSource = list.ToList(); 
                }

            }
            sp.Children.Add(label);
            sp.Children.Add(item.ControlItem);
            return sp;
        }




    }
}

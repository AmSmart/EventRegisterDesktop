using EventRegisterDesktop.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace EventRegisterDesktop
{
    public class LayoutItem
    {
        private static int _tbCount = 0;
        private static int _cbCount = 0;

        private readonly Thickness _margin = new Thickness(15, 5, 5, 5);
        private readonly Thickness _padding = new Thickness(3, 3, 3, 3);
        private readonly int _width = 150;

        public string ContentText { get; set; }
        public string Type { get; private set; }
        public string LabelName { get; private set; }
        public string State { get; private set; } 
        public Control ControlItem { get; private set; }
        public string LinkedTo { get; private set; } // Useful only to Dynamic ComboBoxes
        public int CurrentIndex { get; private set; } // Useful only to ComboBoxes


        public LayoutItem(string type, string labelName, string state, string linkedTo)
        {
            if (type == "TextBox" || type == "ComboBox")
            {
                Type = type;
                LabelName = labelName;
                State = state;
                LinkedTo = linkedTo;
                BuildItem();
                RegisterListeners();
                SetLayoutProperties();
            }
            else
            {
                throw new InvalidOperationException("This type of control is not allowed");
            }
        }

        private void SetLayoutProperties()
        {
            ControlItem.Margin = _margin;
            ControlItem.Padding = _padding;
            ControlItem.Width = _width;
        }

        private void BuildItem()
        {
            if (Type == "TextBox")
            {
                _tbCount++;
                var tb = new TextBox
                {
                    Name = Type + _tbCount
                };
                ControlItem = tb;
            }
            else
            {
                _cbCount++;
                var cb = new ComboBox
                {
                    Name = Type + _cbCount,
                    IsTabStop = false
                };
                ControlItem = cb;
                
            }
        }

        public void Clear()
        {
            if (Type == "TextBox")
            {
                var tb = ControlItem as TextBox;
                tb.Text = "";
            }
            else
            {
                var cb = ControlItem as ComboBox;
                cb.SelectedIndex = 0;
            }
        }

       

        public void RegisterListeners()
        {
            if(Type == "TextBox")
            {
                var tb = ControlItem as TextBox;
                tb.TextChanged += delegate
                {
                    ContentText = tb.Text;
                };
            }
            else
            {
                var cb = ControlItem as ComboBox;
                cb.DropDownClosed += delegate
                {
                    try { ContentText = cb.SelectedItem.ToString(); }
                    catch { /*Log error*/}
                    CurrentIndex = cb.SelectedIndex;
                };
            }
        }

        
    }
}

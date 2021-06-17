using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Eliteria.Converters
{
    public class TextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush LightPrimaryColor = (SolidColorBrush)Application.Current.Resources["LightPrimaryColorBrush"];
            ListBoxItem lvi = value as ListBoxItem;
            SolidColorBrush brush = new SolidColorBrush(Colors.Black);
            if (lvi != null)
            {
                ListBox lv = ItemsControl.ItemsControlFromItemContainer(lvi) as ListBox;
                int ordinal = lv.ItemContainerGenerator.IndexFromContainer(lvi) + 1;
                if (ordinal % 2 == 0) brush = new SolidColorBrush(Colors.White);
            }
            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.InvalidOperationException();
        }
    }
}

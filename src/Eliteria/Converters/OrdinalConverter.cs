using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Eliteria.Converters
{
    public class OrdinalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ListBoxItem lvi = value as ListBoxItem;
            int ordinal = 0;
            if (lvi != null)
            {
                ListBox lv = ItemsControl.ItemsControlFromItemContainer(lvi) as ListBox;
                ordinal = lv.ItemContainerGenerator.IndexFromContainer(lvi) + 1;
            }
            return ordinal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.InvalidOperationException();
        }
    }
}

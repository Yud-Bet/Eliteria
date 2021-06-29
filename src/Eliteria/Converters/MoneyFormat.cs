using System;
using System.Globalization;
using System.Windows.Data;

namespace Eliteria.Converters
{
    class MoneyFormat : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal val = (decimal)value;
            NumberFormatInfo nfi = new CultureInfo("vi-VN", false).NumberFormat;
            return val.ToString("C", nfi);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}

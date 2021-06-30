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
            string val = (string)value;

            val = val.Replace(",", "").Replace("₫", "").Replace(".", "").TrimStart('0');
            if (string.IsNullOrEmpty(val))
            {
                return 0.0m;
            }
            return decimal.Parse(val, NumberStyles.AllowCurrencySymbol | NumberStyles.Number);
        }
    }
}

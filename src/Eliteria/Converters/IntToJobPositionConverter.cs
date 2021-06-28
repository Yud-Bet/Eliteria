using System;
using System.Globalization;
using System.Windows.Data;

namespace Eliteria.Converters
{
    class IntToJobPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value == 1 ? "Quản lý" : "Nhân viên";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value == "Quản lý" ? 1 : 2;
        }
    }
}

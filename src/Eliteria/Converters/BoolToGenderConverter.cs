using System;
using System.Globalization;
using System.Windows.Data;

namespace Eliteria.Converters
{
    class BoolToGenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value == true ? "Nam" : "Nữ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "Nam") return true;
            else return false;
        }
    }
}

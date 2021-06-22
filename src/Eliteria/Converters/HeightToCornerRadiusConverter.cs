using System;
using System.Globalization;
using System.Windows.Data;

namespace Eliteria.Converters
{
    class HeightToCornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double height = (double)value;
            return height / 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.InvalidOperationException();
        }
    }
}

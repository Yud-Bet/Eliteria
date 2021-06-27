using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Eliteria.Converters
{
    class DiameterAndThicknessToStrokeDashArrayConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || !double.TryParse(values[0].ToString(), out double diameter) || !double.TryParse(values[1].ToString(), out double Thickness))
            {
                return 0;
            }

            double circumference = Math.PI * diameter;
            double lineLength = 0.75 * circumference;
            double gapLength = 0.25 * circumference;

            return new DoubleCollection(new[] { lineLength / Thickness, gapLength / Thickness });
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

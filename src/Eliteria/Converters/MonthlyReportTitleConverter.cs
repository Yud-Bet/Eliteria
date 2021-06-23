using System;
using System.Globalization;
using System.Windows.Data;

namespace Eliteria.Converters
{
    class MonthlyReportTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Báo cáo mở/đóng sổ tháng " + value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}

using System;
using System.Globalization;
using System.Windows.Data;

namespace Eliteria.Converters
{
    class DailyReportTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Báo cáo doanh số hoạt động ngày " + value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}

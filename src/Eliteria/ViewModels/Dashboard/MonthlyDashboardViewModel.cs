using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.ObjectModel;

namespace Eliteria.ViewModels
{
    class MonthlyDashboardViewModel: BaseViewModel
    {
        public MonthlyDashboardViewModel()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Sổ mở",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Sổ đóng",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            YFormatter = value => value.ToString("C");
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public ObservableCollection<Models.MonthlyReportItemModel> MonthlyReport { get; } = new ObservableCollection<Models.MonthlyReportItemModel>() {
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
            new Models.MonthlyReportItemModel(){
                Date = new DateTime(2019, 1, 1),
                Opened = 43,
                Closed = 2,
                Different = 41
            },
        }; 
    }
}

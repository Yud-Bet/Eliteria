using Eliteria.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Eliteria.Command
{
    class MonthlyDashboardOnSelectedDateChangeCMD : BaseCommand
    {
        private ViewModels.MonthlyDashboardViewModel viewModel;

        public MonthlyDashboardOnSelectedDateChangeCMD(MonthlyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public async override void Execute(object parameter)
        {
            if (viewModel.startMonth <= viewModel.endMonth)
            {
                int n = viewModel.Data.Count;
                DateTime start = viewModel.startMonth.Value;
                DateTime end = viewModel.endMonth.Value;

                if ((start.Year > viewModel.Data[n - 1].Year || (start.Year == viewModel.Data[n - 1].Year && start.Month > viewModel.Data[n - 1].Month))
                    ||(end.Year < viewModel.Data[0].Year || (end.Year == viewModel.Data[0].Year && end.Month < viewModel.Data[0].Month)))
                {
                    MessageBox.Show("Dữ liệu không tồn tại, xin vui lòng chọn lại thời gian!", "Thông báo");
                }
                else
                {
                    LineSeries open = new LineSeries { Title = "Số sổ mở", Values = new ChartValues<decimal>() };
                    LineSeries close = new LineSeries { Title = "Số sổ đóng", Values = new ChartValues<decimal>() };
                    await LoadXAxis(start, end);
                    await LoadLineSeries(open, close, start, end, n);
                    viewModel.SeriesCollection = new SeriesCollection { open, close};
                }
            }
        }

        public async Task LoadXAxis(DateTime start, DateTime end)
        {
            await Task.Run(() => {
                viewModel.xAxis.Clear();
                for (int i = start.Month, j = start.Year; j < end.Year; i++)
                {
                    if (i <= 12) viewModel.xAxis.Add(string.Format("{0}/{1}", i, j));
                    else
                    {
                        i = 0;
                        j++;
                    }
                }
                for (int i = (start.Year < end.Year) ? 1 : start.Month; i <= end.Month; i++)
                {
                    viewModel.xAxis.Add(string.Format("{0}/{1}", i, end.Year));
                }
            });
        }

        public async Task LoadLineSeries(LineSeries open, LineSeries close, DateTime start, DateTime end, int n)
        {
            bool flag = false; //flag indicate have to put zero at the end of chart
            int beginIndex = -1;
            int endIndex = -1;

            await Task.Run(() => {
                for (int i = 0; i < viewModel.Data.Count && (beginIndex == -1 || endIndex == -1); i++)
                {
                    if (viewModel.Data[i].Month == start.Month && viewModel.Data[i].Year == start.Year && beginIndex != -1) beginIndex = i;
                    if (viewModel.Data[i].Month == end.Month && viewModel.Data[i].Year == start.Year && endIndex != -1) endIndex = i;
                }

                if (beginIndex == -1)
                {
                    for (var i = start; i < viewModel.Data[0].Details[0].Date; i = i.AddMonths(1))
                    {
                        open.Values.Add(0.0m);
                        close.Values.Add(0.0m);
                    }
                    beginIndex = 0;
                }
                if (endIndex == -1)
                {
                    flag = true;
                    endIndex = n - 1;
                }

                for (int i = beginIndex; i <= endIndex; i++)
                {
                    decimal openVal = 0;
                    decimal closeVal = 0;

                    if (viewModel.Data[i].Type == viewModel.SelectedAccType)
                    {
                        for (int j = 0; j < viewModel.Data[i].Details.Count; j++)
                        {
                            openVal += viewModel.Data[i].Details[j].Opened;
                            closeVal += viewModel.Data[i].Details[j].Closed;
                        }
                    }

                    open.Values.Add(openVal);
                    close.Values.Add(closeVal);
                }
                if (flag)
                {
                    int m = viewModel.Data[n - 1].Details.Count;
                    for (var i = viewModel.Data[n - 1].Details[m - 1].Date; i < end; i = i.AddMonths(1))
                    {
                        open.Values.Add(0.0m);
                        close.Values.Add(0.0m);
                    }
                }
            });
        }
    }
}

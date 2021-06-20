using Eliteria.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace Eliteria.Command
{
    class DailyDashboardOnSelectedDateChangeCMD : BaseCommand
    {
        private ViewModels.DailyDashboardViewModel viewModel;

        public DailyDashboardOnSelectedDateChangeCMD(DailyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public async override void Execute(object parameter)
        {
            if (viewModel.startDate <= viewModel.endDate)
            {
                int n = viewModel.Data.Count;
                if (viewModel.startDate > viewModel.Data[n - 1].Date
                    || viewModel.endDate < viewModel.Data[0].Date)
                {
                    MessageBox.Show("Dữ liệu không tồn tại, xin vui lòng nhập lại ngày!", "Thông báo");
                }
                else
                {
                    DateTime start = viewModel.startDate.Value;
                    DateTime end = viewModel.endDate.Value;
                    viewModel.xAxisConst = (viewModel.Data[0].Date - start).Days;
                    LineSeries revenue = new LineSeries { Title = "Tổng thu", Values = new ChartValues<decimal>() };
                    LineSeries expense = new LineSeries { Title = "Tổng chi", Values = new ChartValues<decimal>() };

                    var tasks = new List<Task> { LoadXAxis(start, end), LoadLineSeries(revenue, expense, start, end, n) };
                    await Task.WhenAll(tasks);
                    viewModel.seriesCollection = new SeriesCollection { revenue, expense };
                }
            }
        }

        public async Task LoadXAxis(DateTime start, DateTime end)
        {
            await Task.Run(() => {
                viewModel.xAxis.Clear();
                for (var i = start; i <= end; i = i.AddDays(1))
                {
                    viewModel.xAxis.Add(i.ToString("dd/MM/yy"));
                }
            });
        }

        public async Task LoadLineSeries(LineSeries revenue, LineSeries expense, DateTime start, DateTime end, int n)
        {
            bool flag = false; //flag indicate have to put zero at the end of chart
            int beginIndex = -1;
            int endIndex = -1;

            await Task.Run(() => {
                for (int i = 0; i < viewModel.Data.Count && (beginIndex == -1 || endIndex == -1); i++)
                {
                    if (viewModel.Data[i].Date == start) beginIndex = i;
                    if (viewModel.Data[i].Date == end) endIndex = i;
                }

                if (beginIndex == -1)
                {
                    for (var i = start; i < viewModel.Data[0].Date; i = i.AddDays(1))
                    {
                        revenue.Values.Add(0.0m);
                        expense.Values.Add(0.0m);
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
                    decimal revenueVal = 0;
                    decimal expenseVal = 0;

                    for (int j = 0; j < viewModel.Data[i].DayReports.Count; j++)
                    {
                        revenueVal += viewModel.Data[i].DayReports[j].Revenue;
                        expenseVal += viewModel.Data[i].DayReports[j].Expense;
                    }

                    revenue.Values.Add(revenueVal);
                    expense.Values.Add(expenseVal);
                }
                if (flag)
                {
                    for (var i = viewModel.Data[n - 1].Date; i < end; i = i.AddDays(1))
                    {
                        revenue.Values.Add(0.0m);
                        expense.Values.Add(0.0m);
                    }
                }
            });
        }
    }
}

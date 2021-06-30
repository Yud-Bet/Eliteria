using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class MonthlyDashboardOnSelectedDateChangeCMD : BaseCommandAsync
    {
        private ViewModels.MonthlyDashboardViewModel viewModel;
        private ShowMessageCommand message;

        public MonthlyDashboardOnSelectedDateChangeCMD(ViewModels.MonthlyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
            message = new ShowMessageCommand(viewModel.homeNavigationStore, "Thông báo", "Dữ liệu không tồn tại, xin vui lòng chọn lại thời gian!");
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (viewModel.startMonth <= viewModel.endMonth && viewModel.SelectedAccType != null)
            {
                int n = viewModel.Data.Count;
                DateTime start = viewModel.startMonth.Value;
                DateTime end = viewModel.endMonth.Value;

                if (n ==0 || CompareMonth(start.Month, start.Year, viewModel.Data[n - 1].Month, viewModel.Data[n - 1].Year) == 1
                    || CompareMonth(viewModel.Data[0].Month, viewModel.Data[0].Year, end.Month, end.Year) == 1)
                {
                    message?.Execute(null);
                }
                else
                {
                    LineSeries open = new LineSeries { Title = "Số sổ mở", Values = new ChartValues<decimal>() };
                    LineSeries close = new LineSeries { Title = "Số sổ đóng", Values = new ChartValues<decimal>() };
                    await LoadXAxis(start, end);
                    await LoadLineSeries(open, close, start, end, n);
                    viewModel.SeriesCollection = new SeriesCollection { open, close };
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
                if (CompareMonth(start.Month, start.Year, viewModel.Data[0].Month, viewModel.Data[0].Year) == 1
                    || CompareMonth(start.Month, start.Year, viewModel.Data[0].Month, viewModel.Data[0].Year) == 0)
                {
                    for (int i = 0; i < viewModel.Data.Count && beginIndex == -1; i++)
                    {
                        if (CompareMonth(viewModel.Data[i].Month, viewModel.Data[i].Year, start.Month, start.Year) == 1
                            || CompareMonth(viewModel.Data[i].Month, viewModel.Data[i].Year, start.Month, start.Year) == 0)
                        {
                            beginIndex = i;
                        }
                    }
                }
                if (CompareMonth(end.Month, end.Year, viewModel.Data[n - 1].Month, viewModel.Data[n - 1].Year) == -1
                    || CompareMonth(end.Month, end.Year, viewModel.Data[n - 1].Month, viewModel.Data[n - 1].Year) == 0)
                {
                    for (int i = n -1; i >= 0 && endIndex == -1; i--)
                    {
                        if (CompareMonth(viewModel.Data[i].Month, viewModel.Data[i].Year, end.Month, end.Year) == -1
                            || CompareMonth(viewModel.Data[i].Month, viewModel.Data[i].Year, end.Month, end.Year) == 0)
                        {
                            endIndex = i;
                        }
                    }
                }

                if (beginIndex > endIndex && endIndex != -1)
                {
                    message?.Execute(null);
                }
                int key = 0;
                if (beginIndex == -1)
                {
                    for (var i = start; CompareMonth(i.Month, i.Year, viewModel.Data[0].Month, viewModel.Data[0].Year) == -1; i = i.AddMonths(1))
                    {
                        open.Values.Add(0m);
                        close.Values.Add(0m);
                        key++;
                    }
                    beginIndex = 0;
                }
                if (endIndex == -1)
                {
                    flag = true;
                    endIndex = n - 1;
                }

                int DataIterator = beginIndex;
                viewModel.xAxisToDataIndexConverter.Clear();
                DateTime iteratorLimit = (CompareMonth(end.Month, end.Year, viewModel.Data[n - 1].Month, viewModel.Data[n - 1].Year) == -1) ? end : viewModel.Data[n - 1].Details[0].Date;
                DateTime iteratorBase = (CompareMonth(start.Month, start.Year, viewModel.Data[0].Month, viewModel.Data[0].Year) == 1) ? start : viewModel.Data[0].Details[0].Date;
                for (var iterator = iteratorBase; CompareMonth(iterator.Month, iterator.Year, iteratorLimit.Month, iteratorLimit.Year) == -1
                                                || CompareMonth(iterator.Month, iterator.Year, iteratorLimit.Month, iteratorLimit.Year) == 0; iterator = iterator.AddMonths(1))
                {
                    decimal openVal = 0;
                    decimal closeVal = 0;

                    for (; DataIterator < viewModel.Data.Count && CompareMonth(iterator.Month, iterator.Year, viewModel.Data[DataIterator].Month, viewModel.Data[DataIterator].Year) == 0; DataIterator++)
                    {
                        if (viewModel.Data[DataIterator].Type == viewModel.SelectedAccType)
                        {
                            viewModel.xAxisToDataIndexConverter.Add(key, DataIterator);

                            for (int i = 0; i < viewModel.Data[DataIterator].Details.Count; i++)
                            {
                                openVal += viewModel.Data[DataIterator].Details[i].Opened;
                                closeVal += viewModel.Data[DataIterator].Details[i].Closed;
                            }
                        }
                    }

                    key++;
                    open.Values.Add(openVal);
                    close.Values.Add(closeVal);
                }

                if (flag)
                {
                    for (var i = viewModel.Data[n - 1].Details[0].Date; CompareMonth(i.Month, i.Year, end.Month, end.Year) == -1; i = i.AddMonths(1))
                    {
                        open.Values.Add(0m);
                        close.Values.Add(0m);
                    }
                }
                viewModel.SeriesCollection = new SeriesCollection { open, close};
            });
        }

        private int CompareMonth(int firstMonth, int firstYear, int secondMonth, int secondYear)
        {
            if (firstYear > secondYear || firstMonth > secondMonth && firstYear == secondYear) return 1;
            else if (firstMonth == secondMonth && firstYear == secondYear) return 0;
            else return -1;
        }
    }
}

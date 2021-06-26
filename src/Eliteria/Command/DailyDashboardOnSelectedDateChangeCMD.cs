﻿using LiveCharts;
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

        public DailyDashboardOnSelectedDateChangeCMD(ViewModels.DailyDashboardViewModel viewModel)
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
                    viewModel.OpenMessageCommand?.Execute(null);
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
                if (start >= viewModel.Data[0].Date)
                {
                    for (int i = 0; i < viewModel.Data.Count && beginIndex == -1; i++)
                    {
                        if (viewModel.Data[i].Date >= start) beginIndex = i;
                    }
                }
                if (end <= viewModel.Data[n - 1].Date)
                {
                    for (int i = viewModel.Data.Count - 1; i >= 0 && endIndex == -1; i--)
                    {
                        if (viewModel.Data[i].Date <= end) endIndex = i;
                    }
                }

                int key = 0;
                if (beginIndex == -1)
                {
                    for (var i = start; i < viewModel.Data[0].Date; i = i.AddDays(1))
                    {
                        revenue.Values.Add(0.0m);
                        expense.Values.Add(0.0m);
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
                DateTime iteratorLimit = end < viewModel.Data[n - 1].Date ? end : viewModel.Data[n - 1].Date;
                for (var iterator = start > viewModel.Data[0].Date ? start : viewModel.Data[0].Date; iterator <= iteratorLimit; iterator = iterator.AddDays(1))
                {
                    decimal revenueVal = 0;
                    decimal expenseVal = 0;
                    if (iterator == viewModel.Data[DataIterator].Date)
                    {
                        viewModel.xAxisToDataIndexConverter.Add(key, DataIterator);
                        for (int k = 0; k < viewModel.Data[DataIterator].DayReports.Count; k++)
                        {
                            revenueVal += viewModel.Data[DataIterator].DayReports[k].Revenue;
                            expenseVal += viewModel.Data[DataIterator].DayReports[k].Expense;
                        }
                        DataIterator++;
                    }

                    key++;
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
                viewModel.seriesCollection = new SeriesCollection { revenue, expense };
            });
        }
    }
}
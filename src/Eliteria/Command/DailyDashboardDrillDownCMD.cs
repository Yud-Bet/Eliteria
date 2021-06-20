﻿using Eliteria.ViewModels;
using LiveCharts;

namespace Eliteria.Command
{
    class DailyDashboardDrillDownCMD : BaseCommand
    {
        private ViewModels.DailyDashboardViewModel viewModel;

        public DailyDashboardDrillDownCMD(DailyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            ChartPoint chartPoint = (ChartPoint)parameter;
            int x = xAxisConverter((int)chartPoint.X);
            if (x > -1)
            {
                viewModel.DailyReport = new System.Collections.ObjectModel.ObservableCollection<Models.DayReport>(viewModel.Data[x].DayReports);
            }
            else viewModel.DailyReport = null;
            viewModel.selectedDay = viewModel.xAxis[(int)chartPoint.X];
        }

        private int xAxisConverter(int x)
        {
            if (x >= viewModel.xAxisConst && x < viewModel.Data.Count + viewModel.xAxisConst)
            {
                return x - viewModel.xAxisConst;
            }
            return -1;
        }
    }
}

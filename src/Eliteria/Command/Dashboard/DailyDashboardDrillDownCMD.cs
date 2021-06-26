using LiveCharts;

namespace Eliteria.Command
{
    class DailyDashboardDrillDownCMD : BaseCommand
    {
        private ViewModels.DailyDashboardViewModel viewModel;

        public DailyDashboardDrillDownCMD(ViewModels.DailyDashboardViewModel viewModel)
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
            if (viewModel.xAxisToDataIndexConverter.ContainsKey(x))
            {
                return viewModel.xAxisToDataIndexConverter[x];
            }
            return -1;
        }
    }
}

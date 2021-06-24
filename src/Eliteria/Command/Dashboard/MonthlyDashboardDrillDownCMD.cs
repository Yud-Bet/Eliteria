using LiveCharts;

namespace Eliteria.Command
{
    class MonthlyDashboardDrillDownCMD : BaseCommand
    {
        private ViewModels.MonthlyDashboardViewModel viewModel;

        public MonthlyDashboardDrillDownCMD(ViewModels.MonthlyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            ChartPoint chartPoint = (ChartPoint)parameter;
            int x = xAxisConverter((int)chartPoint.X);
            if (x > -1)
            {
                viewModel.MonthlyReport = new System.Collections.ObjectModel.ObservableCollection<Models.MonthReport>(viewModel.Data[x].Details);
            }
            else viewModel.MonthlyReport = null;
            viewModel.SelectedMonth = viewModel.xAxis[(int)chartPoint.X];
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

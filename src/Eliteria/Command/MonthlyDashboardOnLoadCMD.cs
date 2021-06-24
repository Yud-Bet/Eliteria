using Eliteria.ViewModels;
namespace Eliteria.Command
{
    class MonthlyDashboardOnLoadCMD : BaseCommand
    {
        private ViewModels.MonthlyDashboardViewModel viewModel;

        public MonthlyDashboardOnLoadCMD(MonthlyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public async override void Execute(object parameter)
        {
            viewModel.SavingsAccTypes = await DataAccess.DASavingsType.Load();
            viewModel.Data = await DataAccess.DAMonthlyData.Load();
        }
    }
}

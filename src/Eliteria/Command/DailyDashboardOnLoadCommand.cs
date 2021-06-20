namespace Eliteria.Command
{
    class DailyDashboardOnLoadCommand : BaseCommand
    {
        private ViewModels.DailyDashboardViewModel viewModel;
        public DailyDashboardOnLoadCommand(ViewModels.DailyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public async override void Execute(object parameter)
        {
            viewModel.Data = await DataAccess.DALoadRevenueData.Load();
        }
    }
}

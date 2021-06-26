using System.Threading.Tasks;

namespace Eliteria.Command
{
    class DailyDashboardOnLoadCommand : BaseCommandAsync
    {
        private ViewModels.DailyDashboardViewModel viewModel;
        public DailyDashboardOnLoadCommand(ViewModels.DailyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public async override Task ExecuteAsync(object parameter)
        {
            viewModel.Data = await DataAccess.DALoadRevenueData.Load();
        }
    }
}

using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class DashboardViewModel: BaseViewModel
    {
        private Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        public BaseViewModel currentViewModel => navigationStore.CurrentViewModel;
        
        public DashboardViewModel()
        {
            navigationStore.CurrentViewModel = new DailyDashboardViewModel();
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateDailyDashboardCMD = new Command.NavigateCMD<DailyDashboardViewModel>(
                new Services.NavigationService<DailyDashboardViewModel>(navigationStore, () => new DailyDashboardViewModel()));
            NavigateMonthlyDashboardCMD = new Command.NavigateCMD<MonthlyDashboardViewModel>(
                new Services.NavigationService<MonthlyDashboardViewModel>(navigationStore, () => new MonthlyDashboardViewModel()));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(currentViewModel));
        }

        public ICommand NavigateDailyDashboardCMD { get; }
        public ICommand NavigateMonthlyDashboardCMD { get; }
    }
}

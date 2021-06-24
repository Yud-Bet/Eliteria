using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class DashboardViewModel: BaseViewModel
    {
        private Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        private Stores.NavigationStore _homeNavigationStore;

        public BaseViewModel currentViewModel => navigationStore.CurrentViewModel;
        
        public DashboardViewModel(Stores.NavigationStore homeNavigationStore)
        {
            _homeNavigationStore = homeNavigationStore;

            navigationStore.CurrentViewModel = new DailyDashboardViewModel(_homeNavigationStore);
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateDailyDashboardCMD = new Command.NavigateCMD(CreateDailyDashboardNavSvc());
            NavigateMonthlyDashboardCMD = new Command.NavigateCMD(CreateMonthlyDashboardNavSvc());
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(currentViewModel));
        }

        public ICommand NavigateDailyDashboardCMD { get; }
        public ICommand NavigateMonthlyDashboardCMD { get; }


        private Services.INavigationService CreateDailyDashboardNavSvc()
        {
            return new Services.NavigationService<DailyDashboardViewModel>(navigationStore, () => new DailyDashboardViewModel(_homeNavigationStore));
        }
        private Services.INavigationService CreateMonthlyDashboardNavSvc()
        {
            return new Services.NavigationService<MonthlyDashboardViewModel>(navigationStore, () => new MonthlyDashboardViewModel(_homeNavigationStore));
        }
    }
}

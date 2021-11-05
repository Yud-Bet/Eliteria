using Eliteria.Stores;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private Stores.NavigationStore navigationStore;
        private Stores.NavigationStore mainNavigationStore;

        public Stores.AccountStore accountStore { get; set; }

        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;

        public ICommand navigateSavingAccountListCMD { get; }
        public ICommand navigateDashboardCMD { get; }
        public ICommand navigateTransactionCMD { get; }
        public ICommand navigateLoginCMD { get; }
        public ICommand navigateStaffInfoCMD { get; }
        public ICommand navigateSettingCMD { get; }

        public HomeViewModel(Stores.NavigationStore mainNavStores, Stores.NavigationStore navigationStore, Stores.AccountStore accountStore)
        {
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModel = new SavingsAccountListViewModel(navigationStore);
            this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            this.accountStore = accountStore;
            this.mainNavigationStore = mainNavStores;

            navigateSavingAccountListCMD = new Command.NavigateCMD(CreateSavingsAccountListNavSvc());
            navigateDashboardCMD = new Command.NavigateCMD(CreateDashboardNavSvc());
            navigateTransactionCMD = new Command.NavigateCMD(CreateTransactionNavSvc());
            navigateLoginCMD = new Command.NavigateCMD(CreateLoginNavSvc());
            navigateStaffInfoCMD = new Command.NavigateCMD(CreateStaffInfoNavSvc());
            navigateSettingCMD = new Command.NavigateCMD(CreateSettingNavSvc());
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }


        private Services.INavigationService CreateSavingsAccountListNavSvc()
        {
            return new Services.NavigationService<SavingsAccountListViewModel>(this.navigationStore, () => new SavingsAccountListViewModel(navigationStore));
        }
        private Services.INavigationService CreateDashboardNavSvc()
        {
            return new Services.NavigationService<DashboardViewModel>(this.navigationStore, () => new DashboardViewModel(this.navigationStore));
        }
        private Services.INavigationService CreateTransactionNavSvc()
        {
            return new Services.NavigationService<TransactionViewModel>(this.navigationStore, () => new TransactionViewModel(navigationStore, accountStore));
        }
        private Services.INavigationService CreateStaffInfoNavSvc()
        {
            return new Services.ModalNavigationService<StaffInfoViewModel>(this.navigationStore, () => new StaffInfoViewModel(navigationStore, accountStore));
        }
        private Services.INavigationService CreateLoginNavSvc()
        {
            return new Services.NavigationService<LoginViewModel>(mainNavigationStore, () => new LoginViewModel(mainNavigationStore, navigationStore, accountStore));
        }
        private Services.INavigationService CreateSettingNavSvc()
        {
            return new Services.NavigationService<SettingViewModel>(navigationStore, () => new SettingViewModel(navigationStore, accountStore));
        }
    }
}

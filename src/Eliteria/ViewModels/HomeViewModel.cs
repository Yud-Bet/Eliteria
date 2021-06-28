using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        private Stores.NavigationStore navigationStore;
        private Stores.NavigationStore mainNavigationStore;
        private Stores.AccountStore accountStore = new Stores.AccountStore();

        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;
        public string StaffName { get; set; }

        public ICommand navigateSavingAccountListCMD { get; }
        public ICommand navigateDashboardCMD { get; }
        public ICommand navigateTransactionCMD { get; }
        public ICommand navigateLoginCMD { get; }

        public HomeViewModel(Stores.NavigationStore mainNavStores, Stores.NavigationStore navigationStore, Stores.AccountStore accountStore)
        {
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModel = new SavingsAccountListViewModel();
            this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            this.accountStore = accountStore;
            this.mainNavigationStore = mainNavStores;

            navigateSavingAccountListCMD = new Command.NavigateCMD(CreateSavingsAccountListNavSvc());
            navigateDashboardCMD = new Command.NavigateCMD(CreateDashboardNavSvc());
            navigateTransactionCMD = new Command.NavigateCMD(CreateTransactionNavSvc());
            navigateLoginCMD = new Command.NavigateCMD(CreateLoginNavSvc());

            //StaffName = accountStore.CurrentAccount.StaffName;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }


        private Services.INavigationService CreateSavingsAccountListNavSvc()
        {
            return new Services.NavigationService<SavingsAccountListViewModel>(this.navigationStore, () => new SavingsAccountListViewModel());
        }
        private Services.INavigationService CreateDashboardNavSvc()
        {
            return new Services.NavigationService<DashboardViewModel>(this.navigationStore, () => new DashboardViewModel(this.navigationStore));
        }
        private Services.INavigationService CreateTransactionNavSvc()
        {
            return new Services.NavigationService<TransactionViewModel>(this.navigationStore, () => new TransactionViewModel(navigationStore, accountStore));
        }
        private Services.INavigationService CreateLoginNavSvc()
        {
            return new Services.NavigationService<LoginViewModel>(mainNavigationStore, () => new LoginViewModel(mainNavigationStore, navigationStore, accountStore));
        }
    }
}

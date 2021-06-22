using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        Stores.NavigationStore navigationStore;
        Stores.NavigationStore mainNavigationStore;
        Stores.AccountStore accountStore = new Stores.AccountStore();

        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;
        public ICommand navigateSavingAccountListCMD { get; }
        public ICommand navigateDashboardCMD { get; }
        public ICommand navigateTransactionCMD { get; }
        public ICommand navigateLoginCMD { get; }
        public string StaffName { get; set; }

        public ICommand loadSavingsListCMD { get; set; }
        public HomeViewModel(Stores.NavigationStore mainNavStores, Stores.NavigationStore navigationStore, Stores.AccountStore accountStore)
        {
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModel = new SavingsAccountListViewModel();
            this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            navigateSavingAccountListCMD = new Command.NavigateCMD(CreateSavingsAccountListNavSvc());

            navigateDashboardCMD = new Command.NavigateCMD(CreateDashboardNavSvc());

            navigateTransactionCMD = new Command.NavigateCMD(CreateTransactionNavSvc());

            navigateLoginCMD = new Command.NavigateCMD<LoginViewModel>(
                new Services.NavigationService<LoginViewModel>(mainNavStores, () => new LoginViewModel(mainNavStores, accountStore)));

            this.accountStore = accountStore;
            this.mainNavigationStore = mainNavStores;
            StaffName = accountStore.CurrentAccount.StaffName;
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
            return new Services.NavigationService<TransactionViewModel>(this.navigationStore, () => new TransactionViewModel());
        }
    }
}

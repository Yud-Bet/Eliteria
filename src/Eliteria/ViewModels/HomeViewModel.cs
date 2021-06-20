using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class HomeViewModel: BaseViewModel
    {
        Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        public Stores.AccountStore accountStore { get; set; }
        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;
        public ICommand navigateSavingAccountListCMD { get; }
        public ICommand navigateDashboardCMD { get; }
        public ICommand navigateTransactionCMD { get; }
        public ICommand navigateLoginCMD { get; }
        public string StaffName { get; set; }

        public HomeViewModel(Stores.AccountStore accountStore)
        {
            this.navigationStore.CurrentViewModel = new SavingsAccountListViewModel(savingsAccountsStore);
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            navigateSavingAccountListCMD = new Command.NavigateCMD<SavingsAccountListViewModel>(
                new Services.NavigationService<SavingsAccountListViewModel>(navigationStore, () => new SavingsAccountListViewModel(savingsAccountsStore)));

            navigateDashboardCMD = new Command.NavigateCMD<DashboardViewModel>(
                new Services.NavigationService<DashboardViewModel>(navigationStore, () => new DashboardViewModel()));

            navigateTransactionCMD = new Command.NavigateCMD<TransactionViewModel>(
                new Services.NavigationService<TransactionViewModel>(navigationStore, () => new TransactionViewModel()));

            navigateLoginCMD = new Command.NavigateCMD<LoginViewModel>(
                new Services.NavigationService<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore, accountStore)));

            this.accountStore = accountStore;
            StaffName = accountStore.CurrentAccount.StaffName;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }

        public Stores.SavingsAccountsStore savingsAccountsStore = new Stores.SavingsAccountsStore()
        {
            savingsAccounts = new ObservableCollection<Models.SavingsAccount>
            {
                new Models.SavingsAccount() { Name = "Elly", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "Dakota", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "Johnson", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "Thomas", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "Peterson", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "Shelby", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "Athur", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "George", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "Thompson", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "Jerry", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "Bob", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                new Models.SavingsAccount() { Name = "Kelvin", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" }
            }
        };
    }
}

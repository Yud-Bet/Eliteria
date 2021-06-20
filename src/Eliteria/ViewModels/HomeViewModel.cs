using System.Collections.ObjectModel;
using System.Windows.Input;
using Eliteria.Command;
using Eliteria.DataAccess;

namespace Eliteria.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        Stores.AccountStore accountStore = new Stores.AccountStore();

        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;
        public ICommand navigateSavingAccountListCMD { get; }
        public ICommand navigateDashboardCMD { get; }
        public ICommand navigateTransactionCMD { get; }
        public ICommand navigateLoginCMD { get; }
        public string StaffName { get; set; }

        public ICommand loadSavingsListCMD { get; set; }
        public HomeViewModel(Stores.AccountStore accountStore)
        {
            this.navigationStore.CurrentViewModel = new SavingsAccountListViewModel();
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            navigateSavingAccountListCMD = new Command.NavigateCMD<SavingsAccountListViewModel>(
                new Services.NavigationService<SavingsAccountListViewModel>(navigationStore, () => new SavingsAccountListViewModel()));

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
    }
}

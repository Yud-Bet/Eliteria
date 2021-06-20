using Eliteria.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

            this.accountStore = accountStore;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }
    }
}

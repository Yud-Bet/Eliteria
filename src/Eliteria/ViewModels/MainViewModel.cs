using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        Stores.AccountStore accountStore = new Stores.AccountStore();
        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;



        public ICommand navigateSavingAccountListCMD { get; }
        public ICommand navigateDashboardCMD { get; }
        public ICommand navigateTransactionCMD { get; }


        DataAccess.DASavingAccountList DASavingAccountList = new DataAccess.DASavingAccountList();
        Stores.SavingsAccountsStore savingsAccountsStore = new Stores.SavingsAccountsStore();
        public MainViewModel()
        {

            savingsAccountsStore.savingsAccounts = new ObservableCollection<SavingsAccount>();
            DASavingAccountList.LoadListFromDatabase(savingsAccountsStore.savingsAccounts);



            this.navigationStore.CurrentViewModel = new SavingsAccountListViewModel(savingsAccountsStore);
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            navigateSavingAccountListCMD = new Command.NavigateCMD<SavingsAccountListViewModel>(
                new Services.NavigationService<SavingsAccountListViewModel>(navigationStore, () => new SavingsAccountListViewModel(savingsAccountsStore)));

            navigateDashboardCMD = new Command.NavigateCMD<DashboardViewModel>(
                new Services.NavigationService<DashboardViewModel>(navigationStore, () => new DashboardViewModel()));

            navigateTransactionCMD = new Command.NavigateCMD<TransactionViewModel>(
                new Services.NavigationService<TransactionViewModel>(navigationStore, () => new TransactionViewModel()));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }








    }
}

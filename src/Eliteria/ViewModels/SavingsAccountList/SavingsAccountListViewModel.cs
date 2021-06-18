using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class SavingsAccountListViewModel: BaseViewModel
    {
        Stores.SavingsAccountsStore savingsAccountsStore;
        public ObservableCollection<Models.SavingsAccount> savingsAccounts => savingsAccountsStore.savingsAccounts;
        public SavingsAccountListViewModel(Stores.SavingsAccountsStore savingsAccountsStore)
        {
            this.savingsAccountsStore = savingsAccountsStore;
        }

        public ICommand AddButtonCommand;
      
    }
}

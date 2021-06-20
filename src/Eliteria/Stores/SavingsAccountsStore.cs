using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Stores
{
    class SavingsAccountsStore
    {
        public ObservableCollection<Models.SavingsAccount> savingsAccounts;

        public SavingsAccountsStore()
        {
            this.savingsAccounts =  new ObservableCollection<SavingsAccount>();
        }
    }
}

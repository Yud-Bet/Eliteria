using Eliteria.DataAccess;
using Eliteria.Models;
using Eliteria.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.Command
{
    class loadSavingsListCMD : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly HomeViewModel homeViewModel;

        public loadSavingsListCMD(HomeViewModel homeViewModel)
        {
            this.homeViewModel = homeViewModel;
        }

        public bool CanExecute(object parameter)
        {
           return true;
        } 
        public async void Execute(object parameter)
        {
           await DASavingAccountList.LoadListFromDatabase(homeViewModel.savingsAccountsStore.savingsAccounts);
        }

   
    }
}

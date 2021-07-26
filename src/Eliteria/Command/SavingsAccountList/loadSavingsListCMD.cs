
using Eliteria.DataAccess.Models;
using Eliteria.DataAccess.Modules;
using Eliteria.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
namespace Eliteria.Command
{
    class loadSavingsListCMD : BaseCommandAsync
    {
        private readonly SavingsAccountListViewModel viewModel;

        public loadSavingsListCMD(SavingsAccountListViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            viewModel.IsLoading = true;

            // REGULAR DATA ACCESS
            //viewModel.savingsAccounts = await DASavingAccountList.LoadListFromDatabase().ContinueWith(OnSavingsAccLoadCompleted);

            // DATA ACCESS WITH API
            viewModel.savingsAccounts =   await SavingsAccountM.GetSavingsAccounts();

            viewModel.AllSavings = viewModel.savingsAccounts;
            viewModel.IsLoading = false;
        }

        private ObservableCollection<SavingsAccount> OnSavingsAccLoadCompleted(Task<ObservableCollection<SavingsAccount>> arg)
        {
            if (arg.IsFaulted)
            {
                viewModel.IsLoadingError = true;
                return null;
            }
            return arg.Result;
        }
    }
}

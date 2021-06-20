using Eliteria.DataAccess;
using Eliteria.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class loadFilteredSavingsListCMD : BaseCommand
    {
        public string SearchText;
        private readonly SavingsAccountListViewModel viewModel;
        private ObservableCollection<Models.SavingsAccount> OGsavingsAccounts;
        public loadFilteredSavingsListCMD(SavingsAccountListViewModel viewModel, string SearchText)
        {
            this.viewModel = viewModel;
        }
        public async override void Execute(object parameter)
        {
            OGsavingsAccounts = await DASavingAccountList.LoadListFromDatabase();
            if (SearchText != null)
            {
                viewModel.savingsAccounts = (ObservableCollection<Models.SavingsAccount>)viewModel.savingsAccounts.Where(x => x.Name == SearchText || x.AccountNumber == SearchText || x.IdentificationNumber == SearchText);
            }
            else
                viewModel.savingsAccounts = OGsavingsAccounts;
        }
    }
}

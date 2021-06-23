using Eliteria.DataAccess;
using Eliteria.Models;
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

        private readonly SavingsAccountListViewModel viewModel;
        private ObservableCollection<Models.SavingsAccount> OGsavingsAccounts;
        public loadFilteredSavingsListCMD(SavingsAccountListViewModel viewModel)
        {
            this.viewModel = viewModel;

        }
        public async override void Execute(object parameter)
        {
            OGsavingsAccounts = await DASavingAccountList.LoadListFromDatabase();
            ObservableCollection<Models.SavingsAccount> ReadableSearchResult = new ObservableCollection<SavingsAccount>();
            if (viewModel.SearchText != "")
            {

                var SearchResult = OGsavingsAccounts.Where(x => x.IdentificationNumber.Contains(viewModel.SearchText) || x.Name.Contains(viewModel.SearchText) || x.AccountNumber.Contains(viewModel.SearchText));

                for (int i = 0; i < SearchResult.Count(); i++)
                {
                    ReadableSearchResult.Add(SearchResult.ElementAt(i));
                }
                viewModel.savingsAccounts = ReadableSearchResult;
            }
            else
            {
                viewModel.savingsAccounts = OGsavingsAccounts;
            }

        }
    }
}

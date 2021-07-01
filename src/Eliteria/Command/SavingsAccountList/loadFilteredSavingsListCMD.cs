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
        public loadFilteredSavingsListCMD(SavingsAccountListViewModel viewModel)
        {
            this.viewModel = viewModel;

        }
        public async override void Execute(object parameter)
        {
            ObservableCollection<Models.SavingsAccount> ReadableSearchResult = new ObservableCollection<SavingsAccount>();
            if (!string.IsNullOrEmpty(viewModel.SearchText))
            {
                var SearchResult = viewModel.AllSavings.Where(x => x.IdentificationNumber.Contains(viewModel.SearchText) || x.Name.ToUpper().Contains(viewModel.SearchText.ToUpper()) || x.AccountNumber.Contains(viewModel.SearchText));

                for (int i = 0; i < SearchResult.Count(); i++)
                {
                    ReadableSearchResult.Add(SearchResult.ElementAt(i));
                }
                viewModel.savingsAccounts = ReadableSearchResult;
            }
            else
            {
                viewModel.savingsAccounts = viewModel.AllSavings;
            }

        }
    }
}

using Eliteria.DataAccess;
using Eliteria.ViewModels;

namespace Eliteria.Command
{
    class loadSavingsListCMD : BaseCommand
    {
        private readonly SavingsAccountListViewModel viewModel;

        public loadSavingsListCMD(SavingsAccountListViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public async override void Execute(object parameter)
        {
            viewModel.savingsAccounts = await DASavingAccountList.LoadListFromDatabase();
        }
    }
}

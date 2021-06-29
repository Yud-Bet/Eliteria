using System;
using System.Threading.Tasks;
using System.Windows;

namespace Eliteria.Command
{
    class LoadAllSavingsCommand : BaseCommand
    {
        private ViewModels.TransactionViewModel viewModel;

        public LoadAllSavingsCommand(ViewModels.TransactionViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override async void Execute(object parameter)
        {
            try 
            {
                viewModel.SavingList = await DataAccess.TransactionData.GetAllSaving();
            }
            catch (Exception ex)
            {
                (new Command.ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message)).Execute(null);
            }
            viewModel.TransactionMoney = "";
        }
    }
}

using System;
using System.Windows.Input;

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
                ICommand message = new ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message);
                message.Execute(null);
            }
            viewModel.TransactionMoney = "";
        }
    }
}

using Eliteria.DataAccess.Models;
using Eliteria.DataAccess.Modules;
using System;
using System.Collections.ObjectModel;
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
        public override void Execute(object parameter)
        {
            try 
            {
                viewModel.SavingList = new ObservableCollection<SavingsAccount>(MoneyTransactionModule.GetAllSavings());
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

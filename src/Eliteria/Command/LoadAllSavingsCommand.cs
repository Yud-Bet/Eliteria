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
            viewModel.SavingList = await DataAccess.TransactionData.GetAllSaving();
            viewModel.TransactionMoney = "";
        }
    }
}

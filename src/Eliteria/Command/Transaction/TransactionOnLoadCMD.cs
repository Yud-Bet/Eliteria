namespace Eliteria.Command
{
    class TransactionOnLoadCMD : BaseCommand
    {
        private ViewModels.TransactionViewModel viewModel;

        public TransactionOnLoadCMD(ViewModels.TransactionViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            viewModel.LoadAllSavingCMD?.Execute(null);
        }
    }
}

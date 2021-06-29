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
                viewModel.SavingList = await Task.Run(() => {
                    try
                    {
                        return DataAccess.TransactionData.GetAllSaving();
                    }
                    catch
                    {
                        return null;
                    }
                });
                if (viewModel.SavingList == null) throw new Exception("Đã xảy ra lỗi khi tải thông tin từ server");
            }
            catch (Exception ex)
            {
                (new Command.ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message)).Execute(null);
            }
            viewModel.TransactionMoney = "";
        }
    }
}

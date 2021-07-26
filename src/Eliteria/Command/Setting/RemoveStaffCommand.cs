using Eliteria.DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class RemoveStaffCommand : BaseCommand
    {
        private ViewModels.StaffsViewModel viewModel;
        private Stores.NavigationStore _homeNavStore;
        private Stores.AccountStore account;

        public RemoveStaffCommand(ViewModels.StaffsViewModel viewModel, Stores.NavigationStore _homeNavStore, Stores.AccountStore account)
        {
            this.viewModel = viewModel;
            this.viewModel.OnSelectedItemChange += OnCanExecuteChanged;
            this._homeNavStore = _homeNavStore;
            this.account = account;
        }

        public override bool CanExecute(object parameter)
        {
            return viewModel.SelectedStaffIndex > -1;
        }

        public override async void Execute(object parameter)
        {
            if (account.CurrentAccount.StaffID == viewModel.StaffList[viewModel.SelectedStaffIndex].StaffID)
            {
                ShowMessageCommand message = new ShowMessageCommand(_homeNavStore, "Thông báo", "Bạn không thể xóa chính mình");
                message.Execute(null);
            }
            else
            {
                int x = await DataAccess.DAStaffList.DeleteStaff(viewModel.StaffList[viewModel.SelectedStaffIndex].StaffID).ContinueWith(OnQueryFinished);
                if (x > 0)
                {
                    ShowMessageCommand message = new ShowMessageCommand(_homeNavStore, "Thông báo", "Xóa thành công");
                    viewModel.StaffList = await DataAccess.DAStaffList.Load().ContinueWith(OnReaderFinished);
                    message.Execute(null);
                }
            }
        }

        private ObservableCollection<DataAccess.Models.Account> OnReaderFinished(Task<ObservableCollection<DataAccess.Models.Account>> arg)
        {
            if (arg.IsFaulted)
            {
                return null;
            }
            return arg.Result;
        }

        private int OnQueryFinished(Task<int> arg)
        {
            if (arg.IsFaulted)
            {
                return -1;
            }
            return arg.Result;
        }
    }
}

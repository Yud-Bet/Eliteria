using Eliteria.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class StaffsOnLoadCMD : BaseCommandAsync
    {
        ViewModels.StaffsViewModel viewModel;

        public StaffsOnLoadCMD(ViewModels.StaffsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            viewModel.IsLoading = true;
            viewModel.StaffList = await DataAccess.DAStaffList.Load().ContinueWith(OnLoadCompleted);
            viewModel.IsLoading = false;
        }

        private ObservableCollection<Account> OnLoadCompleted(Task<ObservableCollection<Account>> arg)
        {
            if (arg.IsFaulted)
            {
                viewModel.IsLoadingError = true;
                return null;
            }
            return arg.Result;
        }
    }
}

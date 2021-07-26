using Eliteria.DataAccess.Models;
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
            
            viewModel.StaffList = new ObservableCollection<Account>(DataAccess.Modules.SettingModule.EmployeesM.GetAllEmpoyees());

            viewModel.IsLoading = false;
        }

        private ObservableCollection<DataAccess.Models.Account> OnLoadCompleted(Task<ObservableCollection<DataAccess.Models.Account>> arg)
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

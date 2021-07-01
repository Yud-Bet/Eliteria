using System;
using System.Data;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class OtherParametersOnLoadCMD : BaseCommandAsync
    {
        ViewModels.OtherParameterViewModel viewModel;
        public OtherParametersOnLoadCMD(ViewModels.OtherParameterViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public async override Task ExecuteAsync(object parameter)
        {
            viewModel.IsLoading = true;
            DataTable data = await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_LoadOtherParameters").ContinueWith(OnQueryFinished);
            if (data != null)
            {
                viewModel.OtherParameter = new Models.OtherParameter
                {
                    MinDepositAmount = (Decimal)data.Rows[0][1],
                    MinInitialDeposit = (Decimal)data.Rows[0][0],
                    ControlClosingSaving = (bool)data.Rows[0][2]
                };
            }
            viewModel.IsLoading = false;
        }

        private DataTable OnQueryFinished(Task<DataTable> arg)
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

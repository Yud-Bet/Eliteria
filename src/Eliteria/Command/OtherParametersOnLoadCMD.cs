using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eliteria.Command
{
    class OtherParametersOnLoadCMD : BaseCommand
    {
        ViewModels.OtherParameterViewModel viewModel;
        public OtherParametersOnLoadCMD(ViewModels.OtherParameterViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public async override void Execute(object parameter)
        {
            DataTable data = await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_LoadOtherParameters");
            viewModel.OtherParameter = new Models.OtherParameter { MinDepositAmount = data.Rows[0][1].ToString(), MinInitialDeposit = data.Rows[0][0].ToString()};
        }
    }
}

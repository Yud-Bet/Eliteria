using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class EditOtherParametersCMD : BaseCommand
    {
        ViewModels.OtherParameterViewModel viewModel;
        Stores.NavigationStore homeNavigationStore;
        public EditOtherParametersCMD(ViewModels.OtherParameterViewModel viewModel, Stores.NavigationStore homeNavigationStore)
        {
            this.viewModel = viewModel;
            this.homeNavigationStore = homeNavigationStore;
        }
        public override void Execute(object parameter)
        {
            if(DataAccess.ExecuteQuery.ExecuteNoneQuery("Eliteria_EditOtherParameters @MinDepositAmount , @MinInitialDeposit",
                new object[] { this.viewModel.OtherParameter.MinDepositAmount, this.viewModel.OtherParameter.MinInitialDeposit}) == 1)
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Sửa thông tin thành công.")).Execute(null);
            }
        }
    }
}

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
            if (viewModel.OtherParameter.MinInitialDeposit == "")
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Vui lòng không để trống số tiền gửi ban đầu tối thiểu")).Execute(null);
                return;
            }
            else if (viewModel.OtherParameter.MinDepositAmount == "")
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Vui lòng không để trống số tiền gửi thêm tối thiểu")).Execute(null);
                return;
            }

            else if (Convert.ToSingle(viewModel.OtherParameter.MinDepositAmount) == 0)
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Vui lòng nhập số tiền gửi thêm tối thiểu lớn hơn 0")).Execute(null);
                return;
            }
            else if (Convert.ToSingle(viewModel.OtherParameter.MinInitialDeposit) == 0)
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Vui lòng nhập số tiền gửi ban đầu tối thiểu lớn hơn 0")).Execute(null);
                return;
            }

            if (DataAccess.ExecuteQuery.ExecuteNoneQuery("Eliteria_EditOtherParameters @MinDepositAmount , @MinInitialDeposit , @ControlClosingSaving",
                new object[] { this.viewModel.OtherParameter.MinDepositAmount, this.viewModel.OtherParameter.MinInitialDeposit, this.viewModel.OtherParameter.ControlClosingSaving}) == 1)
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Sửa thông tin thành công.")).Execute(null);
            }
        }
    }
}

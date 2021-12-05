using System;

namespace Eliteria.Command
{
    public class EditOtherParametersCMD : BaseCommand
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
            if (!IsFilledOut(viewModel.OtherParameter.MinInitialDeposit, viewModel.OtherParameter.MinDepositAmount, InvalidMinInitDepositCB, InvalidMinDepositAmountCB)) return;

            if (DataAccess.ExecuteQuery.ExecuteNoneQuery("Eliteria_EditOtherParameters @MinDepositAmount , @MinInitialDeposit , @ControlClosingSaving",
                new object[] { this.viewModel.OtherParameter.MinDepositAmount, this.viewModel.OtherParameter.MinInitialDeposit, this.viewModel.OtherParameter.ControlClosingSaving}) == 1)
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Sửa thông tin thành công.")).Execute(null);
            }
        }

        private void InvalidMinDepositAmountCB()
        {
            var msg = new Command.ShowMessageCommand(homeNavigationStore, "Thông báo", "Vui lòng nhập số tiền gửi thêm tối thiểu lớn hơn 0");
            msg.Execute(null);
        }

        private void InvalidMinInitDepositCB()
        {
            var msg = new Command.ShowMessageCommand(homeNavigationStore, "Thông báo", "Vui lòng nhập số tiền gửi ban đầu tối thiểu lớn hơn 0");
            msg.Execute(null);
        }

        private void BlankMinDepositAmountCB()
        {
            var msg = new Command.ShowMessageCommand(homeNavigationStore, "Thông báo", "Vui lòng không để trống số tiền gửi thêm tối thiểu");
            msg.Execute(null);
        }

        private void BlankMinInitDepositCB()
        {
            var msg = new Command.ShowMessageCommand(homeNavigationStore, "Thông báo", "Vui lòng không để trống số tiền gửi ban đầu tối thiểu");
            msg.Execute(null);
        }

        public static bool IsFilledOut(decimal MinInitDeposit, decimal MinDepositAmount, Action InvalidMinInitDepositCB = null, Action InvalidMinDepositAmountCB = null)
        {
            if (MinInitDeposit == 0.0m)
            {
                InvalidMinInitDepositCB?.Invoke();
                return false;
            }
            else if (MinDepositAmount == 0.0m)
            {
                InvalidMinDepositAmountCB?.Invoke();
                return false;
            }
            return true;
        }
    }
}

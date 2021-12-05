using System;

namespace Eliteria.Command
{
    public class EditSavingTypeCommand : BaseCommand
    {
        Stores.NavigationStore homeNavStore;
        ViewModels.EditSavingTypeViewModel viewModel;
        public EditSavingTypeCommand(ViewModels.EditSavingTypeViewModel viewModel, Stores.NavigationStore homeNavStore)
        {
            this.homeNavStore = homeNavStore;
            this.viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            
            if (IsFilledOutValidInfo(viewModel.MinNumOfDateToWithdraw, viewModel.InterestRate, viewModel.SavingType.MinNumOfDateToWithdraw, viewModel.SavingType.InterestRate, InvalidDaysCallback, InvalidInterestRate, OldInfoCallBack))
            {
                int rowsEffect = DataAccess.ExecuteQuery.ExecuteNoneQuery("Eliteria_EditSavingType @ID , @Period , @InterestRate , @MinNumOfDateToWithdraw , @WithdrawalRule",
                                            new object[] { this.viewModel.SavingType.ID, this.viewModel.SavingType.Period, this.viewModel.InterestRate,
                                                        this.viewModel.MinNumOfDateToWithdraw, this.viewModel.SavingType.WithdrawalRule});
                if (rowsEffect == 1)
                {
                    this.viewModel.SavingType.MinNumOfDateToWithdraw = Convert.ToInt32(this.viewModel.MinNumOfDateToWithdraw);
                    this.viewModel.SavingType.InterestRate = Convert.ToSingle(this.viewModel.InterestRate);
                    (new Command.ShowMessageCommand(this.homeNavStore, "Thông báo", "Sửa thông tin thành công.")).Execute(null);
                    viewModel.SavingTypeViewModel.OnLoadCommand.Execute(null);
                }

            }


        }

        private void OldInfoCallBack()
        {
            viewModel.ErrorStatus = "Thông tin cập nhật trùng với thông tin cũ!";
            viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
        }

        private void InvalidInterestRate()
        {
            viewModel.ErrorStatus = "Vui lòng nhập lãi suất lớn hơn 0!";
            viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
        }

        private void InvalidDaysCallback()
        {
            viewModel.ErrorStatus = "Vui lòng nhập số ngày gửi tối thiểu lớn hơn 0!";
            viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
        }

        public static bool IsFilledOutValidInfo(string minDays2Widthdraw, string interestRate, int oldMinDays2Widthdraw, float oldInterestRate, Action invalidDaysCallback = null, Action invalidInterestRate = null, Action oldInfoCallBack = null)
        {
            if (minDays2Widthdraw == "0" || minDays2Widthdraw == "")
            {
                invalidDaysCallback?.Invoke();
                return false;
            }
            if (interestRate == "" || Convert.ToSingle(interestRate) == 0)
            {
                invalidInterestRate?.Invoke();
                return false;
            }
            if (minDays2Widthdraw == oldMinDays2Widthdraw.ToString() && interestRate == oldInterestRate.ToString())
            {
                oldInfoCallBack?.Invoke();
                return false;
            }
            return true;
        }
    }
}

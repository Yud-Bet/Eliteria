using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eliteria.Command
{
    class EditSavingTypeCommand : BaseCommand
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
            if (viewModel.MinNumOfDateToWithdraw == "0"||viewModel.MinNumOfDateToWithdraw=="")
            {
                viewModel.ErrorStatus = "Vui lòng nhập số ngày gửi tối thiểu lớn hơn 0!";
                viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                return;
            }
            if (Convert.ToSingle(viewModel.InterestRate) == 0||viewModel.InterestRate=="")
            {
                viewModel.ErrorStatus = "Vui lòng nhập lãi suất lớn hơn 0!";
                viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                return;
            }

            if (this.viewModel.MinNumOfDateToWithdraw == this.viewModel.SavingType.MinNumOfDateToWithdraw.ToString() && this.viewModel.InterestRate == this.viewModel.SavingType.InterestRate.ToString())
            {
                viewModel.ErrorStatus = "Thông tin cập nhật trùng với thông tin cũ!";
                viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                return;
            }
            else
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
    }
}

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
            if(this.viewModel.MinNumOfDateToWithdraw != this.viewModel.SavingType.MinNumOfDateToWithdraw || this.viewModel.InterestRate != this.viewModel.SavingType.InterestRate)
            {
                int rowsEffect = DataAccess.ExecuteQuery.ExecuteNoneQuery("Eliteria_EditSavingType @ID , @Period , @InterestRate , @MinNumOfDateToWithdraw , @WithdrawalRule",
                                            new object[] { this.viewModel.SavingType.ID, this.viewModel.SavingType.Period, this.viewModel.InterestRate,
                                                        this.viewModel.MinNumOfDateToWithdraw, this.viewModel.SavingType.WithdrawalRule});
                if (rowsEffect == 1)
                {
                    this.viewModel.SavingType.MinNumOfDateToWithdraw = this.viewModel.MinNumOfDateToWithdraw;
                    this.viewModel.SavingType.InterestRate = this.viewModel.InterestRate;
                    (new Command.ShowMessageCommand(this.homeNavStore, "Thông báo", "Sửa thông tin thành công.")).Execute(null);
                }
                else
                {
                    (new Command.ShowMessageCommand(this.homeNavStore, "Thông báo", "Đã tồn tại một loại sổ có các thông số\n(Kỳ hạn, lãi suất, thời gian gửi tối thiểu, quy định rút tiền)\ngiống loại sổ sau khi bạn sửa.\nVui lòng thay đổi ít nhất một thông số (thời gian gửi tối thiểu, lãi suất).")).Execute(null);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eliteria.Command
{
    class AddNewSavingTypeCommand : BaseCommand
    {
        public Models.SavingType newSavingType;
        public ViewModels.SavingTypeViewModel SavingTypeViewModel;
        public Stores.NavigationStore homeNavigationStore;
        public ViewModels.AddNewSavingTypeViewModel addNewSavingViewModel;
        public AddNewSavingTypeCommand(Models.SavingType newSavingType, Stores.NavigationStore homeNavigationStore, ViewModels.AddNewSavingTypeViewModel addNewSavingViewModel, ViewModels.SavingTypeViewModel savingTypeViewModel)
        {
            this.newSavingType = newSavingType;
            this.homeNavigationStore = homeNavigationStore;
            this.addNewSavingViewModel = addNewSavingViewModel;
            this.SavingTypeViewModel = savingTypeViewModel;
            this.newSavingType.EffectiveDate = DateTime.Today;
        }
        public override void Execute(object parameter)
        {

            if (newSavingType.Name == null || newSavingType.Name == "")
            {
                addNewSavingViewModel.ErrorStatus = "Vui lòng nhập tên của loại tiết kiệm";
                addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                return;
            }
            else if (newSavingType.Period == 0)
            {
                addNewSavingViewModel.ErrorStatus = "Vui lòng nhập kỳ hạn";
                addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                return;
            }
            else if (newSavingType.InterestRate == 0)
            {
                addNewSavingViewModel.ErrorStatus = "Vui lòng nhập lãi xuất";
                addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                return;
            }
            else if (newSavingType.MinNumOfDateToWithdraw == 0)
            {
                addNewSavingViewModel.ErrorStatus = "Vui lòng nhập số ngày gửi tối thiểu";
                addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                return;
            }
            else if (newSavingType.EffectiveDate == null)
            {
                addNewSavingViewModel.ErrorStatus = "Vui lòng nhập ngày áp dụng";
                addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                return;
            }
            else if (newSavingType.WithdrawalRule == null)
            {
                addNewSavingViewModel.ErrorStatus = "Vui lòng chọn quy định rút";
                addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                return;
            }
            int rowsEffect = DataAccess.ExecuteQuery.ExecuteNoneQuery("Eliteria_AddNewSavingType @Name , @Period , @InterestRate , @EffectiveDate , @MinNumOfDateToWithdraw , @WithdrawalRule",
                                                        new object[] { newSavingType.Name, newSavingType.Period, newSavingType.InterestRate, newSavingType.EffectiveDate,
                                                        newSavingType.MinNumOfDateToWithdraw, newSavingType.WithdrawalRule});

            if (rowsEffect == 1)
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Thêm loại sổ tiết kiệm thành công.")).Execute(null);
                this.SavingTypeViewModel.OnLoadCommand.Execute(null);
            }
            else
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Đã tồn tại một loại sổ có các thông số\n(Kỳ hạn, lãi suất, thời gian gửi tối thiểu, quy định rút tiền)\ngiống loại sổ bạn muốn thêm.\nVui lòng thay đổi ít nhất một thông số.")).Execute(null);
            }

        }
    }
}

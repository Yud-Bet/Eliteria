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
            int rowsEffect = DataAccess.ExecuteQuery.ExecuteNoneQuery("Eliteria_AddNewSavingType @Name , @Period , @InterestRate , @EffectiveDate , @MinNumOfDateToWithdraw , @WithdrawalRule",
                                                        new object[] { newSavingType.Name, newSavingType.Period, newSavingType.InterestRate, newSavingType.EffectiveDate,
                                                        newSavingType.MinNumOfDateToWithdraw, newSavingType.WithdrawalRule});
            if ( rowsEffect == 1)
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Thêm loại sổ tiết kiệm thành công.")).Execute(null);
                this.SavingTypeViewModel.OnLoadCommand.Execute(null);
            }
            else
            {
                (new Command.ShowMessageCommand(this.homeNavigationStore, "Thông báo", "Đã tồn tại một loại sổ có các thông số\n(Kỳ hạn, lãi suất, thời gian gửi tối thiểu, quy định rút tiền)\ngiống loại sổ bạn muốn thêm.\nVui lòng thay đổi ít nhất một thông số.")).Execute(null);
            }
            //MessageBox.Show(newSavingType.Name + "\n" +
            //    newSavingType.Period.ToString() + "\n" +
            //    newSavingType.InterestRate.ToString() + "\n" +
            //    newSavingType.MinNumOfDateToWithdraw.ToString() + "\n" +
            //    newSavingType.WithdrawalRule + "\n" +
            //    newSavingType.EffectiveDate.ToShortDateString());
        }
    }
}

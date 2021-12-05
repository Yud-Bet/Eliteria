using System;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    public class AddNewSavingTypeCommand : BaseCommandAsync
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
        public override async Task ExecuteAsync(object parameter)
        {

            if (IsFilledOut(newSavingType.Name, newSavingType.Period, newSavingType.InterestRate, newSavingType.MinNumOfDateToWithdraw, newSavingType.EffectiveDate, newSavingType.WithdrawalRule, blankNameCB, blankPeriodCB, blankInterestRateCB, blankMinDays2WidthdrawCB, blankEffectiveDateCB, blankWidthdrawRulesCB)) return;
            int rowsEffect = await DataAccess.ExecuteQuery.ExecuteNoneQueryAsync("Eliteria_AddNewSavingType @Name , @Period , @InterestRate , @EffectiveDate , @MinNumOfDateToWithdraw , @WithdrawalRule",
                                                        new object[] { newSavingType.Name, newSavingType.Period, newSavingType.InterestRate, newSavingType.EffectiveDate,
                                                        newSavingType.MinNumOfDateToWithdraw, newSavingType.WithdrawalRule}).ContinueWith(OnQueryFinished);

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

        private void blankWidthdrawRulesCB()
        {
            addNewSavingViewModel.ErrorStatus = "Vui lòng chọn quy định rút";
            addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
        }

        private void blankEffectiveDateCB()
        {
            addNewSavingViewModel.ErrorStatus = "Vui lòng nhập ngày áp dụng";
            addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
        }

        private void blankMinDays2WidthdrawCB()
        {
            addNewSavingViewModel.ErrorStatus = "Vui lòng nhập số ngày gửi tối thiểu";
            addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
        }

        private void blankInterestRateCB()
        {
            addNewSavingViewModel.ErrorStatus = "Vui lòng nhập lãi suất";
            addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
        }

        private void blankPeriodCB()
        {
            addNewSavingViewModel.ErrorStatus = "Vui lòng nhập kỳ hạn";
            addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
        }

        private void blankNameCB()
        {
            addNewSavingViewModel.ErrorStatus = "Vui lòng nhập tên của loại tiết kiệm";
            addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
        }

        private int OnQueryFinished(Task<int> arg)
        {
            if (arg.IsFaulted)
            {
                //addNewSavingViewModel.ErrorStatus = "Đã xảy ra lỗi khi thực thi hành động này, xin vui lòng kiểm tra kết nối";
                return -1;
            }
            return arg.Result;
        }

        public static bool IsFilledOut(string name, int period, float interestRate, int minDays2Widthdraw, DateTime effectiveDate, string widthdrawRules, Action blankNameCB = null, Action blankPeriodCB = null, Action blankInterestRateCB = null, Action blankMinDays2WidthdrawCB = null, Action blankEffectiveDateCB = null, Action blankWidthdrawRulesCB = null)
        {
            if (name == null || name == "")
            {
                blankNameCB?.Invoke();
                return false;
            }
            else if (period == 0)
            {
                blankPeriodCB?.Invoke();
                return false;
            }
            else if (interestRate == 0)
            {
                blankInterestRateCB?.Invoke();
                return false;
            }
            else if (minDays2Widthdraw == 0)
            {
                blankMinDays2WidthdrawCB?.Invoke();
                return false;
            }
            else if (effectiveDate == null)
            {
                blankEffectiveDateCB?.Invoke();
                return false;
            }
            else if (widthdrawRules == null)
            {
                blankWidthdrawRulesCB?.Invoke();
                return false;
            }
            return true;
        }
    }
}

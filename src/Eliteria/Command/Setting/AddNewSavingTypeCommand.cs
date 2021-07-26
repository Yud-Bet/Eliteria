using Eliteria.DataAccess.Models;
using Eliteria.DataAccess.Modules.SettingModule;
using Eliteria.DataAccess.Modules.SettingModules;
using System;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class AddNewSavingTypeCommand : BaseCommandAsync
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

            var itemSavingType = new SavingType
            {
                Name = newSavingType.Name,
                Period = newSavingType.Period,
                InterestRate = newSavingType.InterestRate,
                EffectiveDate = newSavingType.EffectiveDate,
                MinNumOfDateToWithdraw = newSavingType.MinNumOfDateToWithdraw,
                WithdrawalRule = newSavingType.WithdrawalRule,

            };

            int rowsEffect = await SavingTypesM.AddNewSavingType(itemSavingType).ContinueWith(OnQueryFinished);

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

        private int OnQueryFinished(Task<int> arg)
        {
            if (arg.IsFaulted)
            {
                //addNewSavingViewModel.ErrorStatus = "Đã xảy ra lỗi khi thực thi hành động này, xin vui lòng kiểm tra kết nối";
                return -1;
            }
            return arg.Result;
        }
    }
}

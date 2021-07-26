using Eliteria.DataAccess.Modules.SettingModule;
using System;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Eliteria.Command
{
    class ModifyStaffInfoCMD : BaseCommandAsync
    {
        private ViewModels.StaffsViewModel staffsViewModel;
        private ViewModels.ModifyStaffInforViewModel modifyStaffViewModel;
        private Stores.AccountStore account;

        public ModifyStaffInfoCMD(ViewModels.StaffsViewModel staffsViewModel, ViewModels.ModifyStaffInforViewModel modifyStaffViewModel, Stores.AccountStore account)
        {
            this.staffsViewModel = staffsViewModel;
            this.modifyStaffViewModel = modifyStaffViewModel;
            this.account = account;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (Validation())
            {
                int res = await DataAccess.DAStaffList.ModifyStaffInfo(modifyStaffViewModel.StaffID, modifyStaffViewModel.SelectedPosition, modifyStaffViewModel.Name, modifyStaffViewModel.PhoneNumber, modifyStaffViewModel.Email, modifyStaffViewModel.Address)
                    .ContinueWith(OnQueryFinished);
                if (res > 0)
                {
                    staffsViewModel.StaffList = new System.Collections.ObjectModel.ObservableCollection<DTA.Account>(EmployeesM.GetAllEmpoyees());

                    account.CurrentAccount.Position = modifyStaffViewModel.SelectedPosition;
                    account.CurrentAccount.StaffName = modifyStaffViewModel.Name;
                    account.CurrentAccount.PhoneNum = modifyStaffViewModel.PhoneNumber;
                    account.CurrentAccount.Email = modifyStaffViewModel.Email;
                    account.CurrentAccount.Address = modifyStaffViewModel.Address;

                    modifyStaffViewModel.StatusMessage = "Sửa thông tin thành công";
                    modifyStaffViewModel.StatusColor = Brushes.Green;
                }
            }
        }

        private int OnQueryFinished(Task<int> arg)
        {
            if (arg.IsFaulted)
            {
                modifyStaffViewModel.StatusMessage = "Đã xảy ra lỗi khi thực thi hành động này. Xin vui lòng kiểm tra lại kết nối";
                modifyStaffViewModel.StatusColor = Brushes.Red;
                return -1;
            }
            return arg.Result;
        }

        private bool Validation()
        {
            if (string.IsNullOrEmpty(modifyStaffViewModel.Name))
            {
                modifyStaffViewModel.StatusMessage = "Vui lòng nhập tên";
                modifyStaffViewModel.StatusColor = Brushes.Red;
                return false;
            }
            if (string.IsNullOrEmpty(modifyStaffViewModel.PhoneNumber))
            {
                modifyStaffViewModel.StatusMessage = "Vui lòng nhập số điện thoại";
                modifyStaffViewModel.StatusColor = Brushes.Red;
                return false;
            }
            if (string.IsNullOrEmpty(modifyStaffViewModel.Address))
            {
                modifyStaffViewModel.StatusMessage = "Vui lòng nhập địa chỉ";
                modifyStaffViewModel.StatusColor = Brushes.Red;
                return false;
            }
            return true;
        }
    }
}

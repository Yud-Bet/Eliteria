using System;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Eliteria.Command
{
    public class ModifyStaffInfoCMD : BaseCommandAsync
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
            if (Validation(modifyStaffViewModel.Name, modifyStaffViewModel.PhoneNumber, modifyStaffViewModel.Address, BlankNameCallBack, BlankPhoneNumCallBack, BlankAddrCallBack))
            {
                int res = await DataAccess.DAStaffList.ModifyStaffInfo(modifyStaffViewModel.StaffID, modifyStaffViewModel.SelectedPosition, modifyStaffViewModel.Name, modifyStaffViewModel.PhoneNumber, modifyStaffViewModel.Email, modifyStaffViewModel.Address)
                    .ContinueWith(OnQueryFinished);
                if (res > 0)
                {
                    staffsViewModel.StaffList = await DataAccess.DAStaffList.Load();

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

        private void BlankAddrCallBack()
        {
            modifyStaffViewModel.StatusMessage = "Vui lòng nhập địa chỉ";
            modifyStaffViewModel.StatusColor = Brushes.Red;
        }

        private void BlankPhoneNumCallBack()
        {
            modifyStaffViewModel.StatusMessage = "Vui lòng nhập số điện thoại";
            modifyStaffViewModel.StatusColor = Brushes.Red;
        }

        private void BlankNameCallBack()
        {
            modifyStaffViewModel.StatusMessage = "Vui lòng nhập tên";
            modifyStaffViewModel.StatusColor = Brushes.Red;
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

        public static bool Validation(string name, string phoneNum, string addr, Action BlankNameCallBack = null, Action BlankPhoneNumCallBack = null, Action BlankAddrCallBack = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                BlankNameCallBack?.Invoke();
                return false;
            }
            if (string.IsNullOrEmpty(phoneNum))
            {
                BlankPhoneNumCallBack?.Invoke();
                return false;
            }
            if (string.IsNullOrEmpty(addr))
            {
                BlankAddrCallBack?.Invoke();
                return false;
            }
            return true;
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Eliteria.Command
{
    public class CreateNewStaffCMD : BaseCommandAsync
    {
        ViewModels.AddStaffViewModel viewModel;
        ViewModels.StaffsViewModel staffsViewModel;

        public CreateNewStaffCMD(ViewModels.AddStaffViewModel viewModel, ViewModels.StaffsViewModel staffsViewModel)
        {
            this.viewModel = viewModel;
            this.staffsViewModel = staffsViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (Validation(viewModel.Name, viewModel.IdentificationNumber, viewModel.Password, viewModel.PhoneNumber, viewModel.Address, BlankNameCallBack, BlankIdCallBack, BlankPassCallBack, BlankPhoneCallBack, BlankAddrCallBack))
            {
                if (viewModel.Email == null) viewModel.Email = "";
                int res = await DataAccess.DAStaffList.CreateNewStaff(viewModel.SelectedPosition, viewModel.Name, viewModel.IdentificationNumber, viewModel.SelectedGender, viewModel.Birthday, viewModel.PhoneNumber, viewModel.Address, viewModel.Password, viewModel.Email).ContinueWith(OnQueryFinished);
                if (res > 0)
                {
                    staffsViewModel.StaffList = await DataAccess.DAStaffList.Load();

                    viewModel.StatusMessage = "Thêm nhân viên thành công";
                    viewModel.StatusColor = Brushes.Green;
                }
                else
                {
                    viewModel.StatusMessage = "Đã xảy ra lỗi khi thực thi hành động này. Xin vui lòng kiểm tra lại kết nối";
                    viewModel.StatusColor = Brushes.Red;
                }
            }
        }

        private void BlankAddrCallBack()
        {
            viewModel.StatusMessage = "Vui lòng nhập địa chỉ";
            viewModel.StatusColor = Brushes.Red;
        }

        private void BlankPhoneCallBack()
        {
            viewModel.StatusMessage = "Vui lòng nhập số điện thoại";
            viewModel.StatusColor = Brushes.Red;
        }

        private void BlankPassCallBack()
        {
            viewModel.StatusMessage = "Vui lòng nhập mật khẩu để có thể đăng nhập vào phần mềm này";
            viewModel.StatusColor = Brushes.Red;
        }

        private void BlankIdCallBack()
        {
            viewModel.StatusMessage = "Vui lòng nhập căn cước công dân";
            viewModel.StatusColor = Brushes.Red;
        }

        private void BlankNameCallBack()
        {
            viewModel.StatusMessage = "Vui lòng nhập tên";
            viewModel.StatusColor = Brushes.Red;
        }

        private int OnQueryFinished(Task<int> arg)
        {
            if (arg.IsFaulted)
            {
                return -1;
            }
            return arg.Result;
        }

        public static bool Validation(string name, string iden, string pass, string phone, string addr, Action blankNameCallBack = null, Action blankIdCallBack = null, Action blankPassCallBack = null, Action blankPhoneCallBack = null, Action blankAddrCallBack = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                blankNameCallBack?.Invoke();
                return false;
            }
            if (string.IsNullOrEmpty(iden))
            {
                blankIdCallBack?.Invoke();
                return false;
            }
            if (string.IsNullOrEmpty(pass))
            {
                blankPassCallBack?.Invoke();
                return false;
            }
            if (string.IsNullOrEmpty(phone))
            {
                blankPhoneCallBack?.Invoke();
                return false;
            }
            if (string.IsNullOrEmpty(addr))
            {
                blankAddrCallBack?.Invoke();
                return false;
            }
            return true;
        }
    }
}

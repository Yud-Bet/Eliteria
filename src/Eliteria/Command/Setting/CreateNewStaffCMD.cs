using System.Threading.Tasks;
using System.Windows.Media;

namespace Eliteria.Command
{
    class CreateNewStaffCMD : BaseCommandAsync
    {
        ViewModels.AddStaffViewModel viewModel;

        public CreateNewStaffCMD(ViewModels.AddStaffViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (Validation())
            {
                int res = await DataAccess.DAStaffList.CreateNewStaff(viewModel.SelectedPosition, viewModel.Name, viewModel.IdentificationNumber, viewModel.SelectedGender, viewModel.Birthday, viewModel.PhoneNumber, viewModel.Address, viewModel.Password, viewModel.Email);
                if (res > 0)
                {
                    viewModel.StatusMessage = "Thêm nhân viên thành công";
                    viewModel.StatusColor = Brushes.Green;
                }
                else
                {
                    viewModel.StatusMessage = "Thêm nhân viên thất bại";
                    viewModel.StatusColor = Brushes.Green;
                }
            }
        }

        private bool Validation()
        {
            if (string.IsNullOrEmpty(viewModel.Name))
            {
                viewModel.StatusMessage = "Vui lòng nhập tên";
                viewModel.StatusColor = Brushes.Red;
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.IdentificationNumber))
            {
                viewModel.StatusMessage = "Vui lòng nhập căn cước công dân";
                viewModel.StatusColor = Brushes.Red;
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.Password))
            {
                viewModel.StatusMessage = "Vui lòng nhập mật khẩu để có thể đăng nhập vào phần mềm này";
                viewModel.StatusColor = Brushes.Red;
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.PhoneNumber))
            {
                viewModel.StatusMessage = "Vui lòng nhập số điện thoại";
                viewModel.StatusColor = Brushes.Red;
                return false;
            }
            if (string.IsNullOrEmpty(viewModel.Address))
            {
                viewModel.StatusMessage = "Vui lòng nhập địa chỉ";
                viewModel.StatusColor = Brushes.Red;
                return false;
            }
            return true;
        }
    }
}

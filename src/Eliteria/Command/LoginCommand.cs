using Eliteria.DataAccess.Models;
using System.Threading.Tasks;
namespace Eliteria.Command
{
    class LoginCommand : BaseCommandAsync
    {
        private readonly ViewModels.LoginViewModel loginViewModel;
        private readonly Services.NavigationService<ViewModels.HomeViewModel> navigationService;
        private readonly Stores.AccountStore accountStore;

        public LoginCommand(ViewModels.LoginViewModel loginViewModel, Stores.AccountStore accountStore, Services.NavigationService<ViewModels.HomeViewModel> navigationService)
        {
            this.loginViewModel = loginViewModel;
            this.navigationService = navigationService;
            this.accountStore = accountStore;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            if (loginViewModel.Username == null || loginViewModel.Username == "")
            {
                loginViewModel.LoginError = "Vui lòng nhập mã nhân viên";
                return;
            }
            if (loginViewModel.Password == null || loginViewModel.Password == "")
            {
                loginViewModel.LoginError = "Vui lòng nhập password";
                return;
            }

            Account account = await DataAccess.Modules.LoginModule.Login(loginViewModel.Username, loginViewModel.Password).ContinueWith(OnTaskCompleted);

            if (account != null)
            {
                accountStore.CurrentAccount = account;
                navigationService.Navigate();
            }
        }

        private Account OnTaskCompleted(Task<Account> arg)
        {
            if (arg.Exception != null)
            {
                loginViewModel.LoginError = "Đã xảy ra lỗi khi cố gắng đăng nhập, xin vui lòng kiểm tra lại kết nối";
                return null;
            }
            else if (arg.Result == null)
            {
                loginViewModel.LoginError = "Sai mật khẩu hoặc mã nhân viên không tồn tại";
                return null;
            }
            else return arg.Result;
        }
    }
}

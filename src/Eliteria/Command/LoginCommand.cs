using System;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    public class LoginCommand : BaseCommandAsync
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
            if (IsFilledOut(loginViewModel.Username, loginViewModel.Password, blankUsernameCallBack, blankPassCallBack))
            {
                Models.Account account = await DataAccess.DALogin.Execute(loginViewModel.Username, loginViewModel.Password).ContinueWith(OnTaskCompleted);

                if (account != null)
                {
                    accountStore.CurrentAccount = account;
                    navigationService.Navigate();
                }
            }
        }

        private void blankPassCallBack()
        {
            loginViewModel.LoginError = "Vui lòng nhập password";
        }

        private void blankUsernameCallBack()
        {
            loginViewModel.LoginError = "Vui lòng nhập mã nhân viên";
        }

        private Models.Account OnTaskCompleted(Task<Models.Account> arg)
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

        public static bool IsFilledOut(string username, string password, Action blankUsernameCallBack = null, Action blankPassCallBack = null)
        {
            if (username == null || username == "")
            {
                blankUsernameCallBack?.Invoke();
                return false;
            }
            if (password == null || password == "")
            {
                blankPassCallBack?.Invoke();
                return false;
            }
            return true;
        }
    }
}

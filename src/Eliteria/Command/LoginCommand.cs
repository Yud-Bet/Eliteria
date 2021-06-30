using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            DataTable data = await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_Login @username , @password", new object[] { loginViewModel.Username, loginViewModel.Password });

            if (data.Rows.Count != 1)
            {
                loginViewModel.LoginError = "Sai mật khẩu hoặc mã nhân viên không tồn tại";
                return;
            }
                
            Models.Account account = new Models.Account()
            {
                StaffID = (int)data.Rows[0][0],
                Email = data.Rows[0][6].ToString(),
                Password = data.Rows[0][2].ToString(),
                StaffName = data.Rows[0][3].ToString(),
                PhoneNum = data.Rows[0][5].ToString(),
                ID = data.Rows[0][4].ToString(),
                Address = data.Rows[0][7].ToString(),
                Sex = (bool)data.Rows[0][8],
                Position = (int)data.Rows[0][1],
                Birthdate = (DateTime)data.Rows[0][9]
            };
            accountStore.CurrentAccount = account;
            navigationService.Navigate();
        }
    }
}

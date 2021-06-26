﻿using System;
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
            if (loginViewModel.Username == null) loginViewModel.Username = "";
            if (loginViewModel.Password == null) loginViewModel.Password = "";
            //DataTable data = DataAccess.ExecuteQuery.ExecuteReader("Eliteria_Login @username , @password", new object[] { loginViewModel.Username, loginViewModel.Password });

            //if (data.Rows.Count != 1) return;

            Models.Account account = new Models.Account()
            {
                Username = data.Rows[0][6].ToString(),
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
            //MessageBox.Show(accountStore.CurrentAccount.Birthdate.ToString());
            navigationService.Navigate();
        }
    }
}

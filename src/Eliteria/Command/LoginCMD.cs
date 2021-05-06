using System.Windows;

namespace Eliteria.Command
{
    class LoginCMD : BaseCommand
    {
        private readonly ViewModels.LoginViewModel loginViewModel;
        private readonly Services.NavigationService<ViewModels.SecondViewModel> navigationService;
        private readonly Stores.AccountStore accountStore;

        public LoginCMD(ViewModels.LoginViewModel loginViewModel, Stores.AccountStore accountStore, Services.NavigationService<ViewModels.SecondViewModel> navigationService)
        {
            this.loginViewModel = loginViewModel;
            this.navigationService = navigationService;
            this.accountStore = accountStore;
        }

        public override void Execute(object parameter)
        {
            Models.Account account = new Models.Account()
            {
                Username = loginViewModel.Username,
                Password = loginViewModel.Password
            };
            accountStore.CurrentAccount = account;
            navigationService.Navigate();
        }
    }
}

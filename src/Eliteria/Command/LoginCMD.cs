using System.Windows;

namespace Eliteria.Command
{
    class LoginCMD : BaseCommand
    {
        private readonly ViewModels.LoginViewModel loginViewModel;
        private readonly Services.NavigationService<ViewModels.SecondViewModel> navigationService;

        public LoginCMD(ViewModels.LoginViewModel loginViewModel, Services.NavigationService<ViewModels.SecondViewModel> navigationService)
        {
            this.loginViewModel = loginViewModel;
            this.navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            MessageBox.Show(loginViewModel.Username);
            navigationService.Navigate();
        }
    }
}

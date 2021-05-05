using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCMD { get; }
        public LoginViewModel(Stores.NavigationStore navigationStore)
        {
            LoginCMD = new Command.LoginCMD(this, new Services.NavigationService<SecondViewModel>(
                navigationStore, ()=> new SecondViewModel(navigationStore)));
        }
    }
}

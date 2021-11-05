using System.Windows.Input;

namespace Eliteria.ViewModels
{
    public class LoginViewModel : BaseViewModel 
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand ButtonLoginCMD { get; }

        private Stores.NavigationStore mainNavigationStore;
        private Stores.NavigationStore navigationStore;
        private Stores.AccountStore accountStore;

        public LoginViewModel(Stores.NavigationStore mainNavigationStore, Stores.NavigationStore navigationStore, Stores.AccountStore accountStore)
        {
            this.mainNavigationStore = mainNavigationStore;
            this.navigationStore = navigationStore;
            this.accountStore = accountStore;
         
            ButtonLoginCMD = new Command.LoginCommand(this, accountStore, CreateHomeNavSvc());
        }
        private string _loginError;
        public string LoginError
        {
            get => _loginError;
            set
            {
                _loginError = value;
                OnPropertyChanged(nameof(LoginError));
            }
        }
        private Services.NavigationService<HomeViewModel> CreateHomeNavSvc()
        {
            return new Services.NavigationService<HomeViewModel>(mainNavigationStore, () => new HomeViewModel(mainNavigationStore, navigationStore, accountStore));
        }
    }
}

using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class LoginViewModel : BaseViewModel 
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

            Username = "1";
            Password = "1";
            ButtonLoginCMD = new Command.LoginCommand(this, accountStore, CreateHomeNavSvc());
        }

        private Services.NavigationService<HomeViewModel> CreateHomeNavSvc()
        {
            return new Services.NavigationService<HomeViewModel>(mainNavigationStore, () => new HomeViewModel(mainNavigationStore, navigationStore, accountStore));
        }
    }
}

using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private Stores.NavigationStore mainNavigationStore;
        private Stores.NavigationStore navigationStore;
        private Stores.AccountStore accountStore;
        public ICommand navigateHomeViewCMD { get; }

        public LoginViewModel(Stores.NavigationStore mainNavigationStore, Stores.NavigationStore navigationStore, Stores.AccountStore accountStore)
        {
            this.mainNavigationStore = mainNavigationStore;
            this.navigationStore = navigationStore;
            this.accountStore = accountStore;
            navigateHomeViewCMD = new Command.NavigateCMD(CreateHomeViewNavigationService());
        }

        private Services.INavigationService CreateHomeViewNavigationService()
        {
            return new Services.NavigationService<HomeViewModel>(mainNavigationStore, () => new HomeViewModel(navigationStore, accountStore));
        }
    }
}

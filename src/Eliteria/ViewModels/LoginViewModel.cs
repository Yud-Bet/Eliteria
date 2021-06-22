using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public ICommand navigateHomeViewCMD { get; }

        public LoginViewModel(Stores.NavigationStore mainNavigationStore, Stores.NavigationStore navigationStore, Stores.AccountStore accountStore)
        {
            this.mainNavigationStore = mainNavigationStore;
            this.navigationStore = navigationStore;
            this.accountStore = accountStore;
            navigateHomeViewCMD = new Command.NavigateCMD(CreateHomeViewNavigationService());

            //Hiếu
            Username = "1";
            Password = "1";
            ButtonLoginCMD = new Command.LoginCommand(this, accountStore, new Services.NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(accountStore, navigationStore)));
            //ButtonLoginCMD.Execute(null);
        }


    }
}

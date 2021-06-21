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

        public LoginViewModel(Stores.NavigationStore navigationStore, Stores.AccountStore accountStore)
        {
            Username = "1";
            Password = "1";
            ButtonLoginCMD = new Command.LoginCommand(this, accountStore, new Services.NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(accountStore, navigationStore)));
            //ButtonLoginCMD.Execute(null);
        }
    }
}

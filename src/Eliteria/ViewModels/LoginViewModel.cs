using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        public ICommand navigateHomeViewCMD { get; }

        public LoginViewModel(Stores.NavigationStore navigationStore, Stores.AccountStore accountStore)
        {
            navigateHomeViewCMD = new Command.NavigateCMD<HomeViewModel>(
                         new Services.NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(accountStore)));
        }
    }
}

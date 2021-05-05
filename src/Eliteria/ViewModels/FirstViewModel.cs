using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class FirstViewModel: BaseViewModel
    {
        public ICommand NavigateLoginViewCMD { get; }

        public FirstViewModel(Stores.NavigationStore navigationStore)
        {
            NavigateLoginViewCMD = new Command.NavigateCMD<LoginViewModel>(
                new Services.NavigationService<LoginViewModel>(navigationStore, ()=> new LoginViewModel(navigationStore)));
        }
    }
}

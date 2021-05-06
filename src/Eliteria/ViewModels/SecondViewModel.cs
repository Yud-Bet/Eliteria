using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class SecondViewModel: BaseViewModel
    {
        private readonly Stores.AccountStore accountStore;
        public ICommand NavigateFirstViewCMD { get; }
        public string Username => accountStore.CurrentAccount?.Username;
        public string Password => accountStore.CurrentAccount?.Password;

        public SecondViewModel(Stores.AccountStore accountStore, Stores.NavigationStore navigationStore)
        {
            this.accountStore = accountStore;
            NavigateFirstViewCMD = new Command.NavigateCMD<FirstViewModel>(
                new Services.NavigationService<FirstViewModel>(navigationStore, ()=> new FirstViewModel(accountStore, navigationStore)));
        }
    }
}

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
        private string username;
        private string password;

        public ICommand NavigateFirstViewCMD { get; }
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertychanged(nameof(Username));
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertychanged(nameof(Password));
            }
        }

        public SecondViewModel(Stores.NavigationStore navigationStore)
        {
            NavigateFirstViewCMD = new Command.NavigateCMD<FirstViewModel>(
                new Services.NavigationService<FirstViewModel>(navigationStore, ()=> new FirstViewModel(navigationStore)));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            navigateHomeViewCMD = new Command.NavigateCMD<HomeViewModel>(
                new Services.NavigationService<HomeViewModel>(navigationStore, () => new HomeViewModel(accountStore)));
            currentViewModel = new HomeViewModel(accountStore);
        }

        private Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        /// <summary>
        /// This store staff account information
        /// </summary>
        private Stores.AccountStore accountStore;
        public BaseViewModel _currentViewModel;
        public BaseViewModel currentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertychanged(nameof(currentViewModel));
                }
            }
        }

        public ICommand navigateHomeViewCMD;
    }
}

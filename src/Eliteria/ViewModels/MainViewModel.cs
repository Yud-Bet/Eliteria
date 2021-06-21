using Eliteria.Models;
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
            //navigationStore.CurrentViewModel = new LoginViewModel(navigationStore, accountStore);
            //navigationStore.CurrentViewModel = new HomeViewModel(accountStore);
            navigationStore.CurrentViewModel = new TransactionViewModel();
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        
       

        private Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        /// <summary>
        /// This store staff account information
        /// </summary>
        Stores.AccountStore accountStore = new Stores.AccountStore();
        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;
        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }
    }
}

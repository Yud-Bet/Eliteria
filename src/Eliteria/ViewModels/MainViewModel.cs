using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        Stores.AccountStore accountStore = new Stores.AccountStore();
        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;

        public MainViewModel()
        {
            this.navigationStore.CurrentViewModel = new FirstViewModel(accountStore, navigationStore);
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }
    }
}

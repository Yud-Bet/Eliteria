using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private readonly Stores.NavigationStore navigationStore;
        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;

        public MainViewModel(Stores.NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModel = new FirstViewModel(navigationStore);
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }
    }
}

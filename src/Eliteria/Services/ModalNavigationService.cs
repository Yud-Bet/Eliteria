using Eliteria.Stores;
using System;

namespace Eliteria.Services
{
    class ModalNavigationService<TViewModel>: INavigationService
        where TViewModel: ViewModels.BaseViewModel
    {
        private readonly Stores.NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public ModalNavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentModal = _createViewModel();
        }
    }
}

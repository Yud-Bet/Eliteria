﻿using System;

namespace Eliteria.Services
{
    class NavigationService<T>
        where T: ViewModels.BaseViewModel
    {
        private readonly Stores.NavigationStore navigationStore;
        private readonly Func<T> createViewModel;

        public NavigationService(Stores.NavigationStore navigationStore, Func<T> createViewModel)
        {
            this.navigationStore = navigationStore;
            this.createViewModel = createViewModel;
        }

        public void Navigate()
        {
            navigationStore.CurrentViewModel = createViewModel();
        }
    }
}

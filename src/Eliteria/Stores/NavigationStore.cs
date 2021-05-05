using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Stores
{
    class NavigationStore
    {
        public event Action CurrentViewModelChanged;
        private ViewModels.BaseViewModel _CurrentViewModel;
        public ViewModels.BaseViewModel CurrentViewModel
        {
            get => _CurrentViewModel;
            set
            {
                _CurrentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}

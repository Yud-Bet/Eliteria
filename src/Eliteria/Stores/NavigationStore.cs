using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Stores
{
    public class NavigationStore
    {
        public event Action CurrentViewModelChanged;
        public event Action CurrentModalChanged;

        private ViewModels.BaseViewModel _CurrentViewModel;
        private ViewModels.BaseViewModel _CurrentModal;
        public ViewModels.BaseViewModel CurrentModal
        {
            get => _CurrentModal;
            set
            {
                _CurrentModal = value;
                OnCurrentModalChanged();
            }
        }
        public bool IsOpen => CurrentModal != null;
        public ViewModels.BaseViewModel CurrentViewModel
        {
            get => _CurrentViewModel;
            set
            {
                _CurrentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public void Close()
        {
            CurrentModal = null;
        }
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        private void OnCurrentModalChanged()
        {
            CurrentModalChanged?.Invoke();
        }
    }
}

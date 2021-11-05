using System.Collections.Generic;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    public class OtherParameterViewModel : BaseViewModel
    {
        public Stores.NavigationStore _homeNavigationStore;
        public ICommand OnLoadCMD { get; set; }
        public ICommand EditParameterCMD { get; set; }
        public OtherParameterViewModel(Stores.NavigationStore homeNavigationStore)
        {
            _homeNavigationStore = homeNavigationStore;
            OnLoadCMD = new Command.OtherParametersOnLoadCMD(this);
            EditParameterCMD = new Command.EditOtherParametersCMD(this, _homeNavigationStore);
        }

        private Models.OtherParameter otherParameter;
        private bool _isLoading = false;
        private bool _isLoadingError = false;
        List<bool> _boolList = new List<bool> { true, false };

        public List<bool> BoolList
        {
            get => _boolList;
            set
            {
                _boolList = value;
                OnPropertyChanged(nameof(BoolList));
            }
        }
        public Models.OtherParameter OtherParameter
        {
            get { return otherParameter; }
            set 
            { 
                otherParameter = value;
                OnPropertyChanged(nameof(OtherParameter));
            }
        }
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertychanged(nameof(IsLoading));
            }
        }
        public bool IsLoadingError
        {
            get => _isLoadingError;
            set
            {
                _isLoadingError = value;
                OnPropertychanged(nameof(IsLoadingError));
            }
        }
    }
}

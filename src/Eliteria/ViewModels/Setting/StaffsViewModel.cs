using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class StaffsViewModel: BaseViewModel
    {
        public StaffsViewModel(Stores.NavigationStore _homeNavStore)
        {
            this._homeNavStore = _homeNavStore;

            OnLoadCommand = new Command.StaffsOnLoadCMD(this);
            OnDoubleClickItemCommand = new Command.OnDoubleClickOnStaffCMD(this, this._homeNavStore);
        }

        private Stores.NavigationStore _homeNavStore;
        private ObservableCollection<Models.Account> _staffList;
        private bool _isLoading = false;
        private bool _isLoadingError = false;

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
        public ObservableCollection<Models.Account> StaffList
        {
            get => _staffList;
            set
            {
                _staffList = value;
                OnPropertychanged(nameof(StaffList));
            }
        }
        public ICommand OnLoadCommand { get; } 
        public ICommand OnDoubleClickItemCommand { get; }
    }
}

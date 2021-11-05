using Eliteria.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    public class StaffsViewModel: BaseViewModel
    {
        public Action OnSelectedItemChange;
        public StaffsViewModel(Stores.NavigationStore _homeNavStore, Stores.AccountStore account)
        {
            this._homeNavStore = _homeNavStore;
            this.account = account;

            OnLoadCommand = new Command.StaffsOnLoadCMD(this);
            OnDoubleClickItemCommand = new Command.OnDoubleClickOnStaffCMD(this, this._homeNavStore);
            AddButtonCommand = new Command.NavigateCMD(CreateAddStaffNavigationService());
            ModifyButtonCommand = new Command.OpenModifyStaffInfoViewCMD(this, _homeNavStore, this.account);
            RemoveCommand = new Command.RemoveStaffCommand(this, _homeNavStore, account);
        }

        private Stores.NavigationStore _homeNavStore;
        private ObservableCollection<Models.Account> _staffList;
        private bool _isLoading = false;
        private bool _isLoadingError = false;
        private int _selectedStaffIndex = -1;

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
        public int SelectedStaffIndex
        {
            get => _selectedStaffIndex;
            set
            {
                _selectedStaffIndex = value;
                OnPropertychanged(nameof(SelectedStaffIndex));
                OnSelectedItemChange();
            }
        }


        public ICommand OnLoadCommand { get; } 
        public ICommand OnDoubleClickItemCommand { get; }
        public ICommand AddButtonCommand { get; }
        public ICommand ModifyButtonCommand { get; }
        public ICommand RemoveCommand { get; }

        public Stores.AccountStore account;

        private INavigationService CreateAddStaffNavigationService()
        {
            return new ModalNavigationService<AddStaffViewModel>(_homeNavStore, () => new AddStaffViewModel(_homeNavStore, this));
        }
    }
}

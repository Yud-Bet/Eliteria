using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace Eliteria.ViewModels
{
    class ModifyStaffInforViewModel : BaseViewModel
    {
        private StaffsViewModel _staffsViewModel;
        private Stores.NavigationStore _homeNavStore;
        private List<string> _positions = new List<string> { "Quản lý", "Nhân viên" };
        private string _name;
        private string _phoneNumber;
        private string _address;
        private int _selectedPosition = 1;
        private string _statusMessage;
        private Brush _statusColor = Brushes.Red;
        private string _email;

        public ModifyStaffInforViewModel(Stores.NavigationStore _homeNavStore, StaffsViewModel _staffsViewModel)
        {
            this._homeNavStore = _homeNavStore;
            this._staffsViewModel = _staffsViewModel;
            CloseCMD = new Command.NavigateCMD(new Services.CloseModalNavSvc(this._homeNavStore));
            ConfirmCommand = new Command.ModifyStaffInfoCMD(_staffsViewModel, this);

            int index = this._staffsViewModel.SelectedSavingsIndex;
            SelectedPosition = this._staffsViewModel.StaffList[index].Position;
            Name = this._staffsViewModel.StaffList[index].StaffName;
            PhoneNumber = this._staffsViewModel.StaffList[index].PhoneNum;
            Address = this._staffsViewModel.StaffList[index].Address;
        }

        public ICommand CloseCMD { get; }
        public ICommand ConfirmCommand { get; }


        public Brush StatusColor
        {
            get => _statusColor;
            set
            {
                _statusColor = value;
                OnPropertychanged(nameof(StatusColor));
            }
        }
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertychanged(nameof(StatusMessage));
            }
        }
        public int SelectedPosition
        {
            get => _selectedPosition;
            set
            {
                _selectedPosition = value;
                OnPropertychanged(nameof(SelectedPosition));
            }
        }

        public List<string> Positions
        {
            get => _positions;
            set
            {
                _positions = value;
                OnPropertychanged(nameof(Positions));
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertychanged(nameof(Name));
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertychanged(nameof(PhoneNumber));
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertychanged(nameof(Email));
            }
        }
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertychanged(nameof(Address));
            }
        }
    }
}

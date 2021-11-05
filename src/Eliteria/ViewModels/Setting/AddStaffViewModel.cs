using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace Eliteria.ViewModels
{
    public class AddStaffViewModel: BaseViewModel
    {
        private Stores.NavigationStore _homeNavStore;
        private StaffsViewModel _staffsViewModel;
        private List<string> _positions = new List<string> { "Quản lý", "Nhân viên"};
        private string _name;
        private string _identificationNumber;
        private List<string> _gender = new List<string>{ "Nam", "Nữ"};
        private DateTime _birthday = new DateTime(2001, 1, 1);
        private string _phoneNumber;
        private string _address;
        private int _selectedPosition = 1;
        private bool _selectedGender = true;
        private string _statusMessage;
        private Brush _statusColor = Brushes.Red;
        private string _password;
        private string _email;

        public AddStaffViewModel(Stores.NavigationStore _homeNavStore, StaffsViewModel _staffsViewModel)
        {
            this._homeNavStore = _homeNavStore;
            this._staffsViewModel = _staffsViewModel;
            CloseCMD = new Command.NavigateCMD(new Services.CloseModalNavSvc(this._homeNavStore));
            CreateStaffCMD = new Command.CreateNewStaffCMD(this, this._staffsViewModel);
        }

        public ICommand CloseCMD { get; }
        public ICommand CreateStaffCMD { get; }


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
        public bool SelectedGender
        {
            get => _selectedGender;
            set
            {
                _selectedGender = value;
                OnPropertychanged(nameof(SelectedGender));
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
        public string IdentificationNumber
        {
            get => _identificationNumber;
            set
            {
                _identificationNumber = value;
                OnPropertychanged(nameof(IdentificationNumber));
            }
        }
        public List<string> Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertychanged(nameof(Gender));
            }
        }
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertychanged(nameof(Birthday));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertychanged(nameof(Password));
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

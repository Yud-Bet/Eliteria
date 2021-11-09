using Eliteria.Models;
using Eliteria.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    public class AddNewSavingViewModel : BaseViewModel
    {
        private SavingsAccountListViewModel _savingsAccountListViewModel;
        private Stores.NavigationStore _navigationStore;
        
        private bool _isNewCustomer;
        public bool IsNewCustomer
        {
            get => _isNewCustomer;
            set
            {
                _isNewCustomer = value;
                OnPropertyChanged(nameof(IsNewCustomer));
            }
        }
        private List<string> _savingsTypeList = new List<string>();
        public List<string> SavingsTypeList
        {
            get => _savingsTypeList;
            set
            {
                _savingsTypeList = value;
                OnPropertyChanged(nameof(SavingsTypeList));
            }
        }

        private string _selectedSavingsType;
        public string SelectedSavingType
        {
            get => _selectedSavingsType;
            set
            {
                _selectedSavingsType = value;
                OnPropertychanged(nameof(SelectedSavingType));
            }
        }
        private string _ownerName;
        public string OwnerName
        {
            get => _ownerName;
            set
            {
                _ownerName = value;
                OnPropertychanged(nameof(OwnerName));
            }
        }

        private string _ownerId;
        public string OwnerID
        {
            get => _ownerId;
            set
            {
                _ownerId = value;
                OnPropertychanged(nameof(OwnerID));
            }
        }        

        private string _owerAddress;
        public string OwnerAddress
        {
            get => _owerAddress;
            set
            {
                _owerAddress = value;
                OnPropertychanged(nameof(OwnerAddress));
            }
        }

        private string _balance;
        public string Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertychanged(nameof(Balance));
            }
        }

        private DateTime _openDate;
        public DateTime OpenDate
        {
            get => _openDate;
            set
            {
                _openDate = value;
                OnPropertychanged(nameof(OpenDate));
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertychanged(nameof(Email));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertychanged(nameof(PhoneNumber));
            }
        }
        private string _errorStatus;
        public string ErrorStatus
        {
            get => _errorStatus;
            set
            {
                _errorStatus = value;
                OnPropertyChanged(nameof(ErrorStatus));
            }
        }
        private System.Windows.Media.Brush _errorColor;
        public System.Windows.Media.Brush ErrorColor
        {
            get => _errorColor;
            set
            {
                _errorColor = value;
                OnPropertyChanged(nameof(ErrorColor));
            }
        }
        private string _gender;
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertychanged(nameof(Gender));
            }
        }

        private DateTime _dob;
        public DateTime DoB
        {
            get => _dob;
            set
            {
                _dob = value;
                OnPropertychanged(nameof(DoB));
            }
        }
        private SavingsAccount _selectedSavingsAccount;
        public SavingsAccount SelectedSavingsAccount
        {
            get => _selectedSavingsAccount;
            set
            {
                _selectedSavingsAccount = value;
                OnPropertyChanged(nameof(SelectedSavingsAccount));
            }
            
        }

        private ObservableCollection<SavingsAccount> _savingsAccountlist;
        private bool _isLoading = false;
        private bool _isLoadingError = false;

        public ObservableCollection<SavingsAccount> SavingsAccountsList
        {
            get => _savingsAccountlist;
            set
            {
                _savingsAccountlist = value;
                OnPropertyChanged(nameof(SavingsAccountsList));
            }
        }       

        public AddNewSavingViewModel(SavingsAccountListViewModel savingsAccountListViewModel, NavigationStore navigationStore)
        {
            OnloadCommand = new Command.CreateNewSavingsAccountOnloadCMD(this);
            IsNewCustomer = true;
            OpenDate = DateTime.Now;
            DoB = DateTime.Now;
            _savingsAccountListViewModel = savingsAccountListViewModel;
            _navigationStore = navigationStore;
            this.FillFormCMD = new Command.FillFormCMD(this);
            this.CancelCMD = new Command.NavigateCMD(new Services.CloseModalNavSvc(navigationStore));
            this.CreateNewSavingCMD = new Command.CreateNewSavingsCMD(this,_savingsAccountListViewModel, _navigationStore);
            //this.SavingsAccountsList = _savingsAccountListViewModel.savingsAccounts;
           


        }

        public ICommand OnloadCommand { get; }
        public ICommand FillFormCMD { get; }
        public ICommand CancelCMD { get; }        
        public ICommand CreateNewSavingCMD { get; }


        public decimal MinInitMoney;
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

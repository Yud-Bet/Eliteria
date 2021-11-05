using Eliteria.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    public class TransactionViewModel : BaseViewModel
    {
        public Stores.NavigationStore navigationStore;
        public Stores.AccountStore accountStore;

        private ObservableCollection<SavingsAccount> _SavingList;
        public ObservableCollection<SavingsAccount> SavingList { get => _SavingList; set { _SavingList = value; OnPropertyChanged(); } }


        private ObservableCollection<Customer> _CustomerList;
        public ObservableCollection<Customer> CustomerList { get => _CustomerList; set { _CustomerList = value; OnPropertyChanged(); } }

        private SavingsAccount _SelectedSaving;
        public SavingsAccount SelectedSaving
        {
            get => _SelectedSaving;
            set
            {
                _SelectedSaving = value;
                OnPropertyChanged();
            }
        }
        private int _idTransaction;
        public int idTransaction { get => _idTransaction; set { _idTransaction = value; } }

        private int _TransactionType = 1;
        public int TransactionType { get => _TransactionType; set { _TransactionType = value; OnPropertyChanged(); } }

        private bool _isPrintBill = true;
        public bool isPrintBill { get => _isPrintBill; set { _isPrintBill = value; OnPropertyChanged(); } }
        
        private bool _isWithdrawInterest = false;
        public bool isWithdrawInterest { get => _isWithdrawInterest; set { _isWithdrawInterest = value; OnPropertyChanged(); } }
        
        private DateTime _TransactionDate;
        public DateTime TransactionDate { get => _TransactionDate; set { _TransactionDate = value; OnPropertyChanged(); } }

        private string _TransactionMoney;
        public string TransactionMoney { get => _TransactionMoney; set { _TransactionMoney = value; OnPropertyChanged(); } }

        private string _errorStatus;
        public string ErrorStatus { get => _errorStatus; set { _errorStatus = value; OnPropertyChanged(nameof(ErrorStatus)); } }

        private System.Windows.Media.Brush _errorColor;
        public System.Windows.Media.Brush ErrorColor { get => _errorColor; set { _errorColor = value; OnPropertyChanged(nameof(ErrorColor)); } }

        public ICommand SendMoneyCMD { get; set; }
        public ICommand WithdrawMoneyCMD { get; set; }

        public ICommand ConfirmCMD { get; set; }
        public ICommand CheckPrintBillCMD { get; set; }
        public ICommand WithdrawInterestCMD { get; set; }
        public ICommand LoadAllSavingCMD { get; }
        public ICommand OnLoadCommand { get; }

        public TransactionViewModel(Stores.NavigationStore navigationStore, Stores.AccountStore accountStore)
        {
            this.navigationStore = navigationStore;
            this.accountStore = accountStore;

            TransactionDate = new DateTime();
            TransactionDate = DateTime.Now;

            LoadAllSavingCMD = new Command.LoadAllSavingsCommand(this);
            OnLoadCommand = new Command.TransactionOnLoadCMD(this);
            SendMoneyCMD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                TransactionType = 1;
                ErrorStatus = "";
            });
            WithdrawMoneyCMD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                TransactionType = 2;
                ErrorStatus = "";
            });

            ConfirmCMD = new Command.ConfirmTransactionCommand(this);
            CheckPrintBillCMD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                isPrintBill = !isPrintBill;
            });
            WithdrawInterestCMD = new RelayCommand<object>((p) => 
            { 
                return true; 
            }, (p) =>
            {
                isWithdrawInterest = !isWithdrawInterest;
                if (SelectedSaving != null && TransactionType == 2)
                {
                    if (isWithdrawInterest)
                        TransactionMoney = SelectedSaving.Interest.ToString();
                    else if (this.SelectedSaving.IdSavingType != 1)
                        TransactionMoney = SelectedSaving.Balance.ToString();
                }
            });

        }
    }

    #region RelayCommand
    class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return _canExecute == null ? true : _canExecute((T)parameter);
            }
            catch
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
    #endregion
}
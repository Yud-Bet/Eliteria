using Eliteria.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class TransactionViewModel : BaseViewModel
    {
        private int _TransactionType = 1;
        public int TransactionType { get => _TransactionType; set { _TransactionType = value; OnPropertyChanged(); } }
        private bool _isPrintBill = true;
        public bool isPrintBill { get => _isPrintBill; set { _isPrintBill = value; OnPropertyChanged(); } }
        private bool _isWithdrawInterest = true;
        public bool isWithdrawInterest { get => _isWithdrawInterest; set { _isWithdrawInterest = value; OnPropertyChanged(); } }
        //private bool _isOpenNewSaving = false;
        //public bool isOpenNewSaving { get => _isOpenNewSaving; set { _isOpenNewSaving = value; OnPropertyChanged(); } }
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

        private DateTime _TransactionDate;
        public DateTime TransactionDate { get => _TransactionDate; set { _TransactionDate = value; OnPropertyChanged(); } }

        private string _TransactionMoney;

        public string TransactionMoney { get => _TransactionMoney; set { _TransactionMoney = value; OnPropertyChanged(); } }

        public ICommand SendMoneyCMD { get; set; }
        public ICommand WithdrawMoneyCMD { get; set; }
        public ICommand OpenNewSavingCMD { get; set; }

        public ICommand ConfirmCMD { get; set; }
        public ICommand CancelCMD { get; set; }
        public ICommand CheckPrintBillCMD { get; set; }
        public ICommand WithdrawInterestCMD { get; set; }
        public ICommand LoadAllSavingCMD { get; }
        public ICommand OnLoadCommand { get; }

        public TransactionViewModel()
        {
            TransactionDate = new DateTime();
            TransactionDate = DateTime.Now;

            LoadAllSavingCMD = new Command.LoadAllSavingsCommand(this);
            OnLoadCommand = new Command.TransactionOnLoadCMD(this);
            SendMoneyCMD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                TransactionType = 1;
                //isOpenNewSaving = false;
                //MessageBox.Show("Click gui tien"); 
            });
            WithdrawMoneyCMD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                TransactionType = 2;
                //isOpenNewSaving = false;
                //MessageBox.Show("Click gui tien");
            });
            OpenNewSavingCMD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //isOpenNewSaving = true;
                TransactionType = 0;
                //MessageBox.Show("Click gui tien");
            });

            ConfirmCMD = new Command.ConfirmTransactionCommand(this);
            CancelCMD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

            });
            CheckPrintBillCMD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                isPrintBill = !isPrintBill;
                //MessageBox.Show(isPrintBill.ToString());
            });
            WithdrawInterestCMD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                isWithdrawInterest = !isWithdrawInterest;
                //MessageBox.Show(isPrintBill.ToString());
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
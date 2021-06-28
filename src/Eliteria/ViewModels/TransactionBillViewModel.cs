using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.ViewModels
{
    class TransactionBillViewModel : BaseViewModel
    {
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

        public TransactionBillViewModel()
        {
            TransactionDate = new DateTime();
            TransactionDate = DateTime.Now;

        }
    }
}

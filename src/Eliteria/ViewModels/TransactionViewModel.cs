using Eliteria.Models;
using Eliteria.Views.Transaction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Eliteria.ViewModels
{
    class TransactionViewModel : BaseViewModel
    {
        Parameter parameter = new Parameter();
        private int _TransactionType = 1;
        public int TransactionType { get => _TransactionType; set { _TransactionType = value; OnPropertyChanged(); } }
        private bool _isPrintBill = true;
        public bool isPrintBill { get => _isPrintBill; set { _isPrintBill = value; OnPropertyChanged(); } }
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
        public ICommand CheckPrintBill { get; set; }

        public async void loadDataSavingList()
        {
            SavingList = new ObservableCollection<SavingsAccount>();
            DataTable savingList = await DataAccess.TransactionData.GetAllSaving();
            for (int i = 0; i < savingList.Rows.Count; i++)
            {
                SavingsAccount item = new SavingsAccount();
                item.AccountNumber = Convert.ToString(savingList.Rows[i].ItemArray[0]);
                item.Name = Convert.ToString(savingList.Rows[i].ItemArray[1]);
                item.Balance = Convert.ToDecimal(savingList.Rows[i].ItemArray[2]);
                item.NextDueDate = Convert.ToDateTime(savingList.Rows[i].ItemArray[3]);
                item.PrescribedAmountDrawn = Convert.ToString(savingList.Rows[i].ItemArray[4]);
                //item.TotalWithdrawMoney = Convert.ToInt32(savingList.Rows[i].ItemArray[5]);
                //item.InterestMoney = Convert.ToInt32(savingList.Rows[i].ItemArray[6]);
                //item.TotalMoney = Convert.ToInt32(savingList.Rows[i].ItemArray[7]);
                //item.NextDuedate = Convert.ToDateTime(savingList.Rows[i].ItemArray[8]);
                //item.InterestRate = Convert.ToInt32(savingList.Rows[i].ItemArray[9]);
                //item.Status = Convert.ToBoolean(savingList.Rows[i].ItemArray[10]);

                //if (savingList.Rows[i].ItemArray[11] != null)
                //    item.closeDateSaving = Convert.ToDateTime(savingList.Rows[i].ItemArray[11]);

                SavingList.Add(item);

            } }
        public TransactionViewModel()
        {
            loadDataSavingList();

            TransactionDate = new DateTime();
            TransactionDate = DateTime.Now;

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

            ConfirmCMD = new RelayCommand<object>((p) => 
            {
                if (SelectedSaving == null )
                {
                    return false;
                }               
                    return true; }, (p) => 
            {
                //MessageBox.Show(SelectedSaving.MaSTK.ToString());
                if (TransactionType == 1)
                {
                    if (Convert.ToDecimal(TransactionMoney) >= parameter.MinNextSendMoney)
                    {
                        InsertTransactionData();
                        printBill();
                        loadDataSavingList();
                    }
                    else
                        MessageBox.Show("So tien chua du");

                }
                else if (TransactionType == 2)
                {
                    if (SelectedSaving.PrescribedAmountDrawn == "<=") 
                    {
                        if (SelectedSaving.NextDueDate.Date == TransactionDate.Date)
                        {

                            if (Convert.ToDecimal(TransactionMoney) <= SelectedSaving.Balance)
                            {
                                InsertTransactionData();
                                printBill();
                                loadDataSavingList();
                            }
                            else
                            {
                                MessageBox.Show("So tien rut khong hop le!");
                            }
                        }
                        else
                        {
                            MessageBox.Show(SelectedSaving.NextDueDate.ToString());
                            MessageBox.Show("Chua den ngay rut tien");
                        }
                    }
                    else if (SelectedSaving.PrescribedAmountDrawn == "=")
                    {
                        if (Convert.ToDecimal(TransactionMoney) == SelectedSaving.Balance)
                        {
                            InsertTransactionData();
                            printBill();
                            loadDataSavingList();
                        }
                        else
                        {
                            MessageBox.Show("So tien rut khong hop le!");
                        }

                    }
                }
                
            });
            CancelCMD = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                
            });
            CheckPrintBill = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                isPrintBill = !isPrintBill;
                //MessageBox.Show(isPrintBill.ToString());
            });

        }

        public void printBill()
        {
            if (isPrintBill)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(TransactionView._transation, "Eliteria");
                }
            }

        }
        public async void InsertTransactionData()
        {
            int result = await DataAccess.TransactionData.InsertNewTransaction(TransactionType, 
                                                                                Convert.ToInt32(SelectedSaving.AccountNumber), 
                                                                                1,  //idStaff
                                                                                Convert.ToDateTime(TransactionDate), 
                                                                                Convert.ToDecimal(TransactionMoney));
            if (result == -1)
            {
                MessageBox.Show("Thanh cong!");
            }
        }
    }
}

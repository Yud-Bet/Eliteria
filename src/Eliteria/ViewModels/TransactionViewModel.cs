using Eliteria.Models;
using Eliteria.Views;
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
                if (SelectedSaving == null)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                //QĐ2: Chỉ nhận gởi thêm tiền khi đến kỳ hạn tính lãi suất của các loại tiết kiệm tương ứng. Số tiền gởi thêm tối thiểu là 100.000đ
                if (TransactionType == 1)
                {
                    if (SelectedSaving.NextDueDate.Date == TransactionDate.Date || SelectedSaving.BeforeDueDate == TransactionDate.Date)
                    {
                        if (Convert.ToDecimal(TransactionMoney) >= parameter.MinNextSendMoney)
                        {
                            InsertTransactionData();
                            printBill();
                            loadDataSavingList();
                        }
                        else
                            MessageBox.Show(String.Concat("Số tiền gởi thêm tối thiểu là ", parameter.MinNextSendMoney.ToString(), "VND"));
                    }
                    else
                    {
                        MessageBox.Show(String.Concat("Chỉ nhận gửi thêm tiền khi đến kỳ hạn tính lãi suất: Ngày ", SelectedSaving.NextDueDate.Date.ToString("dd/MM/yyyy")));
                    }

                }
                //QĐ3:  Lãi suất là 0.5% đối với loại không kỳ hạn, 5% với kỳ hạn 3 tháng và 5.5% với kỳ hạn 6 tháng.
                //Tiền lãi 1 năm = số dư* lãi suất của loại tiết kiệm tương ứng.
                //Loại tiết kiệm có kỳ hạn chỉ được rút khi quá kỳ hạn và phải rút hết toàn bộ, khi này tiền lãi được tính với mức lãi suất của loại không kỳ hạn.
                //Loại tiết kiệm không kỳ hạn được rút khi gửi trên 15 ngày và có thể rút số tiền <= số dư hiện có.
                //Sổ sau khi rút hết tiền sẽ tự động đóng.

                else if (TransactionType == 2)
                {
                    TimeSpan timeSpan = TransactionDate.Subtract(SelectedSaving.OpenDate);
                    if (timeSpan.Days >= SelectedSaving.MinDaysToWithdrawn)
                    {
                        //Loại tiết kiệm không kỳ hạn được rút khi gửi trên 15 ngày và có thể rút số tiền <= số dư hiện có.
                        if (SelectedSaving.IdSavingType == 1)
                        {

                            if (Convert.ToDecimal(TransactionMoney) <= SelectedSaving.Balance)
                            {
                                InsertTransactionData();
                                printBill();
                                CloseSaving();
                                loadDataSavingList();
                            }
                            else
                            {
                                MessageBox.Show(String.Concat("Bạn chỉ có thể rút số tiền không quá số dư hiện có là ", SelectedSaving.Balance.ToString(), "VND"));
                            }
                        }
                        //Loại tiết kiệm có kỳ hạn chỉ được rút khi quá kỳ hạn và phải rút hết toàn bộ, khi này tiền lãi được tính với mức lãi suất của loại không kỳ hạn.
                        else if (SelectedSaving.IdSavingType != 1)
                        {
                            if (timeSpan.Days > SelectedSaving.MinDaysToWithdrawn)
                            {
                                //if ()
                                MessageBox.Show("");
                                if (Convert.ToDecimal(TransactionMoney) == SelectedSaving.Balance)
                                {
                                    InsertTransactionData();
                                    printBill();
                                    //Sổ sau khi rút hết tiền sẽ tự động đóng.
                                    CloseSaving();
                                    loadDataSavingList();
                                }
                                else
                                {
                                    MessageBox.Show(String.Concat("Bạn chỉ có thể rút hết số tiền hiện có là ", SelectedSaving.Balance.ToString(), "VND"));
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(String.Concat("Loại tiết kiệm không kỳ hạn được rút khi gửi trên ",
                                                            SelectedSaving.MinDaysToWithdrawn.ToString(),
                                                            " ngày! \nXin vui lòng quay lại sau ngày ",
                                                            SelectedSaving.OpenDate.AddDays(SelectedSaving.MinDaysToWithdrawn).Date.ToString("dd/MM/yyyy")));
                        }
                    }
                    else
                    {
                        MessageBox.Show(String.Concat("Chỉ được rút khi gửi trên ",
                                                        SelectedSaving.MinDaysToWithdrawn.ToString(),
                                                        " ngày! \nXin vui lòng quay lại sau ngày ",
                                                        SelectedSaving.OpenDate.AddDays(SelectedSaving.MinDaysToWithdrawn).Date.ToString("dd/MM/yyyy")));
                    }


                }
                

            });
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
                item.BeforeDueDate = Convert.ToDateTime(savingList.Rows[i].ItemArray[5]);
                item.OpenDate = Convert.ToDateTime(savingList.Rows[i].ItemArray[6]);
                item.IdSavingType = Convert.ToInt32(savingList.Rows[i].ItemArray[7]);
                item.MinDaysToWithdrawn = Convert.ToInt32(savingList.Rows[i].ItemArray[8]);
                //item.InterestRate = Convert.ToInt32(savingList.Rows[i].ItemArray[9]);
                //item.Status = Convert.ToBoolean(savingList.Rows[i].ItemArray[10]);

                //if (savingList.Rows[i].ItemArray[11] != null)
                //    item.closeDateSaving = Convert.ToDateTime(savingList.Rows[i].ItemArray[11]);

                SavingList.Add(item);
                TransactionMoney = "";
            }
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
            if (result > 0)
            {
                MessageBox.Show("Giao dịch thành công!");
            }
        }
        public async void CloseSaving()
        {
            int result = await DataAccess.TransactionData.ControlCloseSaving();
            if (result > 0)
            {
                MessageBox.Show("Đóng sổ tự động thành công!");
            }
        }
    }
}
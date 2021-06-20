using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class TransactionViewModel : BaseViewModel
    {

        private ObservableCollection<Saving> _SavingList;
        public ObservableCollection<Saving> SavingList { get => _SavingList; set { _SavingList = value; OnPropertyChanged(); } }
        private ObservableCollection<int> _IDSavingList;
        public ObservableCollection<int> IDSavingList { get => _IDSavingList; set { _IDSavingList = value; OnPropertyChanged(); } }

        private ObservableCollection<Customer> _CustomerList;
        public ObservableCollection<Customer> CustomerList { get => _CustomerList; set { _CustomerList = value; OnPropertyChanged(); } }

        private Saving _SelectedSaving;
        public Saving SelectedSaving 
        { 
            get => _SelectedSaving; 
            set 
            { 
                _SelectedSaving = value; 
                OnPropertyChanged(); 
                if (SelectedSaving != null)
                {
                    //SelectedCustomer = SelectedSaving.KHACHHANG;
                }
                else if (SelectedSaving == null)
                {
                    SelectedCustomer = null;
                }
            } 
        }
        private int _SelectedIdSaving;
        public int SelectedIdSaving
        {
            get => _SelectedIdSaving;
            set
            {
                _SelectedIdSaving = value;
                OnPropertyChanged();
                if (SelectedSaving != null)
                {
                    //SelectedCustomer = SelectedSaving.KHACHHANG;
                }
                else if (SelectedSaving == null)
                {
                    SelectedCustomer = null;
                }
            }
        }

        private Customer _SelectedCustomer;
        public Customer SelectedCustomer
        {
            get => _SelectedCustomer;
            set
            {
                _SelectedCustomer = value;
                OnPropertyChanged();
                if (SelectedCustomer != null)
                {
                    //var savingList = DataProvider.Ins.DB.SOTIETKIEMs.SqlQuery("select * from SOTIETKIEM where MaKH = @id", new SqlParameter("@id", SelectedCustomer.MaKH)).ToList();
                    ////SavingList.Clear();
                    //SavingList = new ObservableCollection<SOTIETKIEM>(savingList);
                }
            }
        }
        private DateTime _TransactionDate;
        public DateTime TransactionDate { get => _TransactionDate; set { _TransactionDate = value; OnPropertyChanged(); } }

        private string _TransactionMoney;
        public string TransactionMoney { get => _TransactionMoney; set { _TransactionMoney = value; OnPropertyChanged(); } }

        public ICommand SendMoneyCMD { get; set; }
        public ICommand WithdrawMoneyCMD { get; set; }
        public ICommand ConfirmCMD { get; set; }
        public ICommand CancelCMD { get; set; }
        public ICommand CheckPrintBill { get; set; }
        public TransactionViewModel()
        {
            SavingList = new ObservableCollection<Saving>();
            IDSavingList = new ObservableCollection<int>();
            var savingList = Models.Transaction.GetAllSaving();
            for (int i=0; i < savingList.Rows.Count; i++)
            {
                Saving item = new Saving();
                item.idSaving = Convert.ToInt32(savingList.Rows[i].ItemArray[0]);
                item.idCustomer = Convert.ToInt32(savingList.Rows[i].ItemArray[1]);
                item.idSavingType = Convert.ToInt32(savingList.Rows[i].ItemArray[2]);
                item.openDateSaving = Convert.ToDateTime(savingList.Rows[i].ItemArray[3]);
                item.totalSendMoney = Convert.ToInt32(savingList.Rows[i].ItemArray[4]);
                item.totalWithdrawMoney = Convert.ToInt32(savingList.Rows[i].ItemArray[5]);
                item.interestMoney = Convert.ToInt32(savingList.Rows[i].ItemArray[6]);
                item.totalMoney = Convert.ToInt32(savingList.Rows[i].ItemArray[7]);
                item.nextDuedate = Convert.ToDateTime(savingList.Rows[i].ItemArray[8]);
                item.interestRate = Convert.ToInt32(savingList.Rows[i].ItemArray[9]);
                item.status = Convert.ToBoolean(savingList.Rows[i].ItemArray[10]);
                //if (savingList.Rows[i].ItemArray[11] != null)
                //    item.closeDateSaving = Convert.ToDateTime(savingList.Rows[i].ItemArray[11]);

                SavingList.Add(item);
                IDSavingList.Add(item.idSaving);
            }

            //CustomerList = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
            //SelectedSaving = new SOTIETKIEM();
            //SelectedCustomer = new KHACHHANG();
            TransactionDate = new DateTime();
            TransactionDate = DateTime.Now;

            SendMoneyCMD = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                //MessageBox.Show("Click gui tien"); 
            });
            WithdrawMoneyCMD = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                //MessageBox.Show("Click gui tien");
            });
            ConfirmCMD = new RelayCommand<object>((p) => 
            {
                //if (Convert.ToInt32(TransactionMoney) < 1000)
                //{
                //    MessageBox.Show("Loi!");
                //    return false;
                //} 
                //else
                    return true; }, (p) => 
            {
                //MessageBox.Show(SelectedSaving.MaSTK.ToString());
                //InsertTransactionData();
            });
            CancelCMD = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                //MessageBox.Show("Click gui tien");
            });
            CheckPrintBill = new RelayCommand<object>((p) => { return true; }, (p) => 
            {
                //MessageBox.Show("Click gui tien");
            });

        }

        void InsertTransactionData()
        {
            Transaction pHIEUGIAODICH = new Transaction()
            {
                idTransactionType = 2,
                //idSaving = SelectedSaving.MaSTK,
                idStaff = 1,
                transactionDate = TransactionDate,
                transactionMoney = Convert.ToInt32(TransactionMoney)
            };
            //DataProvider.Ins.DB.PHIEUGIAODICHes.Add(pHIEUGIAODICH);
            //if (Convert.ToBoolean(DataProvider.Ins.DB.SaveChanges()))
            //{
            //    MessageBox.Show("Thanh cong!");
            //}
            SavingList.Clear();
        }
    }
}

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

        private ObservableCollection<SOTIETKIEM> _SavingList;
        public ObservableCollection<SOTIETKIEM> SavingList { get => _SavingList; set { _SavingList = value; OnPropertyChanged(); } }
        
        private ObservableCollection<KHACHHANG> _CustomerList;
        public ObservableCollection<KHACHHANG> CustomerList { get => _CustomerList; set { _CustomerList = value; OnPropertyChanged(); } }

        private SOTIETKIEM _SelectedSaving;
        public SOTIETKIEM SelectedSaving 
        { 
            get => _SelectedSaving; 
            set 
            { 
                _SelectedSaving = value; 
                OnPropertyChanged(); 
                if (SelectedSaving != null)
                {
                    SelectedCustomer = SelectedSaving.KHACHHANG;
                }
                else if (SelectedSaving == null)
                {
                    SelectedCustomer = null;
                }
            } 
        }

        private KHACHHANG _SelectedCustomer;
        public KHACHHANG SelectedCustomer
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
            SavingList = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs);
            CustomerList = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs);
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
                InsertTransactionData();
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
            PHIEUGIAODICH pHIEUGIAODICH = new PHIEUGIAODICH()
            {
                MaLoaiGD = 2,
                MaSTK = SelectedSaving.MaSTK,
                MaNV = 1,
                NgayLapPhieu = TransactionDate,
                SoTien = Convert.ToInt32(TransactionMoney)
            };
            DataProvider.Ins.DB.PHIEUGIAODICHes.Add(pHIEUGIAODICH);
            if (Convert.ToBoolean(DataProvider.Ins.DB.SaveChanges()))
            {
                MessageBox.Show("Thanh cong!");
            }
            SavingList.Clear();
        }
    }
}

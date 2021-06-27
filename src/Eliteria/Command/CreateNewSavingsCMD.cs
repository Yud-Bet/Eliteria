﻿using Eliteria.Models;
using Eliteria.Stores;
using Eliteria.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Eliteria.Command
{
    class CreateNewSavingsCMD : BaseCommand
    {
        private SavingsAccountListViewModel _savingsAccountsListViewModel;
        private readonly AddNewSavingViewModel _addNewSavingViewModel;
        private Decimal _minInitMoney;
 

        private List<string> IDList;

        public CreateNewSavingsCMD(AddNewSavingViewModel addNewSavingViewModel, SavingsAccountListViewModel savingsAccountsListViewModel, NavigationStore homeNavStore)
        {
            this._savingsAccountsListViewModel = savingsAccountsListViewModel;                   
            _addNewSavingViewModel = addNewSavingViewModel;
            IDList = new List<string>();
        }

        public async override void Execute(object parameter)
        {
            _minInitMoney = new decimal();
            _minInitMoney = await DataAccess.DACreateNewSavings.GetMinInitMoney();
            await DataAccess.DAGetCustomerList.DAGetCustomerListIDs(IDList);

            var f = new NumberFormatInfo { NumberGroupSeparator = " " };

            var FormatedMin = _minInitMoney.ToString("n", f);

            if (_addNewSavingViewModel.IsNewCustomer)
            {

                if (IDList.Contains(_addNewSavingViewModel.OwnerID))
                {
                    //MessageBox.Show("CMND/CCCD đã tồn tại trong hệ thống vui lòng chuyển sang mở sổ cho khách hàng cũ", "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    _addNewSavingViewModel.ErrorStatus = "CMND/CCCD đã tồn tại trong hệ thống! Vui lòng chuyển sang mở sổ cho khách hàng cũ";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }


                if (_addNewSavingViewModel.OwnerName == null || _addNewSavingViewModel.SelectedSavingType == null || _addNewSavingViewModel.OwnerID == null || _addNewSavingViewModel.OwnerAddress == null || _addNewSavingViewModel.Balance == null || _addNewSavingViewModel.Email == null || _addNewSavingViewModel.Gender == null || _addNewSavingViewModel.PhoneNumber == null)
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng nhập đầy đủ dữ liệu!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;                    
                    return;
                }
                else
                {
                    if(Convert.ToDecimal(_addNewSavingViewModel.Balance) < _minInitMoney)
                    {
                        _addNewSavingViewModel.ErrorStatus = $"Số tiền gửi ban đầu tối thiểu là {FormatedMin} đ";
                        _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                        return;
                    }
                    SavingsAccount savingsAccount = new SavingsAccount();
                    savingsAccount.Name = _addNewSavingViewModel.OwnerName;
                    savingsAccount.Type = _addNewSavingViewModel.SelectedSavingType;
                    savingsAccount.IdentificationNumber = _addNewSavingViewModel.OwnerID;
                    savingsAccount.Address = _addNewSavingViewModel.OwnerAddress;
                    savingsAccount.Balance = Convert.ToDecimal(_addNewSavingViewModel.Balance);
                    savingsAccount.OpenDate = _addNewSavingViewModel.OpenDate;
                    savingsAccount.Email = _addNewSavingViewModel.Email;
                    savingsAccount.Phonenumber = _addNewSavingViewModel.PhoneNumber;
                    savingsAccount.Gender = _addNewSavingViewModel.Gender;
                    savingsAccount.DoB = _addNewSavingViewModel.DoB;
                    await DataAccess.DACreateNewSavings.AsNewCustomer(savingsAccount);
                    _savingsAccountsListViewModel.savingsAccounts = await DataAccess.DASavingAccountList.LoadListFromDatabase();
                    _addNewSavingViewModel.ErrorStatus = "Thêm sổ tiết kiệm thành công";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Green;
                }
            

            }
            else
            {
                if (_addNewSavingViewModel.SelectedSavingsAccount == null || _addNewSavingViewModel.SelectedSavingsAccount.IdentificationNumber == null || _addNewSavingViewModel.SelectedSavingType == null || _addNewSavingViewModel.OpenDate == null || _addNewSavingViewModel.Balance == null)
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng nhập đầy đủ dữ liệu!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                if (Convert.ToDecimal(_addNewSavingViewModel.Balance) < _minInitMoney)
                {
                    _addNewSavingViewModel.ErrorStatus = $"Số tiền gửi ban đầu tối thiểu là {FormatedMin} đ";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                await DataAccess.DACreateNewSavings.AsOldCustomer(_addNewSavingViewModel.SelectedSavingsAccount.IdentificationNumber, _addNewSavingViewModel.SelectedSavingType, _addNewSavingViewModel.OpenDate, Convert.ToDecimal(_addNewSavingViewModel.Balance));
                _savingsAccountsListViewModel.savingsAccounts = await DataAccess.DASavingAccountList.LoadListFromDatabase();
               
                _addNewSavingViewModel.ErrorStatus = "Thêm sổ tiết kiệm thành công";
                _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Green;


            }





          

        }
    }
}

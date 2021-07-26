
using Eliteria.DataAccess.Models;
using Eliteria.DataAccess.Modules;
using Eliteria.Stores;
using Eliteria.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Eliteria.Command
{
    class CreateNewSavingsCMD : BaseCommand
    {
        private SavingsAccountListViewModel _savingsAccountsListViewModel;
        private readonly AddNewSavingViewModel _addNewSavingViewModel;

        private List<string> IDList;

        public CreateNewSavingsCMD(AddNewSavingViewModel addNewSavingViewModel, SavingsAccountListViewModel savingsAccountsListViewModel, NavigationStore homeNavStore)
        {
            this._savingsAccountsListViewModel = savingsAccountsListViewModel;
            _addNewSavingViewModel = addNewSavingViewModel;
            IDList = new List<string>();
        }

        public async override void Execute(object parameter)
        {
            await DataAccess.DAGetCustomerList.DAGetCustomerListIDs(IDList);

            var f = new NumberFormatInfo { NumberGroupSeparator = " " };

            var FormatedMin = _addNewSavingViewModel.MinInitMoney.ToString("n", f);

            if (_addNewSavingViewModel.IsNewCustomer)
            {

                if (IDList.Contains(_addNewSavingViewModel.OwnerID))
                {
                    //MessageBox.Show("CMND/CCCD đã tồn tại trong hệ thống vui lòng chuyển sang mở sổ cho khách hàng cũ", "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    _addNewSavingViewModel.ErrorStatus = "CMND/CCCD đã tồn tại trong hệ thống! Vui lòng chuyển sang mở sổ cho khách hàng cũ";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                if (_addNewSavingViewModel.OwnerID == null || _addNewSavingViewModel.OwnerID == "")
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng nhập CMND/CCCD của khách hàng!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }

                else if (_addNewSavingViewModel.OwnerName == null || _addNewSavingViewModel.OwnerName == "")
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng nhập họ và tên của khách hàng!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                else if (_addNewSavingViewModel.DoB.Date == DateTime.Now.Date)
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng kiểm tra lại ngày sinh của khách hàng!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                else if (_addNewSavingViewModel.Gender == null)
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng chọn giới tính của khách hàng!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                else if (_addNewSavingViewModel.OwnerAddress == null || _addNewSavingViewModel.OwnerAddress == "")
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng nhập địa chỉ của khách hàng!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                else if(_addNewSavingViewModel.Email==null||_addNewSavingViewModel.Email=="")
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng nhập địa chỉ email của khách hàng!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                else if (_addNewSavingViewModel.PhoneNumber == null || _addNewSavingViewModel.PhoneNumber == "")
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng nhập SĐT của khách hàng!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }

                else if (_addNewSavingViewModel.SelectedSavingType == null)
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng chọn loại tiết kiệm !";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                else if (_addNewSavingViewModel.Balance == null|| _addNewSavingViewModel.Balance == "")
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng nhập tiền gửi ban đầu!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                else
                {
                    if (Convert.ToDecimal(_addNewSavingViewModel.Balance) < _addNewSavingViewModel.MinInitMoney)
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
                    //_savingsAccountsListViewModel.AllSavings = await DataAccess.DASavingAccountList. LoadListFromDatabase();
                    _savingsAccountsListViewModel.AllSavings= await SavingsAccountM.GetSavingsAccounts();
                    _savingsAccountsListViewModel.savingsAccounts = _savingsAccountsListViewModel.AllSavings;
                    _addNewSavingViewModel.ErrorStatus = "Thêm sổ tiết kiệm thành công";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Green;
                }


            }
            else
            {
                if (_addNewSavingViewModel.SelectedSavingsAccount == null || _addNewSavingViewModel.SelectedSavingsAccount.IdentificationNumber == null)
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng chọn một khách hàng trong danh sách CCCD/CMND!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                else if (_addNewSavingViewModel.SelectedSavingType == null)
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng chọn loại tiết kiệm !";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                else if (_addNewSavingViewModel.Balance == null|| _addNewSavingViewModel.Balance == "")
                {
                    _addNewSavingViewModel.ErrorStatus = "Vui lòng nhập tiền gửi ban đầu!";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                else if (Convert.ToDecimal(_addNewSavingViewModel.Balance) < _addNewSavingViewModel.MinInitMoney)
                {
                    _addNewSavingViewModel.ErrorStatus = $"Số tiền gửi ban đầu tối thiểu là {FormatedMin} đ";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    return;
                }
                await DataAccess.DACreateNewSavings.AsOldCustomer(_addNewSavingViewModel.SelectedSavingsAccount.IdentificationNumber, _addNewSavingViewModel.SelectedSavingType, _addNewSavingViewModel.OpenDate, Convert.ToDecimal(_addNewSavingViewModel.Balance));
                //_savingsAccountsListViewModel.AllSavings = await DataAccess.DASavingAccountList.LoadListFromDatabase();
                _savingsAccountsListViewModel.AllSavings = await SavingsAccountM.GetSavingsAccounts();
                _savingsAccountsListViewModel.savingsAccounts = _savingsAccountsListViewModel.AllSavings;

                _addNewSavingViewModel.ErrorStatus = "Thêm sổ tiết kiệm thành công";
                _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Green;


            }
        }
    }
}

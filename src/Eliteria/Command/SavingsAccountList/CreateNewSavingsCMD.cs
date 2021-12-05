using Eliteria.Models;
using Eliteria.Stores;
using Eliteria.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Eliteria.Command
{
    public class CreateNewSavingsCMD : BaseCommand
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

            if (_addNewSavingViewModel.IsNewCustomer)
            {
                if (NewCustomerValidation(IDList, _addNewSavingViewModel.OwnerID, _addNewSavingViewModel.OwnerName, _addNewSavingViewModel.DoB.Date, _addNewSavingViewModel.Gender, _addNewSavingViewModel.OwnerAddress, _addNewSavingViewModel.Email, _addNewSavingViewModel.PhoneNumber, _addNewSavingViewModel.SelectedSavingType, _addNewSavingViewModel.Balance, _addNewSavingViewModel.MinInitMoney, ShowErrorCallBack))
                {
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
                    _savingsAccountsListViewModel.AllSavings = await DataAccess.DASavingAccountList.LoadListFromDatabase();
                    _savingsAccountsListViewModel.savingsAccounts = _savingsAccountsListViewModel.AllSavings;
                    _addNewSavingViewModel.ErrorStatus = "Thêm sổ tiết kiệm thành công";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Green;
                }


            }
            else
            {
                if (OldCustomerValidation(_addNewSavingViewModel.SelectedSavingsAccount, _addNewSavingViewModel.SelectedSavingType, _addNewSavingViewModel.Balance, _addNewSavingViewModel.MinInitMoney, ShowErrorCallBack))
                {
                    await DataAccess.DACreateNewSavings.AsOldCustomer(_addNewSavingViewModel.SelectedSavingsAccount.IdentificationNumber, _addNewSavingViewModel.SelectedSavingType, _addNewSavingViewModel.OpenDate, Convert.ToDecimal(_addNewSavingViewModel.Balance));
                    _savingsAccountsListViewModel.AllSavings = await DataAccess.DASavingAccountList.LoadListFromDatabase();
                    _savingsAccountsListViewModel.savingsAccounts = _savingsAccountsListViewModel.AllSavings;

                    _addNewSavingViewModel.ErrorStatus = "Thêm sổ tiết kiệm thành công";
                    _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Green;
                }
            }
        }

        private void ShowErrorCallBack(string message)
        {
            _addNewSavingViewModel.ErrorStatus = message;
            _addNewSavingViewModel.ErrorColor = System.Windows.Media.Brushes.Red;
        }

        public static bool NewCustomerValidation(List<string> idList, string id, string name, DateTime birthDay, string gender, string addr, string email, string phoneNum, string savingsType, string balance, decimal minInitAmount, Action<string> showErrorCallBack = null)
        {
            if (idList.Contains(id))
            {
                showErrorCallBack("CMND/CCCD đã tồn tại trong hệ thống! Vui lòng chuyển sang mở sổ cho khách hàng cũ");
                return false;
            }
            if (id == null || id == "")
            {
                showErrorCallBack("Vui lòng nhập CMND/CCCD của khách hàng!");
                return false;
            }

            else if (name == null || name == "")
            {
                showErrorCallBack("Vui lòng nhập họ và tên của khách hàng!");
                return false;
            }
            else if (birthDay == DateTime.Now.Date)
            {
                showErrorCallBack("Vui lòng kiểm tra lại ngày sinh của khách hàng!");
                return false;
            }
            else if (gender == null)
            {
                showErrorCallBack("Vui lòng chọn giới tính của khách hàng!");
                return false;
            }
            else if (addr == null || addr == "")
            {
                showErrorCallBack("Vui lòng nhập địa chỉ của khách hàng!");
                return false;
            }
            else if (email == null || email == "")
            {
                showErrorCallBack("Vui lòng nhập địa chỉ email của khách hàng!");
                return false;
            }
            else if (phoneNum == null || phoneNum == "")
            {
                showErrorCallBack("Vui lòng nhập SĐT của khách hàng!");
                return false;
            }
            else if (savingsType == null)
            {
                showErrorCallBack("Vui lòng chọn loại tiết kiệm !");
                return false;
            }
            else if (balance == null || balance == "")
            {
                showErrorCallBack("Vui lòng nhập tiền gửi ban đầu!");
                return false;
            }
            if (Convert.ToDecimal(balance) < minInitAmount)
            {
                var f = new NumberFormatInfo { NumberGroupSeparator = " " };
                var FormatedMin = minInitAmount.ToString("n", f);
                showErrorCallBack($"Số tiền gửi ban đầu tối thiểu là {FormatedMin} đ");
                return false;
            }

            return true;
        }

        public static bool OldCustomerValidation(SavingsAccount selectedAcc, string selectedSavingType, string balance, decimal minInitAmount, Action<string> ShowErrorCallBack = null)
        {
            decimal decBalance = 0.0m;
            if (selectedAcc == null || selectedAcc.IdentificationNumber == null)
            {
                ShowErrorCallBack?.Invoke("Vui lòng chọn một khách hàng trong danh sách CCCD/CMND!");
                return false;
            }
            else if (selectedSavingType == null)
            {
                ShowErrorCallBack?.Invoke("Vui lòng chọn loại tiết kiệm !");
                return false;
            }
            else if (balance == null || balance == "")
            {
                ShowErrorCallBack?.Invoke("Vui lòng nhập tiền gửi ban đầu!");
                return false;
            }
            else if (decimal.TryParse(balance, out decBalance))
            {
                if (decBalance < minInitAmount)
                {
                    var f = new NumberFormatInfo { NumberGroupSeparator = " " };
                    var FormatedMin = minInitAmount.ToString("n", f);
                    ShowErrorCallBack?.Invoke($"Số tiền gửi ban đầu tối thiểu là {FormatedMin} đ");
                    return false;
                }
            }
            else return false;
            return true;
        }
    }
}

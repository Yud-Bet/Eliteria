using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class ASavingsProfileViewModel : BaseViewModel
    {

        private SavingsAccount _savingsAccount;
        private Stores.NavigationStore _navigationStore;
        public ASavingsProfileViewModel(SavingsAccount savingsAccount, Stores.NavigationStore navigationStore)
        {
            _savingsAccount = savingsAccount;
            _navigationStore = navigationStore;
            this.CloseCMD = new Command.NavigateCMD(new Services.CloseModalNavSvc(navigationStore));

        }

        public string ASavingsID
        {
            get => _savingsAccount.AccountNumber;
            set
            {
                _savingsAccount.AccountNumber = value;
                OnPropertychanged(nameof(ASavingsID));
            }
        }


        public string ASavingsType
        {
            get => _savingsAccount.Type;
            set
            {
                _savingsAccount.Type = value;
                OnPropertychanged(nameof(ASavingsType));
            }

        }
        public string ASavingsOwnerName
        {
            get => _savingsAccount.Name;
            set
            {
                _savingsAccount.Name = value;
                OnPropertychanged(nameof(ASavingsOwnerName));
            }
        }

        public string ASavingsOwnerID
        {
            get => _savingsAccount.IdentificationNumber;
            set
            {
                _savingsAccount.IdentificationNumber = value;
                OnPropertychanged(nameof(ASavingsOwnerID));
            }
        }

        public string ASavingsOwnerAddress
        {
            get => _savingsAccount.Address;
            set
            {
                _savingsAccount.Address = value;
                OnPropertychanged(nameof(ASavingsOwnerAddress));
            }
        }


        
    
        public Decimal ASavingsBlance
        {
            get => _savingsAccount.Balance;
            set
            {
                _savingsAccount.Balance =value;
                OnPropertychanged(nameof(ASavingsBlance));
            }
        }

        public string ASavingsOpenDatestring
        {
            get => _savingsAccount.OpenDate.ToString("dd'/'MM'/'yyyy");
            set
            {
                _savingsAccount.OpenDate = Convert.ToDateTime(value);
                OnPropertychanged(nameof(ASavingsOpenDatestring));
            }
        }

        public string ASavingsEmail
        {
            get => _savingsAccount.Email;
            set
            {
                _savingsAccount.Email = value;
                OnPropertychanged(nameof(ASavingsEmail));
            }
        }

        public string ASavingsOwnerGender
        {
            get => _savingsAccount.Gender;
            set
            {
                _savingsAccount.Gender = value;
                OnPropertychanged(nameof(ASavingsOwnerGender));
            }
        }
        public string ASavingsOwnerPhone
        {
            get => _savingsAccount.Phonenumber;
            set
            {
                _savingsAccount.Phonenumber = value;
                OnPropertychanged(nameof(ASavingsOwnerPhone));
            }
        }

        public ICommand CloseCMD { get; }


    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        Stores.AccountStore accountStore = new Stores.AccountStore();
        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;

        public MainViewModel()
        {
            this.navigationStore.CurrentViewModel = new FirstViewModel(accountStore, navigationStore);
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }

        public ObservableCollection<Models.SavingsAccount> savingsAccounts
        {
            get
            {
                return new ObservableCollection<Models.SavingsAccount>
                    {
                        new Models.SavingsAccount() { Name = "Elly", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "Dakota", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "Johnson", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "Thomas", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "Peterson", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "Shelby", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "Athur", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "George", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "Thompson", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "Jerry", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "Bob", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
                        new Models.SavingsAccount() { Name = "Kelvin", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" }

                    };
            }
        }
    }
}

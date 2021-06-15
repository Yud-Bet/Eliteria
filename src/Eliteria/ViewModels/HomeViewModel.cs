using Eliteria.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class HomeViewModel: BaseViewModel
    {
        Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        Stores.AccountStore accountStore;
        public List<Models.SavingsAccount> listSavingAccouts;

        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;

        public ICommand navigateSavingAccountListCMD { get; }
        public ICommand navigateDashboardCMD { get; }
        public ICommand navigateTransactionCMD { get; }

        public HomeViewModel(Stores.AccountStore accountStore)
        {
            this.navigationStore.CurrentViewModel = new SavingsAccountListViewModel(savingsAccountsStore);
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            navigateSavingAccountListCMD = new Command.NavigateCMD<SavingsAccountListViewModel>(
                new Services.NavigationService<SavingsAccountListViewModel>(navigationStore, () => new SavingsAccountListViewModel(savingsAccountsStore)));

            navigateDashboardCMD = new Command.NavigateCMD<DashboardViewModel>(
                new Services.NavigationService<DashboardViewModel>(navigationStore, () => new DashboardViewModel()));

            navigateTransactionCMD = new Command.NavigateCMD<TransactionViewModel>(
                new Services.NavigationService<TransactionViewModel>(navigationStore, () => new TransactionViewModel()));

            this.accountStore = accountStore;
            LoadSOTIETKIEM();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }
        void LoadSOTIETKIEM()
        {
            savingsAccountsStore.savingsAccounts = new ObservableCollection<SavingsAccount>();
            //savingsAccounts = new ObservableCollection<Models.SavingsAccount> { };
            //listSavingAccouts = new List<SavingsAccount>();
            foreach (var item in DataProvider.Ins.BD.SOTIETKIEMs.ToList())
            {
                Models.SavingsAccount savingsaccount = new Models.SavingsAccount()
                {
                    Name = item.KHACHHANG.TenKH.ToString(),
                    AccountNumber = item.MaLoaiSTK.ToString(),
                    IdentificationNumber = item.KHACHHANG.CCCD_CMND.ToString(),
                    Balance = item.SoDu,
                    Type = item.LOAISOTIETKIEM.TenLoaiSTK.ToString()
                };
                //listSavingAccouts.Add(savingsAccount);
                savingsAccountsStore.savingsAccounts.Add(savingsaccount);
            }
        }
        public Stores.SavingsAccountsStore savingsAccountsStore = new Stores.SavingsAccountsStore();
        
        //    savingsAccounts = new ObservableCollection<Models.SavingsAccount>()
        //    //{
                
        //    //    new Models.SavingsAccount() { Name = DataProvider.Ins.BD.SOTIETKIEMs.Find(2).KHACHHANG.TenKH.ToString(), AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "Dakota", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "Johnson", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "Thomas", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "Peterson", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "Shelby", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "Athur", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "George", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "Thompson", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "Jerry", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "Bob", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" },
        //    //    new Models.SavingsAccount() { Name = "Kelvin", AccountNumber = "18383929273", IdentificationNumber = "187665621", Balance = 100, Type = "6 months" }
        //    //}
        //}
    }
}

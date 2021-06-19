using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class SavingsAccountListViewModel: BaseViewModel
    {
        public SavingsAccountListViewModel()
        {
            OnLoadCommand = new Command.loadSavingsListCMD(this);
        }
        private ObservableCollection<Models.SavingsAccount> _savingAccounts;
        public ObservableCollection<Models.SavingsAccount> savingsAccounts
        {
            get => _savingAccounts;
            set
            {
                _savingAccounts = value;
                OnPropertychanged(nameof(savingsAccounts));
            }
        }

        public ICommand AddButtonCommand { get; set; }
        public ICommand OnLoadCommand { get; set; }
    }
}

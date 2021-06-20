using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class SavingsAccountListViewModel: BaseViewModel
    {
        public SavingsAccountListViewModel()
        {
            OnLoadCommand = new Command.loadSavingsListCMD(this);
           
            SavingsListFilterCommnad = new Command.loadFilteredSavingsListCMD(this,SearchText);
        }
        private ObservableCollection<Models.SavingsAccount> _savingAccounts;

        private string _searchtext;
        public string SearchText 
        {
            get => _searchtext;
            set
            {
                _searchtext = value;
                OnPropertychanged(nameof(SearchText));
            }
        }
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
        
        public ICommand SavingsListFilterCommnad { get; set; }
    }
}

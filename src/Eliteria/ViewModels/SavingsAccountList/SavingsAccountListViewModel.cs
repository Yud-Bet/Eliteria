using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class SavingsAccountListViewModel: BaseViewModel
    {
        private string _SearchText ;
        public string SearchText
        {
            get => _SearchText;
            set
            {
               _SearchText = value;
                OnPropertychanged(nameof(SearchText));
            }
        }
        public SavingsAccountListViewModel()
        {            
            OnLoadCommand = new Command.loadSavingsListCMD(this);           
            SearchCommand = new Command.loadFilteredSavingsListCMD(this);                      
           
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
        public ICommand SearchCommand { get; set; }
        
        
    }
}

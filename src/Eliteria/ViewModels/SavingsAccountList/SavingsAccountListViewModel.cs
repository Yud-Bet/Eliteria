using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    public class SavingsAccountListViewModel : BaseViewModel
    {
        private string _SearchText;
        private Stores.NavigationStore _homeNavStore;
        public string SearchText
        {
            get => _SearchText;
            set
            {
                _SearchText = value;
                OnPropertychanged(nameof(SearchText));
            }
        }
        public SavingsAccountListViewModel(Stores.NavigationStore HomeNavigationStore)
        {
            this._homeNavStore = HomeNavigationStore;
            OnLoadCommand = new Command.loadSavingsListCMD(this);
            SearchCommand = new Command.loadFilteredSavingsListCMD(this);
            ViewItemCommand = new Command.ShowSelectedSavingsCMD(_homeNavStore);        
            AddButtonCommand = new Command.NavigateCMD(new Services.ModalNavigationService<ViewModels.AddNewSavingViewModel>(_homeNavStore, () => new AddNewSavingViewModel(this, _homeNavStore)));
        }
        private ObservableCollection<Models.SavingsAccount> _savingAccounts;
        private bool _isLoading;
        private bool _isLoadingError;

        public ObservableCollection<Models.SavingsAccount> AllSavings;

        public ObservableCollection<Models.SavingsAccount> savingsAccounts
        {
            get => _savingAccounts;
            set
            {
                _savingAccounts = value;
                OnPropertychanged(nameof(savingsAccounts));
            }
        }
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }
        public bool IsLoadingError
        {
            get => _isLoadingError;
            set
            {
                _isLoadingError = value;
                OnPropertyChanged(nameof(IsLoadingError));
            }
        }
        public ICommand ViewItemCommand { get; set; }
        public ICommand AddButtonCommand { get; set; }      
        public ICommand OnLoadCommand { get; set; } 
        public ICommand SearchCommand { get; set; }
    }
}

namespace Eliteria.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            DataAccess.TransactionData.AutomaticCalculateInterest();
            mainNavigationStore.CurrentViewModel = new LoginViewModel(mainNavigationStore, navigationStore, accountStore);
            mainNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            navigationStore.CurrentModal = null;
            navigationStore.CurrentModalChanged += OnCurrentModalChanged;
        }

        private Stores.NavigationStore mainNavigationStore = new Stores.NavigationStore();
        private Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        /// <summary>
        /// This store staff account information
        /// </summary>
        private Stores.AccountStore accountStore = new Stores.AccountStore();

        public BaseViewModel CurrentViewModel => mainNavigationStore.CurrentViewModel;
        public BaseViewModel CurrentModal => navigationStore.CurrentModal;
        public bool IsOpen => navigationStore.IsOpen;

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(CurrentViewModel));
        }
        private void OnCurrentModalChanged()
        {
            OnPropertychanged(nameof(CurrentModal));
            OnPropertychanged(nameof(IsOpen));
        }
    }
}

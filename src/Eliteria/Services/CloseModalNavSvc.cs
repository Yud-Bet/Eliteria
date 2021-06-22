namespace Eliteria.Services
{
    class CloseModalNavSvc: INavigationService
    {
        private Stores.NavigationStore navigationStore;

        public CloseModalNavSvc(Stores.NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }

        public void Navigate()
        {
            navigationStore.Close();
        }
    }
}

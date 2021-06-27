using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.Command
{
    class OnDoubleClickOnStaffCMD : BaseCommand
    {
        private ICommand navigateStaffInfoCMD;
        private ViewModels.StaffsViewModel viewModel;
        private Stores.NavigationStore _homeNavStore;
        private Stores.AccountStore _accountStore;

        public OnDoubleClickOnStaffCMD(ViewModels.StaffsViewModel viewModel, Stores.NavigationStore _homeNavStore)
        {
            this.viewModel = viewModel;
            this._homeNavStore = _homeNavStore;
        }

        public override void Execute(object parameter)
        {
            _accountStore = new Stores.AccountStore
            {
                CurrentAccount = (Models.Account)parameter
            };
            navigateStaffInfoCMD = new NavigateCMD(CreateStaffInfoNavSvc());
            navigateStaffInfoCMD?.Execute(null);
        }

        private Services.INavigationService CreateStaffInfoNavSvc()
        {
            return new Services.ModalNavigationService<ViewModels.StaffInfoViewModel>(_homeNavStore, () => new ViewModels.StaffInfoViewModel(_homeNavStore, _accountStore));
        }
    }
}

using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.Command
{
    class OpenModifyStaffInfoViewCMD : BaseCommand
    {
        private ViewModels.StaffsViewModel viewModel;
        private ICommand NavigateModifyStaffInfoCMD;
        private Stores.NavigationStore _homeNavStore;
        private Stores.AccountStore account;

        public OpenModifyStaffInfoViewCMD(ViewModels.StaffsViewModel viewModel, Stores.NavigationStore _homeNavStore, Stores.AccountStore account)
        {
            this.viewModel = viewModel;
            this.viewModel.OnSelectedItemChange += OnCanExecuteChanged;
            this._homeNavStore = _homeNavStore;
            this.account = account;
        }

        public override bool CanExecute(object parameter)
        {
            return viewModel.SelectedStaffIndex > -1;
        }

        public override void Execute(object parameter)
        {
            NavigateModifyStaffInfoCMD = new NavigateCMD(CreateModifyStaffNavSvc());
            NavigateModifyStaffInfoCMD?.Execute(null);
        }

        private Services.INavigationService CreateModifyStaffNavSvc()
        {
            return new Services.ModalNavigationService<ViewModels.ModifyStaffInforViewModel>(_homeNavStore, () => new ViewModels.ModifyStaffInforViewModel(_homeNavStore, viewModel, account));
        }
    }
}

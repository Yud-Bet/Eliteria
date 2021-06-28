using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.Command
{
    class OpenModifyStaffInfoViewCMD : BaseCommandAsync
    {
        private ViewModels.StaffsViewModel viewModel;
        private ICommand NavigateModifyStaffInfoCMD;
        private Stores.NavigationStore _homeNavStore;

        public OpenModifyStaffInfoViewCMD(ViewModels.StaffsViewModel viewModel, Stores.NavigationStore _homeNavStore)
        {
            this.viewModel = viewModel;
            this.viewModel.OnSelectedItemChange += OnCanExecuteChange;
            this._homeNavStore = _homeNavStore;
        }

        public override bool CanExecute(object parameter)
        {
            return viewModel.SelectedSavingsIndex > -1;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            NavigateModifyStaffInfoCMD = new NavigateCMD(CreateModifyStaffNavSvc());
            NavigateModifyStaffInfoCMD?.Execute(null);
        }

        private Services.INavigationService CreateModifyStaffNavSvc()
        {
            return new Services.ModalNavigationService<ViewModels.ModifyStaffInforViewModel>(_homeNavStore, () => new ViewModels.ModifyStaffInforViewModel(_homeNavStore, viewModel));
        }
    }
}

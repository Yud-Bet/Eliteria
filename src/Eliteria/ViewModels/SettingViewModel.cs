using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class SettingViewModel : BaseViewModel
    {
        private Stores.NavigationStore navigationStore = new Stores.NavigationStore();
        private Stores.NavigationStore homeNavigationStore;
        private Stores.AccountStore account;

        public BaseViewModel currentViewModel => navigationStore.CurrentViewModel;
        public SettingViewModel(Stores.NavigationStore homeNavigationStore, Stores.AccountStore account)
        {
            this.homeNavigationStore = homeNavigationStore;
            this.account = account;
            navigationStore.CurrentViewModel = new SavingTypeViewModel(this.homeNavigationStore, navigationStore);
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            navigateSavingTypeCMD = new Command.NavigateCMD(CreateSavingTypeNavSvc());
            navigateOtherParametersCMD = new Command.NavigateCMD(CreateOtherParametersNavSvc());
            navigateStaffsCMD = new Command.NavigateCMD(CreateStaffsNavSvc());
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertychanged(nameof(currentViewModel));
        }
        public ICommand navigateSavingTypeCMD { get; }
        public ICommand navigateOtherParametersCMD { get; }
        public ICommand navigateStaffsCMD { get; }

        private Services.INavigationService CreateSavingTypeNavSvc()
        {
            return new Services.NavigationService<SavingTypeViewModel>(navigationStore, () => new SavingTypeViewModel(homeNavigationStore, navigationStore));
        }
        private Services.INavigationService CreateOtherParametersNavSvc()
        {
            return new Services.NavigationService<OtherParameterViewModel>(navigationStore, () => new OtherParameterViewModel(homeNavigationStore));
        }
        private Services.INavigationService CreateStaffsNavSvc()
        {
            return new Services.NavigationService<StaffsViewModel>(navigationStore, () => new StaffsViewModel(homeNavigationStore, account));
        }
    }
}

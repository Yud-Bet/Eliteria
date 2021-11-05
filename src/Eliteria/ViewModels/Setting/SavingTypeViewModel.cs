using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    public class SavingTypeViewModel : BaseViewModel
    {
        public Stores.NavigationStore homeNavigationStore;
        public Stores.NavigationStore navigationStore;
        public ICommand OnLoadCommand { get; set; }
        public ICommand NavigateAddNewSavingTypeCMD { get; set; }
        public ICommand ShowSelectedSavingTypeCMD { get; set; }
        public SavingTypeViewModel(Stores.NavigationStore homeNavigationStore, Stores.NavigationStore navigationStore)
        {
            this.homeNavigationStore = homeNavigationStore;
            this.navigationStore = navigationStore;
            this.NavigateAddNewSavingTypeCMD = new Command.NavigateCMD(CreateAddNewSavingTypeNavSvc());
            this.ShowSelectedSavingTypeCMD = new Command.ShowSelectedSavingTypeCMD(this.homeNavigationStore, this);
            this.OnLoadCommand = new Command.SavingTypeOnLoadCommand(this);
        }
        private ObservableCollection<Models.SavingType> savingTypes = new ObservableCollection<Models.SavingType>();
        private bool _isLoading = false;
        private bool _isLoadingError = false;

        public ObservableCollection<Models.SavingType> SavingTypes
        {
            get => savingTypes;
            set
            {
                savingTypes = value;
                OnPropertychanged(nameof(savingTypes));
            }
        }
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertychanged(nameof(IsLoading));
            }
        }
        public bool IsLoadingError
        {
            get => _isLoadingError;
            set
            {
                _isLoadingError = value;
                OnPropertychanged(nameof(IsLoadingError));
            }
        }
        private Services.INavigationService CreateAddNewSavingTypeNavSvc()
        {
            return new Services.ModalNavigationService<AddNewSavingTypeViewModel>(this.homeNavigationStore, () => new AddNewSavingTypeViewModel(this.homeNavigationStore, this));
        }
    }
}

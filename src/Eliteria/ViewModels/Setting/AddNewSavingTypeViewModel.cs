using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Eliteria.ViewModels
{
    public class AddNewSavingTypeViewModel : BaseViewModel
    {
        public Models.SavingType newSavingType { get; set; }
        public ObservableCollection<string> WithdrawalRules { get; }
        public ICommand CloseCMD { get; }
        public ICommand AddNewSavingTypeCMD { get; }
        private string _errorStatus;
        public string ErrorStatus
        {
            get => _errorStatus;
            set
            {
                _errorStatus = value;
                OnPropertyChanged(nameof(ErrorStatus));
            }
        }
        private System.Windows.Media.Brush _errorColor;
        public System.Windows.Media.Brush ErrorColor
        {
            get => _errorColor;
            set
            {
                _errorColor = value;
                OnPropertyChanged(nameof(ErrorColor));
            }
        }
        public AddNewSavingTypeViewModel(Stores.NavigationStore homeNavigationStore, ViewModels.SavingTypeViewModel savingTypeViewModel)
        {
            
            CloseCMD = new Command.NavigateCMD(new Services.CloseModalNavSvc(homeNavigationStore));
            WithdrawalRules = new ObservableCollection<string> { "=", "<=" };
            newSavingType = new Models.SavingType();
            AddNewSavingTypeCMD = new Command.AddNewSavingTypeCommand(newSavingType, homeNavigationStore, this, savingTypeViewModel);
        }
    }
}

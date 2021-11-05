using Eliteria.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    public class EditSavingTypeViewModel : BaseViewModel 
    {
        public ViewModels.SavingTypeViewModel SavingTypeViewModel { get; set; }
        public Stores.NavigationStore homeNavigationStore;
        public Models.SavingType SavingType { get; set; }
        public ICommand CloseCMD { get; }
        public ICommand EditCMD { get; set; }
        public string minNumOfDateToWithdraw;
        public string interestRate;
        public EditSavingTypeViewModel(Models.SavingType savingType, Stores.NavigationStore homeNavigationStore, ViewModels.SavingTypeViewModel savingTypeViewModel)
        {
            this.homeNavigationStore = homeNavigationStore;
            this.SavingType = savingType;
            this.CloseCMD = new Command.NavigateCMD(new Services.CloseModalNavSvc(homeNavigationStore));
            this.minNumOfDateToWithdraw = savingType.MinNumOfDateToWithdraw.ToString();
            this.interestRate = savingType.InterestRate.ToString();
            this.EditCMD = new Command.EditSavingTypeCommand(this, homeNavigationStore);
            this.SavingTypeViewModel = savingTypeViewModel;
        }
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
        public string MinNumOfDateToWithdraw
        {
            get { return minNumOfDateToWithdraw; }
            set 
            { 
                minNumOfDateToWithdraw = value;
                OnPropertyChanged(nameof(MinNumOfDateToWithdraw));
            }
        }
        public string InterestRate
        {
            get { return interestRate; }
            set 
            { 
                interestRate = value;
                OnPropertyChanged(nameof(InterestRate));            
            }
        }


    }
}

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
    class EditSavingTypeViewModel : BaseViewModel 
    {
        public ViewModels.SavingTypeViewModel SavingTypeViewModel { get; set; }
        public Stores.NavigationStore homeNavigationStore;
        public Models.SavingType SavingType { get; set; }
        public ICommand CloseCMD { get; }
        public ICommand EditCMD { get; set; }
        public int minNumOfDateToWithdraw;
        public float interestRate;
        public EditSavingTypeViewModel(Models.SavingType savingType, Stores.NavigationStore homeNavigationStore, ViewModels.SavingTypeViewModel savingTypeViewModel)
        {
            this.SavingType = savingType;
            this.CloseCMD = new Command.NavigateCMD(new Services.CloseModalNavSvc(homeNavigationStore));
            this.minNumOfDateToWithdraw = savingType.MinNumOfDateToWithdraw;
            this.interestRate = savingType.InterestRate;
            this.EditCMD = new Command.EditSavingTypeCommand(this, homeNavigationStore);
            this.SavingTypeViewModel = savingTypeViewModel;
        }

        public int MinNumOfDateToWithdraw
        {
            get { return minNumOfDateToWithdraw; }
            set 
            { 
                minNumOfDateToWithdraw = value;
                OnPropertyChanged(nameof(MinNumOfDateToWithdraw));
            }
        }
        public float InterestRate
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

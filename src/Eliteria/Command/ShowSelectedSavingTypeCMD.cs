using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class ShowSelectedSavingTypeCMD : BaseCommand
    {
        ViewModels.SavingTypeViewModel SavingTypeViewModel;
        Stores.NavigationStore homeNavStore;
        public ShowSelectedSavingTypeCMD(Stores.NavigationStore homeNavStore, ViewModels.SavingTypeViewModel savingTypeViewModel)
        {
            this.homeNavStore = homeNavStore;
            this.SavingTypeViewModel = savingTypeViewModel;
        }
        public override void Execute(object parameter)
        {
            Models.SavingType savingType = (Models.SavingType)parameter;
            (new Command.NavigateCMD(new Services.ModalNavigationService<ViewModels.EditSavingTypeViewModel>(this.homeNavStore,
                () => new ViewModels.EditSavingTypeViewModel(savingType, this.homeNavStore,SavingTypeViewModel)))).Execute(null);
        }
    }
}

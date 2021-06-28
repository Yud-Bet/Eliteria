using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class ShowSelectedSavingTypeCMD : BaseCommand
    {
        Stores.NavigationStore homeNavStore;
        public ShowSelectedSavingTypeCMD(Stores.NavigationStore homeNavStore)
        {
            this.homeNavStore = homeNavStore;
        }
        public override void Execute(object parameter)
        {
            Models.SavingType savingType = (Models.SavingType)parameter;
            (new Command.NavigateCMD(new Services.ModalNavigationService<ViewModels.EditSavingTypeViewModel>(this.homeNavStore,
                () => new ViewModels.EditSavingTypeViewModel(savingType, this.homeNavStore)))).Execute(null);
        }
    }
}

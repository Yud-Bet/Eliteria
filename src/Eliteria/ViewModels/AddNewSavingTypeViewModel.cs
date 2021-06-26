using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class AddNewSavingTypeViewModel : BaseViewModel
    {
        public ICommand CloseCMD { get; }
        public AddNewSavingTypeViewModel(Stores.NavigationStore homeNavigationStore)
        {
            CloseCMD = new Command.NavigateCMD(new Services.CloseModalNavSvc(homeNavigationStore));
        }
    }
}

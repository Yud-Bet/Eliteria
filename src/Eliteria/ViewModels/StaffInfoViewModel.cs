using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class StaffInfoViewModel : BaseViewModel
    {
        public ICommand CloseCMD { get; }
        public Stores.AccountStore AccountStore { get; set; }
        public string BirthDate { get; set; }
        public StaffInfoViewModel(Stores.NavigationStore navigationStore, Stores.AccountStore accountStore)
        {
            CloseCMD = new Command.NavigateCMD(new Services.CloseModalNavSvc(navigationStore));
            this.AccountStore = accountStore;
            BirthDate = AccountStore.CurrentAccount.Birthdate.ToShortDateString();
        }
    }
}

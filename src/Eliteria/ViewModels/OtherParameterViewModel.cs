using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class OtherParameterViewModel : BaseViewModel
    {
        public Stores.NavigationStore _homeNavigationStore;
        public ICommand OnLoadCMD { get; set; }
        public ICommand EditParameterCMD { get; set; }
        public OtherParameterViewModel(Stores.NavigationStore homeNavigationStore)
        {
            _homeNavigationStore = homeNavigationStore;
            OnLoadCMD = new Command.OtherParametersOnLoadCMD(this);
            EditParameterCMD = new Command.EditOtherParametersCMD(this, _homeNavigationStore);
        }

        private Models.OtherParameter otherParameter;

        public Models.OtherParameter OtherParameter
        {
            get { return otherParameter; }
            set 
            { 
                otherParameter = value;
                OnPropertyChanged(nameof(OtherParameter));
            }
        }

    }
}

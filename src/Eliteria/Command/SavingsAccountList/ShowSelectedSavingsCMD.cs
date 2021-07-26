﻿
using Eliteria.DataAccess.Models;
using Eliteria.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.Command
{
    class ShowSelectedSavingsCMD : BaseCommand
    {
        private ICommand NavCommand;

        public ShowSelectedSavingsCMD(NavigationStore homeNavStore)
        {
            _homeNavStore = homeNavStore;
        }

        private Stores.NavigationStore _homeNavStore;
        public override void Execute(object parameter)
        {
            SavingsAccount savingsAccount = (SavingsAccount)parameter;
            NavCommand = new Command.NavigateCMD(new Services.ModalNavigationService<ViewModels.ASavingsProfileViewModel>(_homeNavStore, () => new ViewModels.ASavingsProfileViewModel(savingsAccount,_homeNavStore)));
            NavCommand.Execute(null);
        }
    }
}

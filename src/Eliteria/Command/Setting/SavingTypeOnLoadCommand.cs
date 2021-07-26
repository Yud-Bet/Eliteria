
using Eliteria.DataAccess.Models;
using Eliteria.DataAccess.Modules.SettingModules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class SavingTypeOnLoadCommand : BaseCommandAsync
    {
        ViewModels.SavingTypeViewModel viewModel;
        public SavingTypeOnLoadCommand(ViewModels.SavingTypeViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public async override Task ExecuteAsync(object parameter)
        {
            viewModel.IsLoading = true;
            viewModel.SavingTypes = new ObservableCollection<SavingType>( await SavingTypesM.GetSavingTypes().ContinueWith(OnQueryFinished));
            viewModel.IsLoading = false;
        }

        private IEnumerable<SavingType> OnQueryFinished(Task<IEnumerable<SavingType>> arg)
        {
            if (arg.IsFaulted)
            {
                viewModel.IsLoadingError = true;
                return null;
            }
            return arg.Result;
        }
    }
}

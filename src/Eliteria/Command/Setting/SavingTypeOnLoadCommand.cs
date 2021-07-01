using Eliteria.Models;
using System;
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
            viewModel.SavingTypes = await DataAccess.DALoadSavingTypeData.Load().ContinueWith(OnQueryFinished);
            viewModel.IsLoading = false;
        }

        private ObservableCollection<SavingType> OnQueryFinished(Task<ObservableCollection<SavingType>> arg)
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

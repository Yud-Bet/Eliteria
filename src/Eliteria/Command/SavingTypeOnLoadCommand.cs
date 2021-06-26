using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.Command
{
    class SavingTypeOnLoadCommand : BaseCommand
    {
        ViewModels.SavingTypeViewModel viewModel;
        public SavingTypeOnLoadCommand(ViewModels.SavingTypeViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public async override void Execute(object parameter)
        {
            viewModel.SavingTypes = await DataAccess.DALoadSavingTypeData.Load();
        }
    }
}

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Eliteria.Models;
using Eliteria.ViewModels;

namespace Eliteria.Command
{
    class CreateNewSavingsAccountOnloadCMD : BaseCommand
    {
        private readonly AddNewSavingViewModel _addNewSavingViewModel;

        public CreateNewSavingsAccountOnloadCMD(AddNewSavingViewModel addNewSavingViewModel)
        {
            _addNewSavingViewModel = addNewSavingViewModel;
        }

        public  async override void Execute(object parameter)
        {
            _addNewSavingViewModel.IsLoading = true;
            _addNewSavingViewModel.MinInitMoney = await DataAccess.DACreateNewSavings.GetMinInitMoney().ContinueWith(OnLoadingMinInitMoneyFinished);
            _addNewSavingViewModel.SavingsTypeList = await DataAccess.DASavingsType.Load().ContinueWith(OnLoadingSavingTypeListFinished);
            _addNewSavingViewModel.SavingsAccountsList = new ObservableCollection<SavingsAccount>();
            
             await DataAccess.DAGetCustomerList.DAGetCustomerDetailList(_addNewSavingViewModel.SavingsAccountsList).ContinueWith(OnLoadingCustomerDetailListFinished);
            _addNewSavingViewModel.IsLoading = false;
        }

        private void OnLoadingCustomerDetailListFinished(Task obj)
        {
            if (obj.IsFaulted)
            {
                _addNewSavingViewModel.IsLoadingError = true;
            }
        }

        private List<string> OnLoadingSavingTypeListFinished(Task<List<string>> arg)
        {
            if (arg.IsFaulted)
            {
                _addNewSavingViewModel.IsLoadingError = true;
                return null;
            }
            return arg.Result;
        }

        private decimal OnLoadingMinInitMoneyFinished(Task<decimal> arg)
        {
            if (arg.IsFaulted)
            {
                _addNewSavingViewModel.IsLoadingError = true;
                return 0;
            }
            return arg.Result;
        }
    }
}

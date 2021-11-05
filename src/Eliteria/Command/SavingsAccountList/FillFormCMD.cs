using Eliteria.ViewModels;

namespace Eliteria.Command
{
    class FillFormCMD : BaseCommand
    {
        private readonly AddNewSavingViewModel _addNewSavingViewModel;

        public FillFormCMD(AddNewSavingViewModel addNewSavingViewModel)
        {
            _addNewSavingViewModel = addNewSavingViewModel;
        }

        public override void Execute(object parameter)
        {
            if(_addNewSavingViewModel.SelectedSavingsAccount!=null)
            {
                _addNewSavingViewModel.OwnerName = _addNewSavingViewModel.SelectedSavingsAccount.Name;
                _addNewSavingViewModel.DoB = _addNewSavingViewModel.SelectedSavingsAccount.DoB;
                _addNewSavingViewModel.OwnerAddress = _addNewSavingViewModel.SelectedSavingsAccount.Address;
                _addNewSavingViewModel.Email = _addNewSavingViewModel.SelectedSavingsAccount.Email;
                _addNewSavingViewModel.PhoneNumber = _addNewSavingViewModel.SelectedSavingsAccount.Phonenumber;
                _addNewSavingViewModel.Gender = _addNewSavingViewModel.SelectedSavingsAccount.Gender;
            }
      


        }
    }
}

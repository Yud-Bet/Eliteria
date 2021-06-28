﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

            _addNewSavingViewModel.SavingsTypeList = await DataAccess.DASavingsType.Load();
            _addNewSavingViewModel.SavingsAccountsList = new ObservableCollection<SavingsAccount>();
            
             await DataAccess.DAGetCustomerList.DAGetCustomerDetailList(_addNewSavingViewModel.SavingsAccountsList);
        }
    }
}

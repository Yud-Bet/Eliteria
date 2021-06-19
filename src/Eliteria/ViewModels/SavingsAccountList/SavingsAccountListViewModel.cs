using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class SavingsAccountListViewModel: BaseViewModel
    {
        private ObservableCollection<Models.Saving> _SavingList;
        public ObservableCollection<Models.Saving> SavingList { get => _SavingList; set { _SavingList = value; } }
        public SavingsAccountListViewModel()
        {
            LoadSavingsData();
        }

        public ICommand AddButtonCommand;

        void LoadSavingsData()
        {
            SavingList = new ObservableCollection<Models.Saving>();
            foreach (var item in DataProvider.Ins.DB.SOTIETKIEMs)
            {
                Saving savingItem = new Saving();
                savingItem.saving = item;
                savingItem.customer = DataProvider.Ins.DB.KHACHHANGs.Where(c => c.MaKH == item.MaKH).First();
                savingItem.savingType = DataProvider.Ins.DB.LOAISOTIETKIEMs.Where(s => s.MaLoaiSTK == item.MaLoaiSTK).First();
                SavingList.Add(savingItem);
            }
        }
    }
}

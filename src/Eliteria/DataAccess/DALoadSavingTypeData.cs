using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    public static class DALoadSavingTypeData
    {
        public static async Task<ObservableCollection<Models.SavingType>> Load()
        {
            var res = new ObservableCollection<Models.SavingType>();
            DataTable data = await ExecuteQuery.ExecuteReaderAsync("Eliteria_LoadSavingType");
            if (data.Rows.Count > 0)
                for(int i=0; i<data.Rows.Count; i++)
                {
                    res.Add(new Models.SavingType
                    {
                        ID = (int)data.Rows[i][0],
                        Name = (string)data.Rows[i][1],
                        Period = (int)data.Rows[i][2],
                        InterestRate = (float)data.Rows[i][3],
                        EffectiveDate = (DateTime)data.Rows[i][4],
                        MinNumOfDateToWithdraw = (int)data.Rows[i][5],
                        WithdrawalRule = (string)data.Rows[i][6]
                    });
                }
            return res;
        }
    }
}

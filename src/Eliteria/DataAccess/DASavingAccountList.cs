using Eliteria.Models;
using Eliteria.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    static class DASavingAccountList
    {
        public static async Task<ObservableCollection<SavingsAccount>> LoadListFromDatabase()
        {
            ObservableCollection<SavingsAccount> savingsAccounts = new ObservableCollection<SavingsAccount>();
            string querry = "EXEC GetSavingAccounts";
            DataTable data = await ExecuteQuery.ExecuteReaderAsync(querry);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                SavingsAccount savingsAccount = new SavingsAccount();
                savingsAccount.Name = data.Rows[i][0].ToString();
                savingsAccount.AccountNumber = data.Rows[i][1].ToString();
                savingsAccount.IdentificationNumber = data.Rows[i][2].ToString();
                savingsAccount.Balance = Convert.ToDecimal(data.Rows[i][3]);
                savingsAccount.Type = data.Rows[i][4].ToString();
                savingsAccount.OpenDate = Convert.ToDateTime(data.Rows[i][5]);
                savingsAccount.Address = data.Rows[i][6].ToString();
                savingsAccounts.Add(savingsAccount);
            }
            return savingsAccounts;
        }
    }
}

using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    class DASavingAccountList
    {       
        public  async void LoadListFromDatabase( ObservableCollection<SavingsAccount> savingsAccounts)
        {            
            string querry = "EXEC GetSavingAccounts";
            DataTable data = await ExecuteQuery.ExecuteReaderAsync(querry);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                SavingsAccount savingsAccount = new SavingsAccount();
                savingsAccount.Name = data.Rows[i][0].ToString();
                savingsAccount.AccountNumber = data.Rows[i][2].ToString();
                savingsAccount.IdentificationNumber = data.Rows[i][3].ToString();
                savingsAccount.Balance = Convert.ToDecimal(data.Rows[i][3]);
                savingsAccount.Type = data.Rows[i][4].ToString();
                savingsAccounts.Add(savingsAccount);
            }
        }
    }
}

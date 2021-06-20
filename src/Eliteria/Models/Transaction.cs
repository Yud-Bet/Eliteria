using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.Models
{
    public class Transaction
    {
        public int idTransaction;
        public int idTransactionType;
        public int idSaving;
        public int idStaff;
        public DateTime transactionDate;
        public int transactionMoney;

        public static async Task<DataTable> GetAllSaving()
        {
            DataTable data = await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllSaving");
            return data;
        }
        public static async Task<DataTable> GetSavingIf(int idSaving )
        {
            return await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllSavingIf @MaSTK", new object[] { idSaving });
        }
        public static async Task<DataTable> GetAllCustomer()
        {
            return await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllCustomer");
        }
        public static async Task<DataTable> GetCustomerIf(int idCustomer)
        {
            return await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllCustomerIf @MaKH", new object[] { idCustomer});
        }
        public static async Task<DataTable> GetAllParameters()
        {
            return await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllParameters");
        }

    }
}

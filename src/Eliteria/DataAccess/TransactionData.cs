using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    public static class TransactionData
    {
        public static async Task<DataTable> GetAllSaving()
        {
            DataTable data = await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllSaving");
            return data;
        }
        public static async Task<DataTable> GetSavingIf(int idSaving)
        {
            return await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_GetSavingIf @MaSTK", new object[] { idSaving });
        }
        public static async Task<DataTable> GetAllCustomer()
        {
            return await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllCustomer");
        }
        public static async Task<DataTable> GetCustomerIf(int idCustomer)
        {
            return await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_GetCustomerIf @MaKH", new object[] { idCustomer });
        }
        public static async Task<DataTable> GetAllParameters()
        {
            return await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllParameters");
        }
        public static async Task<int> InsertNewTransaction(int idTransactionType, int idSaving, int idSatff, DateTime transactionDate, decimal money)
        {
            return await DataAccess.ExecuteQuery.ExecuteNoneQueryAsync("Eliteria_InsertNewTransaction @MaLoaiGD , @MaSTK , @MaNV , @Ngay , @SoTien", new object[] { idTransactionType, idSaving, idSatff, transactionDate, money });
        }
        public static async Task<int> ControlCloseSaving()
        {
            return await DataAccess.ExecuteQuery.ExecuteNoneQueryAsync("Eliteria_ControlCloseSaving");
        }
        public static async Task<int> AutomaticCalculateInterest()
        {
            return await DataAccess.ExecuteQuery.ExecuteNoneQueryAsync("Eliteria_AutomaticCalculateInterest");
        }
        public static async Task<int> CalculatePreMaturityInterest(int idSaving)
        {
            return await DataAccess.ExecuteQuery.ExecuteNoneQueryAsync("Eliteria_CalculatePreMaturityInterest @MaSTK", new object[] { idSaving});
        }
    }
}
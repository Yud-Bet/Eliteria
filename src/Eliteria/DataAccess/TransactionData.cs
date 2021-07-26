using Eliteria.DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    public static class TransactionData
    {
        public static async Task<ObservableCollection<SavingsAccount>> GetAllSaving()
        {
            ObservableCollection<SavingsAccount> ret = new ObservableCollection<SavingsAccount>();
            DataTable data = await ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllSaving");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                SavingsAccount item = new SavingsAccount();
                item.AccountNumber = Convert.ToString(data.Rows[i].ItemArray[0]);
                item.Name = Convert.ToString(data.Rows[i].ItemArray[1]);
                item.Balance = Convert.ToDecimal(data.Rows[i].ItemArray[2]);
                item.NextDueDate = Convert.ToDateTime(data.Rows[i].ItemArray[3]);
                item.PrescribedAmountDrawn = Convert.ToString(data.Rows[i].ItemArray[4]);
                item.BeforeDueDate = Convert.ToDateTime(data.Rows[i].ItemArray[5]);
                item.OpenDate = Convert.ToDateTime(data.Rows[i].ItemArray[6]);
                item.IdSavingType = Convert.ToInt32(data.Rows[i].ItemArray[7]);
                item.MinDaysToWithdrawn = Convert.ToInt32(data.Rows[i].ItemArray[8]);
                item.Interest = Convert.ToInt32(data.Rows[i].ItemArray[9]);
                //item.Status = Convert.ToBoolean(savingList.Rows[i].ItemArray[10]);

                //if (savingList.Rows[i].ItemArray[11] != null)
                //    item.closeDateSaving = Convert.ToDateTime(savingList.Rows[i].ItemArray[11]);

                ret.Add(item);
            }
            return ret;
        }
        public static async Task<int> LastTransactionID()
        {
            DataTable data = await ExecuteQuery.ExecuteReaderAsync("Eliteria_LastTransactionID");
            if (data.Rows.Count <= 0) return -1;
            int id = (int)data.Rows[0][0];
            return id;
        }
        public static async Task<SavingsAccount> GetSavingIf(int idSaving)
        {
            DataTable data = await ExecuteQuery.ExecuteReaderAsync("Eliteria_GetSavingIf @MaSTK", new object[] { idSaving });
            return new SavingsAccount
            {
                AccountNumber = Convert.ToString(data.Rows[0].ItemArray[0]),
                Name = Convert.ToString(data.Rows[0].ItemArray[1]),
                Balance = Convert.ToDecimal(data.Rows[0].ItemArray[2]),
                NextDueDate = Convert.ToDateTime(data.Rows[0].ItemArray[3]),
                PrescribedAmountDrawn = Convert.ToString(data.Rows[0].ItemArray[4]),
                BeforeDueDate = Convert.ToDateTime(data.Rows[0].ItemArray[5]),
                OpenDate = Convert.ToDateTime(data.Rows[0].ItemArray[6]),
                IdSavingType = Convert.ToInt32(data.Rows[0].ItemArray[7]),
                MinDaysToWithdrawn = Convert.ToInt32(data.Rows[0].ItemArray[8]),
                Interest = Convert.ToInt32(data.Rows[0].ItemArray[9])
            };
        }
        public static async Task<DataTable> GetAllCustomer()
        {
            return await ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllCustomer");
        }
        public static async Task<DataTable> GetCustomerIf(int idCustomer)
        {
            return await ExecuteQuery.ExecuteReaderAsync("Eliteria_GetCustomerIf @MaKH", new object[] { idCustomer });
        }
        public static async Task<DataTable> GetAllParameters()
        {
            return await ExecuteQuery.ExecuteReaderAsync("Eliteria_GetAllParameters");
        }
        public static async Task<int> InsertNewTransaction(int idTransactionType, int idSaving, int idSatff, DateTime transactionDate, decimal money)
        {
            return await ExecuteQuery.ExecuteNoneQueryAsync("Eliteria_InsertNewTransaction @MaLoaiGD , @MaSTK , @MaNV , @Ngay , @SoTien", new object[] { idTransactionType, idSaving, idSatff, transactionDate, money });
        }
        public static async Task<int> ControlCloseSaving()
        {
            return await ExecuteQuery.ExecuteNoneQueryAsync("Eliteria_ControlCloseSaving");
        }
        public static async Task<int> AutomaticCalculateInterest()
        {
            return await ExecuteQuery.ExecuteNoneQueryAsync("Eliteria_AutomaticCalculateInterest");
        }
        public static async Task<decimal> CalculatePreMaturityInterest(int idSaving)
        {
            DataTable data = await ExecuteQuery.ExecuteReaderAsync("Eliteria_CalculatePreMaturityInterest @MaSTK", new object[] { idSaving });
            if (data.Rows.Count > 0) return (decimal)data.Rows[0].ItemArray[0];
            else return -1;
        }
        public static async Task<int> WithdrawInterest(int idSaving)
        {
            return await ExecuteQuery.ExecuteNoneQueryAsync("Eliteria_WithdrawInterest @MaSTK", new object[] { idSaving });
        }

    }
}
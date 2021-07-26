using Dapper;
using Eliteria.API.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public class MoneyTransactionProvider : IMoneyTransactionProvider
    {
        public async Task<int> AutomaticCalculateInterest(string conn)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                int affectedRows = await sqlConnection.ExecuteAsync("Eliteria_AutomaticCalculateInterest", commandType: CommandType.StoredProcedure);
                return affectedRows;
            }
        }

        public async Task<decimal> CalculatePreMaturityInterest(string conn, int idSaving)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@MaSTK", idSaving);
                decimal transAmount = (await sqlConnection.QueryAsync<decimal>("Eliteria_CalculatePreMaturityInterest", param, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return transAmount;
            }
        }

        public async Task<int> ControlCloseSavings(string conn)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                int affectedRows = await sqlConnection.ExecuteAsync("Eliteria_ControlCloseSaving", commandType: CommandType.StoredProcedure);
                return affectedRows;
            }
        }

        public async Task<List<SavingsAccount>> GetAllSavings(string conn)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                var model = await sqlConnection.QueryAsync<SavingsAccount>("Eliteria_GetAllSaving", commandType: CommandType.StoredProcedure);
                return model.ToList();
            }
        }

        public async Task<int> GetLastTransactionID(string conn)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                int transID = (await sqlConnection.QueryAsync<int>("Eliteria_LastTransactionID", commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return transID;
            }
        }

        public async Task<SavingsAccount> GetSavingIf(string conn, int idSaving)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@MaSTK", idSaving);
                var savingsAccount = (await sqlConnection.QueryAsync<SavingsAccount>("Eliteria_GetSavingIf", param, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return savingsAccount;
            }
        }

        public async Task<int> InsertNewTransaction(string conn, TransactionSlipData transaction)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@MaLoaiGD", transaction.TransactionTypeID);
                param.Add("@MaSTK", transaction.SavingsID);
                param.Add("@MaNV", transaction.StaffID);
                param.Add("@Ngay", transaction.TransactionDate);
                param.Add("@SoTien", transaction.Amount);
                var affectedRows = await sqlConnection.ExecuteAsync("Eliteria_InsertNewTransaction", param, commandType: CommandType.StoredProcedure);
                return affectedRows;
            }
        }

        public async Task<int> WithdrawInterest(string conn, int idSaving)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                var param = new DynamicParameters();
                param.Add("@MaSTK", idSaving);
                var affectedRows = await sqlConnection.ExecuteAsync("Eliteria_WithdrawInterest", param, commandType: CommandType.StoredProcedure);
                return affectedRows;
            }
        }
    }
}

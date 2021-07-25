using Dapper;
using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                int affectedRows = sqlConnection.Execute("Eliteria_AutomaticCalculateInterest", commandType: CommandType.StoredProcedure);
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
                decimal transAmount = sqlConnection.Query<decimal>("Eliteria_CalculatePreMaturityInterest", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return transAmount;
            }
        }

        public async Task<int> ControlCloseSavings(string conn)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                int affectedRows = sqlConnection.Execute("Eliteria_ControlCloseSaving", commandType: CommandType.StoredProcedure);
                return affectedRows;
            }
        }

        public Task<ObservableCollection<SavingsAccount>> GetAllSavings(string conn)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastTransactionID(string conn)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                int transID = sqlConnection.Query<int>("Eliteria_LastTransactionID", commandType: CommandType.StoredProcedure).FirstOrDefault();
                return transID;
            }
        }

        public Task<SavingsAccount> GetSavingIf(string conn, int idSaving)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertNewTransaction(string conn, int idTransactionType, int idSaving, int idSatff, DateTime transactionDate, decimal money)
        {
            throw new NotImplementedException();
        }

        public Task<int> WithdrawInterest(string conn, int idSaving)
        {
            throw new NotImplementedException();
        }
    }
}

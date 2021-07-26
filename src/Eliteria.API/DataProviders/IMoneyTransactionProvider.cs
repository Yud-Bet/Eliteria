using Eliteria.API.Models;
using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface IMoneyTransactionProvider
    {
        Task<List<SavingsAccount>> GetAllSavings(string conn);
        Task<int> GetLastTransactionID(string conn);
        Task<SavingsAccount> GetSavingIf(string conn, int idSaving);
        Task<int> InsertNewTransaction(string conn, TransactionSlipData transaction);
        Task<int> ControlCloseSavings(string conn);
        Task<int> AutomaticCalculateInterest(string conn);
        Task<decimal> CalculatePreMaturityInterest(string conn, int idSaving);
        Task<int> WithdrawInterest(string conn, int idSaving);
    }
}

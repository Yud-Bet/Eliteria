using Eliteria.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface IMoneyTransactionProvider
    {
        Task<ObservableCollection<SavingsAccount>> GetAllSavings(string conn);
        Task<int> GetLastTransactionID(string conn);
        Task<SavingsAccount> GetSavingIf(string conn, int idSaving);
        Task<int> InsertNewTransaction(string conn, int idTransactionType, int idSaving, int idSatff, DateTime transactionDate, decimal money);
        Task<int> ControlCloseSavings(string conn);
        Task<int> AutomaticCalculateInterest(string conn);
        Task<decimal> CalculatePreMaturityInterest(string conn, int idSaving);
        Task<int> WithdrawInterest(string conn, int idSaving);
    }
}

using Eliteria.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface IMoneyTransactionProvider
    {
        Task<ObservableCollection<SavingsAccount>> GetAllSavings();
        Task<int> GetLastTransactionID();
        Task<SavingsAccount> GetSavingIf(int idSaving);
        Task<int> InsertNewTransaction(int idTransactionType, int idSaving, int idSatff, DateTime transactionDate, decimal money);
        Task<int> ControlCloseSavings();
        Task<int> AutomaticCalculateInterest();
        Task<decimal> CalculatePreMaturityInterest(int idSaving);
        Task<int> WithdrawInterest(int idSaving);
    }
}

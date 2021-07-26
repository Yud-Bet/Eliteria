using Eliteria.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface IEmployeesProvider
    {
        Task<IEnumerable<Account>> GetAllAccounts(string conn);
        Task<int> UpdateAccount(string conn, Account account);
        Task<int> InsertAccount(string conn, Account account);
        Task<int> RemoveAccount(string conn, string accountID);
    }
}

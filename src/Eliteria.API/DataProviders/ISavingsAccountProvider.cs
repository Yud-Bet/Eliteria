using Eliteria.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface ISavingsAccountProvider
    {
        Task<List<SavingsAccount>> GetAllSavingsAccount(string conn);
    }
}
using Eliteria.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface ISavingTypeProvider
    {
        Task<int> AddNewSavingType(string conn, SavingType item);
        Task<IEnumerable<SavingType>> GetAllSavingTypes(string conn);
    }
}

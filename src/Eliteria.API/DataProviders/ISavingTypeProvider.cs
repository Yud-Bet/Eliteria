using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eliteria.Models;

namespace Eliteria.API.DataProviders
{
    public interface ISavingTypeProvider
    {
        Task<int> AddNewSavingType(string conn, SavingType item);
        Task<IEnumerable<SavingType>> GetAllSavingTypes(string conn);
    }
}

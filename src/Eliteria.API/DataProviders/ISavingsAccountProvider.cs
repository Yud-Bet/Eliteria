using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface ISavingsAccountProvider
    {
        Task<List<SavingsAccount>> GetAllSavingsAccount(string conn);
    }
}
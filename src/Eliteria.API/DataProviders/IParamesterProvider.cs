using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface IParamesterProvider
    {
        Task<IEnumerable<OtherParameter>> ConfigureParamester(string conn, OtherParameter item);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface ILoginProvider
    {
        public Task<IEnumerable<Models.Account>> Login(string conn, string userName, string pass);
    }
}

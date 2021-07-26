using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Eliteria.API.Models;

namespace Eliteria.API.DataProviders
{
    public class LoginProvider : ILoginProvider
    {
        public async Task<IEnumerable<Account>> Login(string conn, string userName, string pass)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@username", userName);
                parameters.Add("@password", pass);
                return await sqlConnection.QueryAsync<Account>("Eliteria_Login", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}

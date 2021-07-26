using Dapper;
using Eliteria.API.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public class SavingsAccountProvider : ISavingsAccountProvider
    {
        public async Task<List<SavingsAccount>> GetAllSavingsAccount(string conn)
        {
            using (var sqlConn = new SqlConnection(conn))
            {
                await sqlConn.OpenAsync();
                var model = await sqlConn.QueryAsync<SavingsAccount>("Eliteria_GetSavingAccounts", commandType: CommandType.StoredProcedure);
                return model.ToList();
            }
        }
    }
}
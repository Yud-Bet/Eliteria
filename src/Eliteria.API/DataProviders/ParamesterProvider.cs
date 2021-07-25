using Dapper;
using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public class ParamesterProvider : IParamesterProvider
    {
        public async Task<IEnumerable<OtherParameter>> ConfigureParamester(string conn, OtherParameter item)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@MinDepositAmount", item.MinDepositAmount);
                parameters.Add("@MinInitialDeposit", item.MinInitialDeposit);
                parameters.Add("@ControlClosingSaving", item.ControlClosingSaving);
               return  await sqlConnection.QueryAsync<OtherParameter>("Eliteria_EditOtherParameters", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

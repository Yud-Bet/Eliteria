using Dapper;
using Eliteria.API.Models;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public class ParamesterProvider : IParamesterProvider
    {
        public async Task<int> ConfigureParamester(string conn, OtherParameter item)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@MinDepositAmount", item.MinDepositAmount);
                parameters.Add("@MinInitialDeposit", item.MinInitialDeposit);
                parameters.Add("@ControlClosingSaving", item.ControlClosingSaving);
                return await sqlConnection.ExecuteAsync("Eliteria_EditOtherParameters", parameters, commandType: CommandType.StoredProcedure);
                
            }
        }
    }
}

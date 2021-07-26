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
    public class SavingTypeProvider : ISavingTypeProvider
    {
        public async Task<int> AddNewSavingType(string conn,SavingType item)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                var parameters = new DynamicParameters();
                parameters.Add("@Name", item.Name);
                parameters.Add("@Period", item.Period);
                parameters.Add("@InterestRate", item.InterestRate);
                parameters.Add("@EffectiveDate", item.EffectiveDate);
                parameters.Add("@MinNumOfDateToWithdraw", item.MinNumOfDateToWithdraw);
                parameters.Add("@WithdrawalRule", item.MinNumOfDateToWithdraw);

                return await sqlConnection.ExecuteAsync("Eliteria_AddNewSavingType",
                    parameters,
                    commandType: CommandType.StoredProcedure);

               
            }
        }

        public async Task<IEnumerable<SavingType>> GetAllSavingTypes(string conn)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                return  await sqlConnection.QueryAsync<SavingType>("Eliteria_LoadSavingType", null, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

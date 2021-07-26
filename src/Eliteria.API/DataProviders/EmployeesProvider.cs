using Dapper;
using Eliteria.API.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public class EmployeesProvider : IEmployeesProvider
    {


        public  async Task<IEnumerable<Account>> GetAllAccounts(string conn)
        {
           using(var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<Account>("Eliteria_LoadAllStaffs",commandType:CommandType.StoredProcedure);
            }
        }

        public async Task<int> RemoveAccount(string conn, string accountID)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                var paramester = new DynamicParameters();
                paramester.Add("@StaffID", accountID);
                await sqlConnection.OpenAsync();
                return await sqlConnection.ExecuteAsync("Eliteria_RemoveStaff", paramester,commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<int> InsertAccount(string conn, Account account)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                var paramester = new DynamicParameters();
                paramester.Add("@Position", account.Position);
                paramester.Add("@Name", account.StaffName);
                paramester.Add("@IdentificationNumber", account.ID);
                paramester.Add("@Gender", account.Sex);
                paramester.Add("@Birthday", account.Birthdate);
                paramester.Add("@PhoneNumber", account.PhoneNum);
                paramester.Add("@Address", account.Address);
                paramester.Add("@Password",account.Password);
                paramester.Add("@Email", account.Password);
                await sqlConnection.OpenAsync();
                return await sqlConnection.ExecuteAsync("Eliteria_AddNewStaff", paramester, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateAccount(string conn, Account account)
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                var parameters = new  DynamicParameters();
                parameters.Add("@StaffId", account.StaffID);
                parameters.Add("@Position", account.Position);
                parameters.Add("@Name", account.StaffName);
                parameters.Add("@PhoneNumber", account.PhoneNum);
                parameters.Add("@Email", account.Email);
                parameters.Add("@Address", account.Address);
                return await sqlConnection.ExecuteAsync("Eliteria_ModifyStaffInfo", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

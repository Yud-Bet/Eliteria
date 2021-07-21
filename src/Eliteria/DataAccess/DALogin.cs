using System;
using System.Data;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    public static class DALogin
    {
        public static async Task<Models.Account> Execute(string Username, string Password)
        {
            DataTable data = await ExecuteQuery.ExecuteReaderAsync("Eliteria_Login @username , @password", new object[] { Username, Password });
            if (data.Rows.Count < 1) return null;
            Models.Account account = new Models.Account()
            {
                StaffID = (int)data.Rows[0][0],
                Email = data.Rows[0][6].ToString(),
                Password = data.Rows[0][2].ToString(),
                StaffName = data.Rows[0][3].ToString(),
                PhoneNum = data.Rows[0][5].ToString(),
                ID = data.Rows[0][4].ToString(),
                Address = data.Rows[0][7].ToString(),
                Sex = (bool)data.Rows[0][8],
                Position = (int)data.Rows[0][1],
                Birthdate = (DateTime)data.Rows[0][9]
            };
            return account;
        }
    }
}

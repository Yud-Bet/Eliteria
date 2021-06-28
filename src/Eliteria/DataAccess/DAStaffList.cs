using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    public static class DAStaffList
    {
        public static async Task<ObservableCollection<Models.Account>> Load()
        {
            ObservableCollection<Models.Account> ret = new ObservableCollection<Models.Account>();
            DataTable data = await ExecuteQuery.ExecuteReaderAsync("Eliteria_LoadAllStaffs");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Models.Account staff = new Models.Account
                {
                    StaffName = data.Rows[i].ItemArray[0].ToString(),
                    Position = (int)data.Rows[i].ItemArray[1],
                    ID = data.Rows[i].ItemArray[2].ToString(),
                    Sex = (bool)data.Rows[i].ItemArray[3],
                    Birthdate = (DateTime)data.Rows[i].ItemArray[4],
                    PhoneNum = data.Rows[i].ItemArray[5].ToString(),
                    Address = data.Rows[i].ItemArray[6].ToString(),
                };
                ret.Add(staff);
            }
            return ret;
        }
        public static async Task<int> CreateNewStaff(int Position, string Name, string IdentificationNumber, bool Gender, DateTime Birthday, string PhoneNumber, string Address, string Password, string Email)
        {
            string query = "Eliteria_AddNewStaff @Position , @Name , @IdentificationNumber , @Gender , @Birthday , @PhoneNumber , @Address , @Password , @Email";
            return await ExecuteQuery.ExecuteNoneQueryAsync(query, new object[] { Position, Name, IdentificationNumber, Gender, Birthday, PhoneNumber, Address, Password, Email});
        }

        public static async Task<int> ModifyStaffInfo(int Position, string Name, string PhoneNumber, string Email, string Address)
        {
            string query = "Eliteria_ModifyStaffInfo @Position , @Name , @PhoneNumber , @Email , @Address";
            return await ExecuteQuery.ExecuteNoneQueryAsync(query, new object[] { Position, Name, PhoneNumber, Email, Address });
        }
    }
}

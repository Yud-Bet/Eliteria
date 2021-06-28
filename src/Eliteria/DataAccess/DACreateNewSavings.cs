using Eliteria.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    public static class DACreateNewSavings
    {
        public static async Task<decimal> GetMinInitMoney()
        {
            decimal MinInit = new decimal();
            string querry = "SELECT SoTienGuiBDToiThieu FROM THAMSO";
            DataTable data = await ExecuteQuery.ExecuteReaderAsync(querry);
            MinInit = Convert.ToDecimal(data.Rows[0][0]);
            return MinInit;
        }
        public static async Task AsNewCustomer(SavingsAccount savingsAccount)
        {
            bool OwnerGender;
           
            if (savingsAccount.Gender == "Nam")
                OwnerGender = true;
            else
                OwnerGender = false;       
            string querry = $"EXEC Eliteria_CreateNewAccountForNewCustomer @tenkh , @cmnd , @diachi , @dienthoai , @email , @gioitinh , @ngaysinh , @loaitk , @ngaymoso , @tongtiendagui";
            await ExecuteQuery.ExecuteNoneQueryAsync(querry, new object[] { savingsAccount.Name, savingsAccount.IdentificationNumber, savingsAccount.Address, savingsAccount.Phonenumber, savingsAccount.Email, OwnerGender, savingsAccount.DoB, savingsAccount.Type, savingsAccount.OpenDate, savingsAccount.Balance });

        }
        public static async Task AsOldCustomer(string ID, string Loaitk, DateTime OpenDate, Decimal Amount)
        {
            string querry = "EXEC Eliteria_CreateNewAccountForOldUser @cmnd , @loaitk , @ngaymoso , @tiengui";
            await ExecuteQuery.ExecuteNoneQueryAsync(querry, new object[] { ID, Loaitk, OpenDate, Amount });           
        }

    }
} 

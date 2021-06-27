using Eliteria.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    class DACreateNewSavings
    {
        public static void GetMinInitMoney(ref Decimal MinInit)
        {
            
            string querry = "SELECT SoTienGuiBDToiThieu FROM THAMSO";
            DataTable data = ExecuteQuery.ExecuteReader(querry);
            MinInit = Convert.ToDecimal(data.Rows[0][0]);
          
        }
        public static void AsNewCustomer(SavingsAccount savingsAccount)
        {
            string OwnerGender;
           
            if (savingsAccount.Gender == "Nam")
                OwnerGender = "1";
            else
                OwnerGender = "0";       
            string querry = $"EXEC Eliteria_CreateNewAccountForNewCustomer @tenkh= N'{savingsAccount.Name}',@cmnd='{savingsAccount.IdentificationNumber}'," +
                $"@diachi=N'{savingsAccount.Address}',@dienthoai = '{savingsAccount.Phonenumber}',@email = '{savingsAccount.Email}',@gioitinh = {OwnerGender},@ngaysinh = '{savingsAccount.DoB.ToString("MM/dd/yyyy")}'," +
                $"@loaitk = N'{savingsAccount.Type}',@ngaymoso = '{savingsAccount.OpenDate.ToString("MM/dd/yyyy")}',@tongtiendagui = {savingsAccount.Balance}";
            ExecuteQuery.ExecuteNoneQuery(querry);

        }
        public static void AsOldCustomer(string ID, string Loaitk, DateTime OpenDate, Decimal Amount)
        {           
            string querry = $"EXEC Eliteria_CreateNewAccountForOldUser @cmnd ='{ID}',@loaitk = N'{Loaitk}',@ngaymoso='{OpenDate.ToString("MM/dd/yyyy")}',@tiengui ={Amount}";
            ExecuteQuery.ExecuteNoneQuery(querry);

        }

    }
}

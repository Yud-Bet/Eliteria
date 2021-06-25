using Eliteria.Models;
using System;

namespace Eliteria.DataAccess
{
    class DACreateNewSavings
    {
        public static void AsNewCustomer(SavingsAccount savingsAccount)
        {
            string OwnerGender;
            int Maloaitk = new int();
            if (savingsAccount.Gender == "Nam")
                OwnerGender = "1";
            else
                OwnerGender = "0";
            switch (savingsAccount.Type)
            {
                case "Không kỳ hạn":
                    Maloaitk = 1;
                    break;
                case "3 tháng":
                    Maloaitk = 2;
                    break;
                case "6 tháng":
                    Maloaitk = 3;
                    break;
            }


            string querry = $"EXEC Eliteria_CreateNewAccountForNewCustomer @tenkh= N'{savingsAccount.Name}',@cmnd='{savingsAccount.IdentificationNumber}'," +
                $"@diachi=N'{savingsAccount.Address}',@dienthoai = '{savingsAccount.Phonenumber}',@email = '{savingsAccount.Email}',@gioitinh = {OwnerGender},@ngaysinh = '{savingsAccount.DoB.ToString("MM/dd/yyyy")}'," +
                $"@maltk = {Maloaitk},@ngaymoso = '{savingsAccount.OpenDate.ToString("MM/dd/yyyy")}',@tongtiendagui = {savingsAccount.Balance}";
            ExecuteQuery.ExecuteNoneQuery(querry);

        }
        public static void AsOldCustomer(string ID, string Loaitk, DateTime OpenDate, Decimal Amount)
        {
            int Maloaitk = new int();
            switch (Loaitk)
            {
                case "Không kỳ hạn":
                    Maloaitk = 1;
                    break;
                case "3 tháng":
                    Maloaitk = 2;
                    break;
                case "6 tháng":
                    Maloaitk = 3;
                    break;
            }
            string querry = $"EXEC Eliteria_CreateNewAccountForOldUser @cmnd ='{ID}',@maltk = '{Maloaitk}',@ngaymoso='{OpenDate.ToString("MM/dd/yyyy")}',@tiengui ={Amount}";
            ExecuteQuery.ExecuteNoneQuery(querry);

        }

    }
}

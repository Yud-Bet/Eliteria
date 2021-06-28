using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    class DAGetCustomerList
    {
        public static async Task DAGetCustomerListIDs(List<string> IDs)
        {
            string querry = "SELECT [CCCD/CMND] FROM KHACHHANG";
            DataTable data = await ExecuteQuery.ExecuteReaderAsync(querry);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                IDs.Add(data.Rows[i][0].ToString());
            }
        }

        public static async Task DAGetCustomerDetailList(ObservableCollection<SavingsAccount> savingsAccounts)
        {
            string querry = "SELECT TenKH,[CCCD/CMND],DiaChi,Email,DienThoai,GioiTinh,NgaySinh FROM KHACHHANG";
            DataTable data = await ExecuteQuery.ExecuteReaderAsync(querry);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                SavingsAccount savingsAccount = new SavingsAccount();
                savingsAccount.Name = data.Rows[i][0].ToString();
                savingsAccount.IdentificationNumber = data.Rows[i][1].ToString();
                savingsAccount.Address = data.Rows[i][2].ToString();
                savingsAccount.Email = data.Rows[i][3].ToString();
                savingsAccount.Phonenumber = data.Rows[i][4].ToString();
                if ((bool)data.Rows[i][5])
                    savingsAccount.Gender = "Nam";
                else
                    savingsAccount.Gender = "Nữ";
                savingsAccount.DoB = Convert.ToDateTime(data.Rows[i][6]);
                savingsAccounts.Add(savingsAccount);
            }
        }
    }
}

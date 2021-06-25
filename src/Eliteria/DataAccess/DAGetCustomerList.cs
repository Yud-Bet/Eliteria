using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    class DAGetCustomerList
    {
        public static async void DAGetCustomerListIDs(List<string> IDs)
        {            
            string querry = "SELECT [CCCD/CMND] FROM KHACHHANG";
            DataTable data = await ExecuteQuery.ExecuteReaderAsync(querry);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                IDs.Add(data.Rows[i][0].ToString());
            }
        }

    }
}

using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    public static class DASavingsType
    {
        public static async Task<List<string>> Load()
        {
            List<string> res = new List<string>();
            DataTable data = await ExecuteQuery.ExecuteReaderAsync("Eliteria_LoadSavingsType");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                res.Add((string)data.Rows[i].ItemArray[0]);
            }
            return res;
        }
    }
}

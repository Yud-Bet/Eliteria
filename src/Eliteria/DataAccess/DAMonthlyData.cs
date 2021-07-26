using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    public static class DAMonthlyData
    {
        public static async Task<List<MonthlyReportItem>> Load()
        {
            var res = new List<MonthlyReportItem>();
            DataTable data = await ExecuteQuery.ExecuteReaderAsync("Eliteria_LoadMonthlyData");
            if (data.Rows.Count == 0) return res;
            string accType = (string)data.Rows[0].ItemArray[0];
            DateTime date = (DateTime)data.Rows[0].ItemArray[1];
            int open = (int)data.Rows[0].ItemArray[2];
            int close = (int)data.Rows[0].ItemArray[3];
            int diff = (int)data.Rows[0].ItemArray[4];
            MonthReport detail = new MonthReport
            {
                Date = date,
                Opened = open,
                Closed = close,
                Different = diff
            };
            res.Add(new MonthlyReportItem { Type = accType, Month = date.Month, Year = date.Year, Details = new List<MonthReport> { detail } });
            for (int i = 1, j = 0; i < data.Rows.Count; i++)
            {
                string _type = (string)data.Rows[i].ItemArray[0];
                DateTime _date = (DateTime)data.Rows[i].ItemArray[1];
                int _open = (int)data.Rows[i].ItemArray[2];
                int _close = (int)data.Rows[i].ItemArray[3];
                int _diff = (int)data.Rows[i].ItemArray[4];
                MonthReport _detail = new MonthReport
                {
                    Date = _date,
                    Opened = _open,
                    Closed = _close,
                    Different = _diff
                };

                int k;
                for (k = 0; k <= j && !(res[k].Type == _type && res[k].Month == _date.Month && res[k].Year == _date.Year); k++)
                {
                }
                if (k <= j)
                {
                    res[k].Details.Add(_detail);
                }
                else
                {
                    res.Add(new MonthlyReportItem { Type = _type, Month = _date.Month, Year = _date.Year, Details = new List<MonthReport> { _detail } });
                    j++;
                }
            }
            return res;
        }
    }
}

using Eliteria.API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
namespace Eliteria.API.DataProviders
{
    public class ReportProvider : IReportProvider
    {
        public async Task<IEnumerable<MonthlyReportItem>> GetMonthlyData(string conn)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                IEnumerable<RawMonthlyData> rawData = await sqlConnection.QueryAsync<RawMonthlyData>("Eliteria_LoadMonthlyData",
                    commandType: System.Data.CommandType.StoredProcedure);
                Dictionary<string, MonthlyReportItem> data = new Dictionary<string, MonthlyReportItem>();
                foreach (var item in rawData.ToList())
                {
                    string key = string.Format("{0}/{1}/{2}", item.Type, item.Date.Month, item.Date.Year);

                    if (data.ContainsKey(key))
                    {
                        MonthReport details = new MonthReport();
                        details.Date = item.Date;
                        details.Opened = item.Opened;
                        details.Closed = item.Closed;
                        details.Different = item.Different;
                        data[key].Details.Add(details);
                    }
                    else
                    {
                        data[key] = new MonthlyReportItem();
                        data[key].Type = item.Type;
                        data[key].Month = item.Date.Month;
                        data[key].Year = item.Date.Year;
                        MonthReport details = new MonthReport();
                        details.Date = item.Date;
                        details.Opened = item.Opened;
                        details.Closed = item.Closed;
                        details.Different = item.Different;
                        data[key].Details = new List<MonthReport>() { details };
                    }
                }
                return data.Values.ToList().AsEnumerable();
            }
        }

        public async Task<IEnumerable<DailyReportItem>> GetRevenueData(string conn)
        {
            using (SqlConnection sqlConnection = new SqlConnection(conn))
            {
                await sqlConnection.OpenAsync();
                IEnumerable<RawDailyData> rawData = await sqlConnection.QueryAsync<RawDailyData>("Eliteria_LoadRevenueData",
                    commandType: System.Data.CommandType.StoredProcedure);
                Dictionary<string, DailyReportItem> data = new Dictionary<string, DailyReportItem>();
                foreach (var item in rawData.ToList())
                {
                    string key = item.Date.ToString("dd/MM/yyyy");

                    if (data.ContainsKey(key))
                    {
                        DayReport details = new DayReport();
                        details.Type = item.Type;
                        details.Revenue = item.Revenue;
                        details.Expense = item.Expense;
                        details.Different = item.Different;
                        data[key].DayReports.Add(details);
                    }
                    else
                    {
                        data[key] = new DailyReportItem();
                        data[key].Date = item.Date;
                        DayReport details = new DayReport();
                        details.Type = item.Type;
                        details.Revenue = item.Revenue;
                        details.Expense = item.Expense;
                        details.Different = item.Different;
                        data[key].DayReports = new List<DayReport>() { details };
                    }
                }
                return data.Values.ToList().AsEnumerable();
            }
        }
    }
}

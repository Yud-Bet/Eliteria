using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliteria.API.DataProviders
{
    public interface IReportProvider
    {
        public Task<IEnumerable<Models.MonthlyReportItem>> GetMonthlyData(string conn);
        public Task<IEnumerable<Models.DailyReportItem>> GetRevenueData(string conn);
    }
}

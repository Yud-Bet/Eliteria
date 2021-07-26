using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.DataAccess.Modules
{
    public class ReportModule : BaseModule
    {
        public static async Task<List<Models.MonthlyReportItem>> GetMonthlyData()
        {
            ApiPath = string.Format("api/report/monthly-data");
            var path = BaseURL + "/" + ApiPath;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler) { Timeout = TimeSpan.FromMinutes(10) })
            {
                var responseMessage = await client.GetAsync(path);
                var model = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<Models.MonthlyReportItem>>(model);
                return data.ToList();
            }
        }
        public static async Task<List<Models.DailyReportItem>> GetDailyData()
        {
            ApiPath = string.Format("api/report/daily-data");
            var path = BaseURL + "/" + ApiPath;
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var client = new HttpClient(clientHandler) { Timeout = TimeSpan.FromMinutes(10) })
            {
                var responseMessage = await client.GetAsync(path);
                var model = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<Models.DailyReportItem>>(model);
                return data.ToList();
            }
        }
    }
}

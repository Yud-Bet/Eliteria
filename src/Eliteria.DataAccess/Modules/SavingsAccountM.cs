using Eliteria.DataAccess.Models;
using Eliteria.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Eliteria.DataAccess.Modules
{
    public class SavingsAccountM
    {
        private static string API_GetSavingsAccounts = WebConfigurationManager.AppSettings["API"] + "api/SavingsAccount/SavingsAccountList";

        public static async Task<ObservableCollection<SavingsAccount>> GetSavingsAccounts()
        {
            using (var Client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) })
            {
                var res = await Client.GetAsync(API_GetSavingsAccounts);
                var strRes = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<SavingsAccount>>(strRes);
            }            
        }
                

    }
}

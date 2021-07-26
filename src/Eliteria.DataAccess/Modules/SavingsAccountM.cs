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
        private static string API_GetSavingsAccounts = WebConfigurationManager.AppSettings["API"] + "api/SavingsAccount/{0}";

        public static async Task<ObservableCollection<SavingsAccount>> GetSavingsAccountsBySite(string Site = "ELITERIASITE")
        {
            try
            {
                using (var Client = new HttpClient { Timeout = TimeSpan.FromMinutes(2) })
                {
                    var model = Client.GetAsync(String.Format(API_GetSavingsAccounts, Site))
                        .Result.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<ObservableCollection<SavingsAccount>>(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}

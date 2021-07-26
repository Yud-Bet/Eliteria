using Eliteria.DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Eliteria.DataAccess.Modules.SettingModules
{
    public class ParamestersM
    {
        private static string strUrl = WebConfigurationManager.AppSettings["API"];

        //Paramesters

        private static string API_CONFIGURE_PARAMESTERS = strUrl + "api/Paramester";

        public static int ConfigureParamester(OtherParameter item)
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) })
                {
                    var content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(String.Format(API_CONFIGURE_PARAMESTERS), content).Result.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(result);
                }
            }
            catch (Exception ex)
            {

                return 0;
            }
        }
    }
}

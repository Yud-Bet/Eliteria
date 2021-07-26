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
    public class SavingTypesM
    {

        private static string strUrl = WebConfigurationManager.AppSettings["API"];

        //Saving Types

        private static string API_GET_ALL_SAVING_TYPE = strUrl + "api/SavingType/GetALlSavingTypes";
        private static string API_ADD_NEW_SAVING_TYPE = strUrl + "api/SavingType/AddNewSavingType";

        public static async Task<IEnumerable<SavingType>> GetSavingTypes()
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) })
                {
                    var responde = await client
                   .GetAsync(String.Format(API_GET_ALL_SAVING_TYPE));
                    var result = await responde.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<SavingType>>(result);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static async Task<int> AddNewSavingType(SavingType itemSavingType)
        {
            try
            {

                using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) })
                {
                    var content = new StringContent(JsonConvert.SerializeObject(itemSavingType), Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync(String.Format(API_ADD_NEW_SAVING_TYPE), content);
                    var result = await responseMessage.Content.ReadAsStringAsync();

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

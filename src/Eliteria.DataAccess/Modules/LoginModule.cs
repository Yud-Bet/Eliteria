using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.DataAccess.Modules
{
    public class LoginModule : BaseModule
    {
        public static async Task<IEnumerable<Models.Account>> Login(string username, string password)
        {
            ApiPath = string.Format("api/login");
            var path = BaseURL + "/" + ApiPath;
            try
            {
                Models.Account acc = new Models.Account()
                {
                    StaffID = Int32.TryParse(username, out int result) ? result : -1,
                    Password = password,
                };
                if (acc.StaffID == -1)
                    return null;
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (var client = new HttpClient(clientHandler) { Timeout = TimeSpan.FromMinutes(10) })
                {
                    var content = new StringContent(JsonConvert.SerializeObject(acc), Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync(path, content);
                    var model = await responseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Models.Account>>(model);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}

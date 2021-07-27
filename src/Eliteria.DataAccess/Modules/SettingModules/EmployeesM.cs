
using Eliteria.DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;



namespace Eliteria.DataAccess.Modules.SettingModule
{
    public class EmployeesM
    {
        private static string strUrl = WebConfigurationManager.AppSettings["API"];

        private static string API_GET_ALL_EMPLOYEES = strUrl + "api/Employees";
        private static string API_REMOVE_EMPLOYEE = strUrl + "api/Employees/Remove/{0}";
        private static string API_UPDATE_EMPLOYEE = strUrl + "api/Employees/Update";
        private static string API_INSERT_EMPLOYEE = strUrl + "api/Employees/Insert";

        public static IEnumerable<Account> GetAllEmpoyees()
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) })
                {
                    var model = client
                   .GetAsync(String.Format(API_GET_ALL_EMPLOYEES))
                   .Result
                   .Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<IEnumerable<Account>>(model);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public static int RemoveEmployee(string  accountID)
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) })
                {
                    var model = client
                   .GetAsync(String.Format(API_REMOVE_EMPLOYEE, accountID))
                   .Result
                   .Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<int>(model);
                }
            }
            catch (Exception)
            {
                //return 0 == false ??
                return 0;
            }
        }

        public static int UpdateEmployee(Account accountItem)
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) })
                {
                    var content = new StringContent(JsonConvert.SerializeObject(accountItem), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(String.Format(API_UPDATE_EMPLOYEE), content).Result.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(result);
                }
            }
            catch (Exception)
            {
                //return 0 == false ??
                return 0;
            }
        }

        public static int InsertEmployee(Account accountItem)
        {
            try
            {
                using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10) })
                {
                    var content = new StringContent(JsonConvert.SerializeObject(accountItem), Encoding.UTF8, "application/json");
                    var result = client.PostAsync(String.Format(API_INSERT_EMPLOYEE), content).Result.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(result);
                }
            }
            catch (Exception)
            {
                //return 0 == false ??
                return 0;
            }
        }


    }

}

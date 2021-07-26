using Eliteria.DataAccess.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Eliteria.DataAccess.Modules
{
    public class MoneyTransactionModule
    {
        private static string strUrl = WebConfigurationManager.AppSettings["API"];
        private static string API_PUT_AutoCalcInterest = strUrl + "api/MoneyTransaction/AutomaticCalculateInterest";
        private static string API_GET_CalcPreMaturityInterest = strUrl + "api/MoneyTransaction/CalculatePreMaturityInterest/{0}";
        private static string API_PUT_CloseSavings = strUrl + "api/MoneyTransaction/ControlCloseSavings";
        private static string API_GET_GetAllSavings = strUrl + "api/MoneyTransaction/GetAllSavings";
        private static string API_GET_GetLastTransactionID = strUrl + "api/MoneyTransaction/GetLastTransactionID";
        private static string API_GET_GetSavingsWithID = strUrl + "api/MoneyTransaction/GetSavingsWithID/{0}";
        private static string API_POST_InsertNewTransaction = strUrl + "api/MoneyTransaction/InsertNewTransaction";
        private static string API_PUT_WithdrawInterest = strUrl + "api/MoneyTransaction/WithdrawInterest/{0}";

        public static bool AutomaticCalculateInterest()
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10)})
            {
                var respond = client.PutAsync(API_PUT_AutoCalcInterest, null).Result;
                if (respond.StatusCode == HttpStatusCode.NoContent) return true;
                else return false;
            }
        }
        public static decimal CalculatePreMaturityInterest(int SavingsId)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10)})
            {
                var respond = client.GetAsync(string.Format(API_GET_CalcPreMaturityInterest, SavingsId)).Result;
                var strRespond = respond.Content.ReadAsStringAsync().Result;
                if (respond.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<decimal>(strRespond);
                else return default(decimal);
            }
        }
        public static bool ControlCloseSavings()
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10)})
            {
                var respond = client.PutAsync(API_PUT_CloseSavings, null).Result;
                if (respond.StatusCode == HttpStatusCode.BadRequest) return false;
                else return true;
            }
        }
        public static List<SavingsAccount> GetAllSavings()
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10)})
            {
                var respond = client.GetAsync(API_GET_GetAllSavings).Result;
                var strRespond = respond.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<SavingsAccount>>(strRespond);
            }
        }
        public static int GetLastTransactionID()
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10)})
            {
                var respond = client.GetAsync(API_GET_GetLastTransactionID).Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<int>(respond);
            }
        }
        public static SavingsAccount GetSavingsWithID(int id)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10)})
            {
                var respond = client.GetAsync(string.Format(API_GET_GetSavingsWithID, id)).Result;
                var strRespond = respond.Content.ReadAsStringAsync().Result;
                if (respond.StatusCode == HttpStatusCode.NotFound) return null;
                else return JsonConvert.DeserializeObject<SavingsAccount>(strRespond);
            }
        }
        public static bool InsertNewTransaction(TransactionSlipData transaction)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10)})
            {
                var byteContent = Converters.ObjectToByteArrayContentConverter.Execute(transaction);
                var respond = client.PostAsync(API_POST_InsertNewTransaction, byteContent).Result;
                if (respond.StatusCode == HttpStatusCode.Created) return true;
                else return false;
            }
        }
        public static bool WithdrawInterest(int SavingsID)
        {
            using (var client = new HttpClient { Timeout = TimeSpan.FromMinutes(10)})
            {
                var respond = client.PutAsync(string.Format(API_PUT_WithdrawInterest, SavingsID), null).Result;
                if (respond.StatusCode == HttpStatusCode.BadRequest) return false;
                return true;
            }
        }
    }
}

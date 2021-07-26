using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;


namespace Eliteria.DataAccess.Modules.SettingModules
{
    class SavingTypesM
    {

        private static string strUrl = WebConfigurationManager.AppSettings["API"];

        //Saving Types

        private static string API_GET_ALL_SAVING_TYPE = strUrl + "/api/SavingType/GetALlSavingTypes";
        private static string API_ADD_NEW_SAVING_TYPE = strUrl + "/api/SavingType/AddNewSavingType";
    }
}

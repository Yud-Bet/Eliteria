using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Eliteria.DataAccess.Modules.SettingModules
{
    class ParamestersM
    {
        private static string strUrl = WebConfigurationManager.AppSettings["API"];

        //Paramesters

        private static string API_CONFIGURE_PARAMESTERS = strUrl + "/api/Paramester";
    }
}

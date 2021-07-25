using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eliteria.DataAccess.Modules
{
    public abstract class BaseModule
    {
        public static string BaseURL = ConfigurationManager.AppSettings["BASE_URL"];
        public static string ApiPath;
    }
}

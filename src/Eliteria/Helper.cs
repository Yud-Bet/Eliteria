using System.Configuration;

namespace Eliteria
{
    public static class Helper
    {
        public static string ConnectionStringVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}

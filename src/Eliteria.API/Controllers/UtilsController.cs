using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Eliteria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilsController : ControllerBase
    {
        public static string GetConnectionString(string site, string host)
        {
            string path = "Files\\Systems\\SQLConfig.xml";

            XDocument testXML = XDocument.Load(path);
            XElement cInfo = testXML.Descendants("info").Where(c => c.Element("site").Value.Equals(site)).FirstOrDefault();
            return cInfo.Element("connectionString").Value;
        }
    }
}

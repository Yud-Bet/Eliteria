using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace TodoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilsController : ControllerBase
    {
        public static string GetConnectionString(string site, string host)
        {
            string path = "Files\\System\\SQLConfig.xml";

            XDocument xml = XDocument.Load(path);
            XElement cInfo = xml.Descendants("info").Where(c => c.Element("site").Value.Equals(site)).FirstOrDefault();
            return cInfo.Element("connectionString").Value;
        }
    }
}

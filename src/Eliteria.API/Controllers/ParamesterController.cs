using Eliteria.API.DataProviders;
using Eliteria.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Eliteria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParamesterController : ControllerBase
    {
        private readonly ILogger<ParamesterController> _logger;
        private IParamesterProvider _iParamesterProvider;
        private IHostingEnvironment _hostingEnvironment;

        public ParamesterController(ILogger<ParamesterController> logger, IParamesterProvider iSavingTypeProvinder, IHostingEnvironment hostingEnvironment)
        {
            this._logger = logger;
            this._iParamesterProvider = iSavingTypeProvinder;
            this._hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<int>ConfigureParamester(OtherParameter item)
        {
            return await this._iParamesterProvider.ConfigureParamester(UtilsController.GetConnectionString("YUD",""),item);
        }
    }
}

using Eliteria.API.DataProviders;
using Eliteria.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliteria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingTypeController : ControllerBase
    {
        private readonly ILogger<SavingTypeController> _logger;
        private ISavingTypeProvider _iSavingTypeProvinder;
        private IHostingEnvironment _hostingEnvironment;

        public SavingTypeController(ILogger<SavingTypeController> logger, ISavingTypeProvider iSavingTypeProvinder, IHostingEnvironment hostingEnvironment)
        {
            this._logger = logger;
            this._iSavingTypeProvinder = iSavingTypeProvinder;
            this._hostingEnvironment = hostingEnvironment;
        }

       [HttpGet("GetALlSavingTypes")]
       public async Task<IEnumerable<SavingType>> GetALlSavingTypes()
        {
            return await this._iSavingTypeProvinder.GetAllSavingTypes(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath));
        }

        [HttpPost("AddNewSavingType")]
        public async Task<int> AddNewSavingType(SavingType item)
        {
            return await this._iSavingTypeProvinder.AddNewSavingType(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath),item);
        }
    }



}

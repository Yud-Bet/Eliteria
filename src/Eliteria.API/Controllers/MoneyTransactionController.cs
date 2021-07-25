using Eliteria.API.DataProviders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliteria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyTransactionController : ControllerBase
    {
        private readonly ILogger<MoneyTransactionController> _logger;
        private IMoneyTransactionProvider _moneyTransactionProvider;
        private IHostingEnvironment _hostingEnvironment;

        public MoneyTransactionController(ILogger<MoneyTransactionController> logger, IMoneyTransactionProvider moneyTransactionProvider, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _moneyTransactionProvider = moneyTransactionProvider;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPut("AutomaticCalculateInterest")]
        public async Task<IActionResult> AutomaticCalculateInterest()
        {
            await _moneyTransactionProvider.AutomaticCalculateInterest(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath));
            return NoContent();
        }

        [HttpGet("CalculatePreMaturityInterest/{idSaving}")]
        public async Task<ActionResult<decimal>> CalculatePreMaturityInterest(int idSaving)
        {
            decimal transAmount = await _moneyTransactionProvider.CalculatePreMaturityInterest(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath), idSaving);
            if (transAmount == default(decimal)) return NotFound(); 
            return Ok(transAmount);
        }

        [HttpPut("ControlCloseSavings")]
        public async Task<IActionResult> ControlCloseSavings()
        {
            int affectedRows = await _moneyTransactionProvider.ControlCloseSavings(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath));
            if (affectedRows == -1) return BadRequest();
            return NoContent();
        }

        [HttpGet("GetLastTransactionID")]
        public async Task<ActionResult<int>> GetLastTransactionID()
        {
            int transID = await _moneyTransactionProvider.GetLastTransactionID(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath));
            return Ok(transID);
        }
    }
}

using Eliteria.API.DataProviders;
using Eliteria.API.Models;
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

        [HttpGet("GetAllSavings")]
        public async Task<ActionResult<List<SavingsAccount>>> GetAllSavings()
        {
            var savingsAccounts = await _moneyTransactionProvider.GetAllSavings(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath));
            return Ok(savingsAccounts);
        }

        [HttpGet("GetLastTransactionID")]
        public async Task<ActionResult<int>> GetLastTransactionID()
        {
            int transID = await _moneyTransactionProvider.GetLastTransactionID(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath));
            return Ok(transID);
        }

        [HttpGet("GetSavingsWithID/{id}")]
        public async Task<ActionResult<SavingsAccount>> GetSavingsWithID(int id)
        {
            var account = await _moneyTransactionProvider.GetSavingIf(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath), id);
            if (account == default(SavingsAccount)) return NotFound();
            return Ok(account);
        }

        [HttpPost("InsertNewTransaction")]
        public async Task<IActionResult> InsertNewTransaction([FromBody] TransactionSlipData transaction)
        {
            int affectedRows = await _moneyTransactionProvider.InsertNewTransaction(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath), transaction);
            return CreatedAtAction(nameof(InsertNewTransaction), transaction);
        }

        [HttpPut("WithdrawInterest/{SavingID}")]
        public async Task<IActionResult> WithdrawInterest(int SavingID)
        {
            int affectedRows = await _moneyTransactionProvider.WithdrawInterest(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath), SavingID);
            if (affectedRows == -1) return BadRequest();
            return NoContent();
        }
    }
}

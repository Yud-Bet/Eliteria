using Eliteria.API.DataProviders;
using Eliteria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eliteria.API.Controllers;
using Microsoft.AspNetCore.Hosting;

namespace Eliteria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsAccountController : ControllerBase
    {
        private readonly ILogger<SavingsAccountController> _logger;
        private ISavingsAccountProvider _savingsAccountProvider;
        private IHostingEnvironment _hostingEnvironment;
        public SavingsAccountController(ILogger<SavingsAccountController> logger, ISavingsAccountProvider savingsAccountProvider, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _savingsAccountProvider = savingsAccountProvider;
            _hostingEnvironment = hostingEnvironment;
        }
        
        [HttpGet("SavingsAccountList")]
        public async Task<List<SavingsAccount>> GetSavingsAccount()
        {
            return await _savingsAccountProvider.GetAllSavingsAccount(UtilsController.GetConnectionString("ELITERIASITE", _hostingEnvironment.ContentRootPath));
        }        
    }
}

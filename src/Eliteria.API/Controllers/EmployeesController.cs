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
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private IEmployeesProvider _employeesProvider;
        private IHostingEnvironment _hostingEnvironment;
        public EmployeesController(ILogger<EmployeesController> logger, IEmployeesProvider employeesProvider, IHostingEnvironment hostingEnvironment)
        {
            this._logger = logger;
            this._employeesProvider = employeesProvider;
            this._hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await this._employeesProvider.GetAllAccounts(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath));
        }

        [HttpGet("Remove/{accountID}")]
        public async Task<int> DeleteAccount(string accountID)
        {
            return await this._employeesProvider.RemoveAccount(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath),accountID);
        }

        [HttpPost("Update")]
        public async Task<int> UpdateAccount(Account account)
        {
            return await this._employeesProvider.UpdateAccount(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath),account);
        }

        [HttpPost("Insert")]
        public async Task<int> InsertNewAccount(Account account)
        {
            return await this._employeesProvider.InsertAccount(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath), account);
        }
    }


}

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
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private ILoginProvider _loginProvider;
        private IHostingEnvironment _hostingEnvironment;

        public LoginController(ILogger<LoginController> logger, ILoginProvider loginProvider, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _loginProvider = loginProvider;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Models.Account>>> Login([FromBody] Models.Account account)
        {
            try
            {
                IEnumerable<Models.Account> respondAccount =
                    await _loginProvider.Login(UtilsController.GetConnectionString("YUD", _hostingEnvironment.ContentRootPath),
                    account.StaffID.ToString(), account.Password);
                return CreatedAtAction(nameof(Login), respondAccount.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

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
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private IReportProvider _reportProvider;
        private IHostingEnvironment _hostingEnvironment;

        public ReportController(ILogger<ReportController> logger, IReportProvider reportProvider, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _reportProvider = reportProvider;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("monthly-data")]
        public async Task<ActionResult<IEnumerable<Models.MonthlyReportItem>>> GetMonthlyData()
        {
            try
            {
                var data = await _reportProvider.GetMonthlyData(UtilsController.GetConnectionString("Pr3", _hostingEnvironment.ContentRootPath));
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("daily-data")]
        public async Task<ActionResult<IEnumerable<Models.DailyReportItem>>> GetDailyData()
        {
            try
            {
                var data = await _reportProvider.GetRevenueData(UtilsController.GetConnectionString("Pr3", _hostingEnvironment.ContentRootPath));
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

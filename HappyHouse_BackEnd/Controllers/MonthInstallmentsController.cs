using HappyHouse_Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthInstallmentsController : ControllerBase
    {
        private readonly MonthInstallmentsService monthInstallmentsService;

        public MonthInstallmentsController(MonthInstallmentsService monthInstallmentsService)
        {
            this.monthInstallmentsService = monthInstallmentsService;
        }


        [HttpGet]
        public async Task<IActionResult> GetMonthInstallmentsAsync()
        {
            var monthInstallments = await monthInstallmentsService.GetMonthInstallmentsAsync();
            if (monthInstallments == null || !monthInstallments.Any())
            {
                return NotFound("No month installments found.");
            }
            return Ok(monthInstallments);
        }
    }
}

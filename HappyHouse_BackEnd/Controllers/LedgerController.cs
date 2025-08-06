using HappyHouse_Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        private readonly LedgerService _ledgerService;

        public LedgerController(LedgerService ledgerService)
        {
            _ledgerService = ledgerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLedgers(DateTime date)
        {
            return Ok(await _ledgerService.GetAllLedgersAsync(date));
        }
    }
}

using HappyHouse_Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        private readonly ILedgerService _ledgerService;

        public LedgerController(ILedgerService ledgerService)
        {
            _ledgerService = ledgerService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetLedgers()
        {            
            return Ok(await _ledgerService.GetAllLedgersAsync());
        }

        [HttpGet("date")]
        public async Task<IActionResult> GetLedgerByDate(DateTime date)
        {
            return Ok(await _ledgerService.GetLedgerByDateAsync(date));
        }
    }
}

using HappyHouse.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse.API
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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

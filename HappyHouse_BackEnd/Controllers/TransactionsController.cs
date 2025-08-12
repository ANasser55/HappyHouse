using HappyHouse_Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionsService _transactionsService;

        public TransactionsController(TransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTransActionsAsync()
        {
            var transactions = await _transactionsService.GetAllTransactionsAsync();
            return Ok(transactions);
        }
        [HttpGet("getCustomerTransactions")]
        public async Task<IActionResult> GetCustomerTransactionsAsync(int id)
        {
            var transactions = await _transactionsService.GetCustomerTransactionsAsync(id);
            if (transactions == null || !transactions.Any())
            {
                return NotFound("No transactions found for the given customer ID.");
            }
            return Ok(transactions);
        }

        [HttpGet("getLedgerTransactions")]
        public async Task<IActionResult> GetLedgerTransactionsAsync(int id)
        {
            var transactions = await _transactionsService.GetLedgerTransactionsAsync(id);
            if (transactions == null || !transactions.Any())
            {
                return NotFound("No transactions found for the given ledger ID.");
            }
            return Ok(transactions);
        }
    }
}

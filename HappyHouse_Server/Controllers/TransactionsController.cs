using HappyHouse_Server.DTO;
using HappyHouse_Server.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }


        //[HttpGet]
        //public async Task<IActionResult> GetAllTransActionsAsync()
        //{
        //    var transactions = await _transactionsService.GetAllTransactionsAsync();
        //    return Ok(transactions);
        //}
        [HttpGet("CustomerTransactions/{id}")]
        public async Task<IActionResult> GetCustomerTransactionsAsync(int id)
        {
            var transactions = await _transactionsService.GetCustomerTransactionsAsync(id);
            if (transactions == null || !transactions.Any())
            {
                return NotFound("No transactions found for the given customer ID.");
            }
            return Ok(transactions);
        }

        [HttpGet("LedgerTransactions/{id}")]
        public async Task<IActionResult> GetLedgerTransactionsAsync(int id)
        {
            var transactions = await _transactionsService.GetLedgerTransactionsAsync(id);
            if (transactions == null || !transactions.Any())
            {
                return NotFound("No transactions found for the given ledger ID.");
            }
            return Ok(transactions);
        }

        [HttpPost("cash")]
        public async Task<IActionResult> AddCashTransaction(CashTransactionDTO cash)
        {
            try
            {
                var id = await _transactionsService.AddCashTransaction(cash);
                if (id != 0)
                    return Ok($"Created Transaction: TransactionId = {id}");
                else
                    return StatusCode(500, "Couldn't Save Transaction");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Installment")]
        public async Task<IActionResult> AddInstallmentTransaction(InstallmentTransactionDTO installment)
        {
            try
            {
                var id = await _transactionsService.AddInstallmentTransaction(installment);
                if (id != 0)
                    return Ok($"Created Transaction: TransactionId = {id}");
                else
                    return StatusCode(500, "Couldn't Save Transaction");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}

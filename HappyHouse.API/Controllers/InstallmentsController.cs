using HappyHouse.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse.API
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class InstallmentsController : ControllerBase
    {
        private readonly IInstallmentsService _installmentsService;

        public InstallmentsController(IInstallmentsService installmentsService)
        {
            _installmentsService = installmentsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInstallments()
        {
            try
            {
                var installments = await _installmentsService.GetAllInstallmentsAsync();
                return Ok(installments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving installments: {ex.Message}");
            }
        }
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetCustomerInstallments(int customerId)
        {
            try
            {
                var installments = await _installmentsService.GetCustomerInstallmentsAsync(customerId);
                if (installments == null || installments.Count == 0)
                {
                    return NotFound($"No installments found for customer with ID {customerId}");
                }
                return Ok(installments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving installments for customer: {ex.Message}");
            }
        }
        [HttpGet("month")]
        public async Task<IActionResult> GetMonthInstallments()
        {
            try
            {
                var installments = await _installmentsService.GetMonthInstallmentsAsync();
                return Ok(installments);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving installments: {ex.Message}");
            }
        }
    }
}

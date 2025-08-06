using HappyHouse_Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsController : ControllerBase
    {
        private readonly InstallmentsService _installmentsService;

        public InstallmentsController(InstallmentsService installmentsService)
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
    }
}

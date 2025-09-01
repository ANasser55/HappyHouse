using HappyHouse_Server.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customersService.GetAllCustomers());
        }

        [HttpGet("Installments")]
        public async Task<IActionResult> GetCustomerInstallments(int id)
        {
            try
            {
                var customer = await _customersService.GetCustomersInstallments();
                return Ok(customer);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchCustomers([FromQuery] string text)
        {
            var customers = await _customersService.SearchCustomers(text);
            return Ok(customers);
        }
    }
}

using HappyHouse_Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersService _customersService;

        public CustomersController(CustomersService customersService)
        {
            _customersService = customersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _customersService.GetAllCustomers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var customer = await _customersService.GetCustomerById(id);
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
            var customers = await _customersService.SearchCustomer(text);
            return Ok(customers);
        }
    }
}

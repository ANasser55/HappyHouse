using HappyHouse_Server.DTO;
using HappyHouse_Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRegistrationController : ControllerBase
    {
        private readonly ICustomerRegistrationService _customerRegistrationService;

        public CustomerRegistrationController(ICustomerRegistrationService customerRegistrationService)
        {
            _customerRegistrationService = customerRegistrationService;
        }


        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(CustomerRegistrationDTO registrationDTO)
        {
            try
            {
                await _customerRegistrationService.AddNewCustomer(registrationDTO.Customer, registrationDTO.Installment, registrationDTO.Transaction);
                return Ok();

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Customer exist"))
                    return Conflict("العميل موجود مسبقًا");

                return StatusCode(500, "حدث خطأ غير متوقع: " + ex.Message);
            }


        }

    }
}

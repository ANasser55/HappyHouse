using HappyHouse.Application.DTOs;
using HappyHouse.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse.API
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
                await _customerRegistrationService.AddNewCustomer(registrationDTO);
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

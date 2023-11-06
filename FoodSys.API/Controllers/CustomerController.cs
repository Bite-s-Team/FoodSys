using FoodSys.Application.DTO.Request.Customer;
using FoodSys.Application.DTO.Response.Customer;
using FoodSys.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FoodSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("AddCustomer")]
        public async Task<ActionResult<AddCustomerResponse>> AddCustomer(AddCustomerRequest customer)
        {
            if (customer == null)
            {
                return BadRequest("No data");
            }

            var customerResponse = await _customerService.AddCustomer(customer);
            if (customerResponse == null)
            {
                return BadRequest("Error: null user");
            }

            return Ok(customerResponse);

        }
    }
}

using FoodSys.Application.DTO.Request.Customer;
using FoodSys.Application.DTO.Response.Customer;
using FoodSys.Application.Service.Interface;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("GetCustomer/{id}")]
        [Authorize]
        public async Task<ActionResult<GetCustomerResponse>> GetCustomer(String id)
        {
            Guid guid = new Guid(id);

            var customerResponse = await _customerService.GetCustomer(guid);
            if (customerResponse == null)
            {
                return BadRequest("Error: null user");
            }

            return Ok(customerResponse);
        }
        [HttpDelete("DeleteCustomer/{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteCustomer(Guid id)
        {
            var deleted = await _customerService.DeleteCustomer(id);

            return deleted;
        }
        [HttpPut("UpdateCustomer")]
        [Authorize]
        public async Task<ActionResult<UpdateCustomerResponse>> UpdateCustomer(UpdateCustomerRequest customer)
        {
            var custormerResponse = await _customerService.UpdateCustomer(customer);

            if (custormerResponse == null)
            {
                return BadRequest("Error: null user");
            }

            return Ok(custormerResponse);
        }
    }
}

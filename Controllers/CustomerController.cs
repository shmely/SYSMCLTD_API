using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SYSMCLTD_API.DTOS;
using SYSMCLTD_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SYSMCLTD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;




        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ServiceResponse<IEnumerable<CustomerDto>>> Get()
        {
            return await _customerService.GetCustomers();
        }
        [HttpGet("{id}")]
        public async Task<ServiceResponse<CustomerDto>> Get(int id)
        {
            return await _customerService.GetCustomerById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ServiceResponse<CustomerDto>> Delete(int id)
        {
            return await _customerService.DeleteCustomer(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<CustomerDto>> Post(CustomerDto customer)
        {
            return await _customerService.SaveCustomer(customer);
        }

    }
}

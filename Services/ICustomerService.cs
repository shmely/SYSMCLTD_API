using SYSMCLTD_API.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SYSMCLTD_API.Services
{
    public interface ICustomerService
    {
        Task<ServiceResponse<IEnumerable<CustomerDto>>> GetCustomers();

        Task<ServiceResponse<CustomerDto>> GetCustomerById(int id);

        Task<ServiceResponse<CustomerDto>> SaveCustomer(CustomerDto customerDto); 

        Task<ServiceResponse<CustomerDto>> DeleteCustomer(int id);



    }
}

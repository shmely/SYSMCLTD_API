using AutoMapper;
using SYSMCLTD_API.DTOS;
using SYSMCLTD_API.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace SYSMCLTD_API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly SYSMCLTDContext _context;
        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper, SYSMCLTDContext context)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ServiceResponse<CustomerDto>> DeleteCustomer(int id)
        {
            var response = new ServiceResponse<CustomerDto>();
            try
            {
                var customer=await _context.Customers.FindAsync(id);
                customer.IsDeleted = true;
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                
            }
            catch (System.Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public async Task<ServiceResponse<CustomerDto>> GetCustomerById(int id)
        {
            var response = new ServiceResponse<CustomerDto>();
            try
            {
                var customer = await _context.Customers
               .Include(c => c.Addresses.Where(ad => ad.IsDeleted == false))
               .Include(c => c.Contacts.Where(co => co.IsDeleted == false))
               .Where(c => c.IsDeleted == false && c.Id==id).FirstOrDefaultAsync();
                response.Data = _mapper.Map<CustomerDto>(customer);
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + " " + ex.InnerException.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var response = new ServiceResponse<IEnumerable<CustomerDto>>();
            try
            {
                var customers = await _context.Customers
               .Include(c => c.Addresses.Where(ad => ad.IsDeleted == false))
               .Include(c => c.Contacts.Where(co => co.IsDeleted == false))
               .Where(c => c.IsDeleted == false).ToListAsync();
                response.Data = customers.Select(c => _mapper.Map<CustomerDto>(c));
            }
            catch (System.Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message + " " + ex.InnerException.Message;
            }
            
            return response;
        }

        public async Task<ServiceResponse<CustomerDto>> SaveCustomer(CustomerDto customerDto)
        {
            var response = new ServiceResponse<CustomerDto>();
            try
            {
                
                var customer = _mapper.Map<Customer>(customerDto);
                if (customer.Id!=0)
                 _context.Customers.Update(customer);
                else
                    _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<CustomerDto>(customer);
            }
            catch (System.Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message + " " + ex.InnerException.Message;
            }
            return response;
        }
    }
}

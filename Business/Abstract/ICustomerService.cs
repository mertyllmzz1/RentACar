using Core.Results;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        public Task<IResult> AddAsync(Customers data);
        public Task<IResult> UpdateAsync(CustomerIsAdminDTO data);
        public Task<IResult> DeleteAsync(int Id);
        public Task<Customers> GetFirstCustomersAsync(int Id);
        public Task<IList<Customers>> GetAllCustomersAsync();
        public Task<IList<Customers>> GetAllRentsByCustomersIdAsync(int Id);
        public Task<Customers> LoginAsync(string Email, string Password);
        public Task<string> PaswordForgotAsync(string Email);
    }
}

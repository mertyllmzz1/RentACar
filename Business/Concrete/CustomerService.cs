using Core.Results;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> AddAsync(Customers data)
        {
            return await _unitOfWork.RepoCustomers.AsyncAdd(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            return await _unitOfWork.RepoCustomers.AsyncDelete(x => x.ID == Id).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<Customers>> GetAllCustomersAsync()
        {
            return await _unitOfWork.RepoCustomers.AsyncGetAll();
        }

        public async Task<IList<Customers>> GetAllRentsByCustomersIdAsync(int Id)
        {
            return await _unitOfWork.RepoCustomers.AsyncGetAll(x => x.ID == Id, x => x.Rents);
        }

        public async Task<Customers> GetFirstCustomersAsync(int Id)
        {
            return await _unitOfWork.RepoCustomers.AsyncFirst(x => x.ID == Id);
        }

        public  async Task<Customers> LoginAsync(string Email, string Password)
        {
            return await _unitOfWork.RepoCustomers.Login(Email, Password);
        }

        public async Task<string> PaswordForgotAsync(string Email)
        {
            return await _unitOfWork.RepoCustomers.ForgotPasswords(Email);
        }

        public async Task<IResult> UpdateAsync(CustomerIsAdminDTO data)
        {
            var customer = _unitOfWork.RepoCustomers.AsyncFirst(x=>x.ID==data.ID).Result;
            if (customer!=null)
            {
                customer.IsAdmin = data.IsAdmin;
            }
            return await _unitOfWork.RepoCustomers.AsyncUpdate(customer).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
    }
}

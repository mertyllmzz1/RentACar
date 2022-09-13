using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentService : IRentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> AllAddAsync(Rents data)
        {
            return await _unitOfWork.RepoRents.AsyncAdd(data).ContinueWith(p => _unitOfWork.SaveChanges()).Result;
        }

        public async Task<IList<Rents>> GetAllRents()
        {
            return await Task.Run(() => _unitOfWork.RepoRents.AsyncGetAll(null, x => x.Customers).Result.OrderByDescending(x => x.RentDate).ToList());
        }

        public async Task<Rents> GetRentsRelationById(int id)
        {
            return await _unitOfWork.RepoRents.AsyncFirst(x => x.ID == id, x => x.Customers);
        }

        public async Task<IResult> UpdateAsync(Rents data)
        {
            return await _unitOfWork.RepoRents.AsyncUpdate(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
    }
}

using Core.Results;
using DataAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoriesService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> AddAsync(Categories data)
        {
            return await _unitOfWork.RepoCategories.AsyncAdd(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
        public async Task<IResult> DeleteAync(int id)
        {
            return await _unitOfWork.RepoCategories.AsyncDelete(x=>x.ID==id).ContinueWith(x=>_unitOfWork.SaveChanges()).Result;
        }
        public async Task<Categories> GetAllCarsByCategoryID(int CategoriesId)
        {
            return await _unitOfWork.RepoCategories.AsyncFirst(p => p.ID == CategoriesId, x => x.Cars);
        }
        public async Task<IList<Categories>> GetAllCategoriesAsync()
        {
            return await _unitOfWork.RepoCategories.AsyncGetAll();
        }
        public async Task<Categories> GetCategoryByID(int CategoriesId)
        {
            return await _unitOfWork.RepoCategories.AsyncFirst(p=>p.ID==CategoriesId);
        }
        public async Task<IResult> UpdateAsync(Categories data)
        {
            return await _unitOfWork.RepoCategories.AsyncUpdate(data).ContinueWith(x => _unitOfWork.SaveChanges()).Result;
        }
    }
}

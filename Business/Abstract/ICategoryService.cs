using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        public Task<IResult> AddAsync(Categories data);
        public Task<IResult> UpdateAsync(Categories data);
        public Task<IResult> DeleteAync(int id);
        public Task<IList<Categories>> GetAllCategoriesAsync();
        public Task<Categories> GetAllCarsByCategoryID(int CategoriesId);
        public Task<Categories> GetCategoryByID(int CategoriesId);
    }
}

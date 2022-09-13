using DataAccess.Abstract;
using DataAccess.Repository;
namespace DataAccess.Concrete
{
    public class CategoriesRepo: Repositories<Categories>, ICategoriesRepo
    {
        public CategoriesRepo(DbContext context) : base(context){}
    }
}

using DataAccess.Abstract;
using DataAccess.Repository;
namespace DataAccess.Concrete
{
    public class CarsRepo:Repositories<Cars>,ICarsRepo
    {
        public CarsRepo(DbContext context):base(context)
        {

        }
    }
}

using DataAccess.Abstract;
using DataAccess.Repository;

namespace DataAccess.Concrete
{
    public class RentsRepo : Repositories<Rents>,IRentsRepo
    {
        public RentsRepo(DbContext context):base(context)
        {

        }
    }
}

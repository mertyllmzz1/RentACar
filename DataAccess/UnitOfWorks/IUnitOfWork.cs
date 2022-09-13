using Core.Results;
using DataAccess.Abstract;
namespace DataAccess.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public ICategoriesRepo RepoCategories { get; }
        public ICustomerRepo RepoCustomers { get; }
        public ICarsRepo RepoCars { get; }
        public IRentsRepo RepoRents { get; }
        public Task<IResult> SaveChanges();

    }
}

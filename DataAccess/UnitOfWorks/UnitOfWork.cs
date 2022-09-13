using Core.Results;
using Core.Results.ComplexTypes;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentContext context;
        public UnitOfWork(RentContext context)
        {
            this.context = context;
        }
        private CategoriesRepo categories;
        private CustomerRepo customer;
        private CarsRepo cars;
        private RentsRepo rents;
        public ICategoriesRepo RepoCategories => categories??new CategoriesRepo(context);

        public ICustomerRepo RepoCustomers => customer ??new CustomerRepo(context);

        public ICarsRepo RepoCars => cars ??new CarsRepo(context);

        public IRentsRepo RepoRents => rents ?? new RentsRepo(context);

        public async Task<IResult> SaveChanges()
        {
            using (context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    context.Database.CommitTransaction();
                    return Result.FactoryResult(StatusCode.Success, "İşlem Başarılı");
                }
                catch (Exception e)
                {
                    context.Database.RollbackTransaction();
                    return Result.FactoryResult(StatusCode.Error, "İşlem Başarısız", e);
                }
            }
        }
    }
}

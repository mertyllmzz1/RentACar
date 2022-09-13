using Core.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Repository
{

    public interface IRepositories<TEntity> where TEntity : class, IEntity
    {
        public Task AsyncAdd(TEntity entity);
        public Task AsyncUpdate(TEntity entity);
        public Task<TEntity> AsyncFirst(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include);
        public Task<IList<TEntity>> AsyncGetAll(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] include);
        public Task AsyncDelete(Expression<Func<TEntity, bool>> where);

    }
}

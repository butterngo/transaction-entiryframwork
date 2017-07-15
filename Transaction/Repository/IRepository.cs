namespace Transaction.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Transaction.Domain;

    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> FindByIdAsync(int Id);

        IQueryable<TEntity> FindAll(Expression<Func<TEntity,bool>> pression = null);

        void Add(TEntity entity);

        void Edit(TEntity entity);

        void Delete(int id);

        void Delete(TEntity entity);
    }
}

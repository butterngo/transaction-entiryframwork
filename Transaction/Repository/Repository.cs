namespace Transaction.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Transaction.Domain;

    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        protected readonly TContext _context;

        protected Repository(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (entity != null) return;

            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public void Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> pression = null)
        {
            if (pression == null) return _context.Set<TEntity>().AsNoTracking();

            return _context.Set<TEntity>().AsNoTracking().Where(pression);
        }

        public Task<TEntity> FindByIdAsync(int Id)
        {
            return _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}

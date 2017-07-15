namespace Transaction.Repository
{
    using System.Data.Entity;
    using Transaction.Domain;

    public sealed class GenericRepository<TEntity, TContext> : Repository<TEntity, TContext>, IRepository<TEntity>
        where  TEntity: class, IEntity
        where TContext: DbContext, new()
    {
        public GenericRepository():this(new TContext()) { }

        public GenericRepository(TContext context) : base(context)
        {
        }
    }
}

namespace Transaction
{
    using System;
    using System.Threading.Tasks;
    using Transaction.Domain;
    using Transaction.Repository;

    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Order> OrderRepository { get; set; }

        public IRepository<OrderDetail> OrderDetailRepository { get; set; }

        private readonly TransactionContext _context;

        public UnitOfWork() : this(new TransactionContext()) { }

        public UnitOfWork(TransactionContext context)
        {
            _context = context;
            InitRepository();
        }

        private void InitRepository()
        {
            OrderRepository = new GenericRepository<Order, TransactionContext>(_context);
            OrderDetailRepository = new GenericRepository<OrderDetail, TransactionContext>(_context);
        }

        public async Task CommitAsync()
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public void Commit()
        {
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}

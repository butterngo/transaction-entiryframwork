namespace Transaction
{
    using System.Threading.Tasks;
    using Transaction.Domain;
    using Transaction.Repository;

    public interface IUnitOfWork
    {
        IRepository<Order> OrderRepository { get; }

        IRepository<OrderDetail> OrderDetailRepository { get; }

        Task CommitAsync();

        void Commit();
    }
}

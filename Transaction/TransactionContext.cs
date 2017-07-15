namespace Transaction
{
    using System;
    using System.Data.Entity;
    using Transaction.Domain;

    public class TransactionContext: DbContext
    {
        public TransactionContext() : base("TransactionContext")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", @"C:\Dev\DemoForBlog\Transaction\Transaction\Transaction\App_Data");
        }

        public virtual IDbSet<Order> Order { get; set; }
        public virtual IDbSet<OrderDetail> OrderDetail { get; set; }
    }
}

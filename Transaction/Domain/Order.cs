namespace Transaction.Domain
{
    using System;
    using System.Collections.Generic;

    public class Order: IEntity
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

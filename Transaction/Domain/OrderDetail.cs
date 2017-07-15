namespace Transaction.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class OrderDetail: IEntity
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

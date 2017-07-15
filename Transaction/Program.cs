namespace Transaction
{
    using System;
    using Transaction.Domain;

    public class Program
    {
        static void Main(string[] args)
        {
            //Insert Done
                Process(false, "VuNgo");
            //RollBack Done
                Process(true, "VuNgo1");
            Console.ReadKey();
        }

        private static void Process(bool isRollBack, string CreatedBy)
        {
            IUnitOfWork uow = new UnitOfWork();

            var order = new Order
            {
                Sku = Guid.NewGuid().ToString("n").Substring(0, 6),
                CreatedBy = CreatedBy,
                CreatedAt = DateTime.Now,
            };

            uow.OrderRepository.Add(order);

            for (int i = 0; i < 5; i++)
            {
                var orderDetail = new OrderDetail
                {
                    ProductName = (i == 3 && isRollBack ? "dsadsadsadsadsadsadsdas": $"Name:{i}"),
                    Price = i * 10,
                    CreatedAt = DateTime.Now,
                    Order = order,
                    OrderId = order.Id
                };

                uow.OrderDetailRepository.Add(orderDetail);
            }

            uow.Commit();
        }
    }
}

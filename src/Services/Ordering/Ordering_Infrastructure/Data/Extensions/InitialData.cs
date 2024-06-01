using Ordering_Domain.Models;
using Ordering_Domain.ValueObjects;

namespace Ordering_Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>()
            {
                Customer.Create(CustomerId.Of(new Guid("3d8f7b5e-debe-45f4-923e-db17076b098a")), "piotr", "piotr@gmail.com"),
                Customer.Create(CustomerId.Of(new Guid("d3d7edcd-fc8c-4258-9961-9af7736fa580")), "michal", "michal@gmail.com")
            };

        public static IEnumerable<Product> Products =>
            new List<Product>()
            {
                Product.Create(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "IPhone X", 500),
                Product.Create(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), "Samsung 10", 400),
                Product.Create(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), "Huawei Plus", 650),
                Product.Create(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), "Xiaomi Mi 9", 470)
            };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("piotr", "brother", "piotrbrother@gmail.com", "Kunickikego No:25", "Poland", "Lodz", "90000");
                var address2 = Address.Of("michal", "brother", "michalbrother@gmail.com", "Sportowa No:10", "Poland", "Lodz", "90000");

                var payment1 = Payment.Of("jan", "5555555555554444", "12/28", "355", 1);
                var payment2 = Payment.Of("john", "8885555555554444", "06/30", "222", 2);

                var order1 = Order.Create(
                                OrderId.Of(Guid.NewGuid()),
                                CustomerId.Of(new Guid("3d8f7b5e-debe-45f4-923e-db17076b098a")),
                                OrderName.Of("ORD_1"),
                                shippingAddress: address1,
                                billingAddress: address1,
                                payment1);
                order1.Add(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 2, 500);
                order1.Add(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), 1, 400);

                var order2 = Order.Create(
                                OrderId.Of(Guid.NewGuid()),
                                CustomerId.Of(new Guid("d3d7edcd-fc8c-4258-9961-9af7736fa580")),
                                OrderName.Of("ORD_2"),
                                shippingAddress: address2,
                                billingAddress: address2,
                                payment2);
                order2.Add(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), 1, 650);
                order2.Add(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), 2, 470);

                return new List<Order> { order1, order2 };
            }
        }
    }
}

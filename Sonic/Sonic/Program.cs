using System;
using System.Collections.Generic;
using Sonic.Business;
using Sonic.Business.Extended.Orders;
using Sonic.DTO.Basic.Items;
using Sonic.DTO.Extended.Orders;
using Sonic.DTO.Extended.Orders.Items;
using Autofac;

namespace Sonic
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();

            var orderService = container.Resolve<IOrderService>();

            var order = BuildOrder();

            var orderTotal = orderService.GetOrderTotal(order);

            Console.WriteLine(orderTotal.ToString());
        }

        private static IContainer BuildContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new BusinessAutofacModule());

            return containerBuilder.Build();
        }

        private static Order BuildOrder()
        {
            return new Order(BuildOrderItems());
        }

        private static IEnumerable<OrderItem> BuildOrderItems()
        {
            return new List<OrderItem>
            {
                new OrderItem(new Item(1, "Cheese Burger", 5.5f), 1, OrderItemType.Material),
                new OrderItem(new Item(1, "Cherry Limeade", 2.2f), 1, OrderItemType.Material),
                new OrderItem(new Item(1, "Delivery Service", 1.23f), 1, OrderItemType.Service),
            };
        }
    }
}

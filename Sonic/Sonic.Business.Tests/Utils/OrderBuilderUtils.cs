using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Extended.Orders;
using Sonic.DTO.Extended.Orders.Items;
using Sonic.DTO.Basic.Items;
using Sonic.DTO.Extended.Store;

namespace Sonic.Business.Tests.Utils
{
    public class OrderBuilderUtils
    {
        public OrderBuilderUtils() { }

        public OrderItem BuildOrderItem(int key, string name, float price, int quantity, OrderItemType type)
        {
            return new OrderItem(BuildItem(key, name, price), quantity, type);
        }

        public Item BuildItem(int key, string name, float price)
        {
            return new Item(key, name, price);
        }

        public Location BuildLocation()
        {
            return new Location();
        }

        public Order BuildEmptyOrder()
        {
            return new Order(new List<OrderItem>());
        }

        public Order BuildOrder(IEnumerable<OrderItem> orderItems)
        {
            return new Order(orderItems);
        }
    }
}

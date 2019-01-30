using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonic.DTO.Basic.Items;
using Sonic.DTO.Extended.Store;
using Sonic.DTO.Extended.Orders.Items;

namespace Sonic.DTO.Extended.Orders
{
    public class Order
    { 
        public Order(IEnumerable<OrderItem> orderItems)
        {
            OrderItems = orderItems;
        }

        public int ID { get; }

        public Location StoreLocation { get; }

        public IEnumerable<OrderItem> OrderItems { get; }

        public ICollection<Item> GetItems()
        {
            var items = OrderItems.Select(x => x.Item);

            return items.OrderBy(x => x.Name).ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Sonic.DTO.Basic.Items;
using Sonic.DTO.Extended.Orders;
using Sonic.DTO.Extended.Orders.Items;

namespace Sonic.DTO.Tests.Extended.Orders
{
    public class OrderTests
    {
        [Fact]
        public void GetItemsTest()
        {
            var unsortedItems = BuildUnsortedOrderItems();
            var sortedItems = BuildSortedItems();

            var target = new Order(unsortedItems);

            var result = target.GetItems();

            var i = 0;

            foreach (var item in result)
            {
                Assert.Equal(sortedItems[i].Name, item.Name);
                i++;
            }
        }

        private IEnumerable<OrderItem> BuildUnsortedOrderItems()
        {
            return new List<OrderItem>
            {
                new OrderItem(new Item(2, "Hot Dog", 4.5f), 1, OrderItemType.Material),
                new OrderItem(new Item(3, "Expedited Service", 1.5f), 1, OrderItemType.Service),
                new OrderItem(new Item(1, "CheeseBurger", 5.5f), 1, OrderItemType.Material),
                new OrderItem(new Item(4, "Delivery Service", 2.4f), 1, OrderItemType.Service),
            };
        }

        private IList<Item> BuildSortedItems()
        {
            return new List<Item>
            {
                new Item(1, "CheeseBurger", 5.5f),
                new Item(4, "Delivery Service", 2.4f),
                new Item(3, "Expedited Service", 1.5f),
                new Item(2, "Hot Dog", 4.5f)
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Sonic.DTO.Basic.Orders;
using Sonic.DTO.Basic.Items;
using Sonic.DTO.Basic.Orders.Items;

namespace Sonic.DTO.Tests.Basic.Orders
{
    public class OrderTests
    {
        private float _salesTax = .08625f;

        [Fact]
        public void BasicMaterialOrderItemGetOrderTotalTest()
        {
            var orderList = new List<OrderItem>
            {
                BuildMaterialOrderItem(1, "CheeseBurger", 5.5f, 1)
            };

            var target = new Order(orderList.ToArray());

            var result = target.GetOrderTotal(_salesTax);

            // 5.5 + .474375 = 5.97
            var expected = 5.97f;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void MaterialOrderItemQuantityGetOrderTotalTest()
        {
            var orderList = new List<OrderItem>
            {
                BuildMaterialOrderItem(1, "CheeseBurger", 5.5f, 13)
            };

            var target = new Order(orderList.ToArray());

            var result = target.GetOrderTotal(_salesTax);

            // 71.5 + 6.166875 = 77.67
            var expected = 77.67f;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void BasicServiceOrderItemGetOrderTotalTest()
        {
            var orderList = new List<OrderItem>
            {
                BuildServiceOrderItem(1, "Delivery Service", 5.5f, 1)
            };

            var target = new Order(orderList.ToArray());

            var result = target.GetOrderTotal(_salesTax);

            // 5.5 * 1 = 5.5
            var expected = 5.5f;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ServiceOrderItemGetOrderTotalTest()
        {
            var orderList = new List<OrderItem>
            {
                BuildServiceOrderItem(1, "Delivery Service", 5.5f, 13)
            };

            var target = new Order(orderList.ToArray());

            var result = target.GetOrderTotal(_salesTax);

            // 5.5 * 13 = 71.5
            var expected = 71.5f;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetOrderTotalWithMaterialAndServiceOrderItemsTest()
        {
            var orderList = new List<OrderItem>
            {
                BuildMaterialOrderItem(1, "CheeseBurger", 5.5f, 13),
                BuildServiceOrderItem(1, "Delivery Service", 5.5f, 13)
            };

            var target = new Order(orderList.ToArray());

            var result = target.GetOrderTotal(_salesTax);

            // 77.67 + 71.5 = 149.17
            var expected = 149.17f;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetOrderTotalWithMaterialAndServiceOrderItemsMoreTest()
        {
            var orderList = new List<OrderItem>
            {
                BuildMaterialOrderItem(1, "CheeseBurger", 5.34f, 1),
                BuildMaterialOrderItem(1, "Cherry Limeade", 2.78f, 1),
                BuildServiceOrderItem(1, "Delivery Service", 1.23f, 1)
            };

            var target = new Order(orderList.ToArray());

            var result = target.GetOrderTotal(_salesTax);

            // 5.80 + 3.02 + 1.23 = 10.05
            var expected = 10.05f;

            Assert.Equal(expected, result);
        }

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

        private OrderItem[] BuildUnsortedOrderItems()
        {
            return new List<OrderItem>
            {
                new MaterialOrderItem(new Item(2, "Hot Dog", 4.5f), 1),
                new ServiceOrderItem(new Item(3, "Expedited Service", 1.5f), 1),
                new MaterialOrderItem(new Item(1, "CheeseBurger", 5.5f), 1),
                new ServiceOrderItem(new Item(4, "Delivery Service", 2.4f), 1),
            }.ToArray();
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

        private OrderItem BuildMaterialOrderItem(int key, string name, float price, int quantity)
        {
            return new MaterialOrderItem(BuildItem(key, name, price), quantity);
        }

        private OrderItem BuildServiceOrderItem(int key, string name, float price, int quantity)
        {
            return new ServiceOrderItem(BuildItem(key, name, price), quantity);
        }

        private Item BuildItem(int key, string name, float price)
        {
            return new Item(key, name, price);
        }
    }
}

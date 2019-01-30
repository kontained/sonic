using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Sonic.DTO.Basic.Items;
using Sonic.DTO.Basic.Order.Items;

namespace Sonic.DTO.Tests.Basic.Order.Items
{
    public class ServiceOrderItemTests
    {
        private float _salesTax = 0.0f;

        [Fact]
        public void BasicCalculateOrderPriceTest()
        {
            var item = BuildItem(1, "CheeseBurger", 5.50f);
            var quantity = 1;

            var target = new ServiceOrderItem(item, quantity);

            var result = target.CalculateOrderPrice();

            // 5.5 * 1 = 5.5
            var expected = 5.5f;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ItemQuantityCalculateTest()
        {
            var item = BuildItem(1, "CheeseBurger", 5.50f);
            var quantity = 13;

            var target = new ServiceOrderItem(item, quantity);

            var result = target.CalculateOrderPrice();

            // 5.5 * 13 = 71.5
            var expected = 71.5f;

            Assert.Equal(expected, result);
        }

        private Item BuildItem(int key, string name, float price)
        {
            return new Item(key, name, price);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Sonic.DTO.Basic.Items;
using Sonic.DTO.Basic.Order.Items;

namespace Sonic.DTO.Tests.Basic.Order.Items
{
    public class MaterialOrderItemTests
    {
        private float _salesTax = .08625f;

        [Fact]
        public void BasicCalculateOrderPriceTest()
        {
            var item = BuildItem(1, "CheeseBurger", 5.50f);
            var quantity = 1;

            var target = new MaterialOrderItem(item, quantity);

            var result = target.CalculateOrderPrice(_salesTax);

            // 5.5 + .474375 = 5.97
            var expected = 5.97f;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ItemQuantityCalculateTest()
        {
            var item = BuildItem(1, "CheeseBurger", 5.50f);
            var quantity = 13;

            var target = new MaterialOrderItem(item, quantity);

            var result = target.CalculateOrderPrice(_salesTax);

            // 71.5 + 6.166875 = 77.67
            var expected = 77.67f;

            Assert.Equal(expected, result);
        }

        private Item BuildItem(int key, string name, float price)
        {
            return new Item(key, name, price);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Sonic.Business.Extended.Orders.Processor.Strategy.Factory;
using Sonic.Business.Extended.Orders.Processor.Strategy;
using Sonic.Business.Extended.Orders.Processor.Taxes;
using Sonic.DTO.Extended.Orders.Items;
using Sonic.DTO.Basic.Items;

namespace Sonic.Business.Tests.Extended.Orders.Processor.Factory
{
    public class OrderItemStrategyFactoryTests
    {
        private Mock<ITaxRateService> _taxRateService;

        public OrderItemStrategyFactoryTests()
        {
            _taxRateService = new Mock<ITaxRateService>();
        }

        [Fact]
        private void NullOrderItemThrowsExceptionTest()
        {
            var target = BuildTestTarget();

            Assert.Throws<ArgumentNullException>(() => target.GetOrderItemProcessingStrategy(null));
        }

        [Fact]
        private void GetMaterialOrderItemProcessingStrategyTest()
        {
            var expected = typeof(MaterialOrderItemProcessingStrategy);

            var orderItem = BuildOrderItem(1, "Cheese Burger", 5.5f, 1, OrderItemType.Material);

            var target = BuildTestTarget();

            var result = target.GetOrderItemProcessingStrategy(orderItem);

            Assert.Equal(expected, result.GetType());
        }

        [Fact]
        private void GetServiceOrderItemProcessingStrategyTest()
        {
            var expected = typeof(ServiceOrderItemProcessingStrategy);

            var orderItem = BuildOrderItem(1, "Cheese Burger", 5.5f, 1, OrderItemType.Service);

            var target = BuildTestTarget();

            var result = target.GetOrderItemProcessingStrategy(orderItem);

            Assert.Equal(expected, result.GetType());
        }

        private OrderItem BuildOrderItem(int key, string name, float price, int quantity, OrderItemType type)
        {
            return new OrderItem(BuildItem(key, name, price), quantity, type);
        }

        private Item BuildItem(int key, string name, float price)
        {
            return new Item(key, name, price);
        }

        private IOrderItemStrategyFactory BuildTestTarget()
        {
            return new OrderItemStrategyFactory(BuildMaterialOrderItemStrategy(), BuildServiceOrderItemStrategy());
        }

        private MaterialOrderItemProcessingStrategy BuildMaterialOrderItemStrategy()
        {
            return new MaterialOrderItemProcessingStrategy(_taxRateService.Object);
        }

        private ServiceOrderItemProcessingStrategy BuildServiceOrderItemStrategy()
        {
            return new ServiceOrderItemProcessingStrategy();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Sonic.Business.Extended.Orders.Processor;
using Sonic.Business.Extended.Orders.Processor.Strategy.Factory;
using Sonic.Business.Extended.Orders.Processor.Strategy;
using Sonic.DTO.Extended.Orders;
using Sonic.DTO.Extended.Store;
using Sonic.DTO.Extended.Orders.Items;
using Sonic.DTO.Basic.Items;

namespace Sonic.Business.Tests.Extended.Orders.Processor
{
    public class OrderProcessorTests
    {
        private Mock<IOrderItemStrategyFactory> _orderItemStrategyFactory;
        private Mock<IOrderItemProcessingStrategy> _orderItemProcessingStrategy;

        public OrderProcessorTests()
        {
            _orderItemStrategyFactory = new Mock<IOrderItemStrategyFactory>();
            _orderItemProcessingStrategy = new Mock<IOrderItemProcessingStrategy>();
            _orderItemStrategyFactory.Setup(x => x.GetOrderItemProcessingStrategy(It.IsAny<OrderItem>())).Returns(_orderItemProcessingStrategy.Object);
        }

        [Fact]
        public void NullOrderThrowsArgumentException()
        {
            var target = BuildTestTarget();

            Assert.Throws<ArgumentNullException>(() => target.GetOrderTotal(null));
        }

        [Fact]
        public void GetOrderTotalTest()
        {
            var order = BuildOrder();

            var expected = 10.5f;

            _orderItemProcessingStrategy.Setup(x => x.GetOrderItemTotal(It.IsAny<OrderItem>(), It.IsAny<Location>())).Returns(expected);

            var target = BuildTestTarget();

            var result = target.GetOrderTotal(order);

            Assert.Equal(expected, result);
        }

        private Order BuildOrder()
        {
            return new Order
            (
                new List<OrderItem>
                {
                    new OrderItem(new Item(1, "Cheese Burger", 10.5f), 1, OrderItemType.Material)
                }
            );
        }

        public IOrderProcessor BuildTestTarget()
        {
            return new OrderProcessor(_orderItemStrategyFactory.Object);
        }
    }
}

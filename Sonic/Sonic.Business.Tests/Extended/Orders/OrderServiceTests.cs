using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Sonic.Business.Extended.Orders;
using Sonic.Business.Extended.Orders.Processor;
using Sonic.Business.Tests.Utils;
using Sonic.DTO.Extended.Orders;
using Sonic.DTO.Extended.Orders.Items;

namespace Sonic.Business.Tests.Extended.Orders
{
    public class OrderServiceTests
    {
        private Mock<IOrderProcessor> _orderProcessor;
        private OrderBuilderUtils _builderUtils;

        public OrderServiceTests()
        {
            _orderProcessor = new Mock<IOrderProcessor>();
            _builderUtils = new OrderBuilderUtils();
        }

        [Fact]
        public void NullOrderThrowsArgumentNullException()
        {
            var target = BuildTestTarget();

            Assert.Throws<ArgumentNullException>(() => target.GetOrderTotal(null));
        }

        [Fact]
        public void OrderProcessorCalledTest()
        {
            var order = _builderUtils.BuildEmptyOrder();

            var expected = 10.5f;

            _orderProcessor.Setup(x => x.GetOrderTotal(It.IsAny<Order>())).Returns(expected);

            var target = BuildTestTarget();

            var result = target.GetOrderTotal(order);

            Assert.Equal(expected, result);

            _orderProcessor.Verify(x => x.GetOrderTotal(It.IsAny<Order>()), Times.Once);
        }

        private IOrderService BuildTestTarget()
        {
            return new OrderService(_orderProcessor.Object);
        }
    }
}

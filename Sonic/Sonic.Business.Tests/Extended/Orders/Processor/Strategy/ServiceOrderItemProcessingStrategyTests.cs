using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Xunit;
using Sonic.Business.Extended.Orders.Processor.Strategy;
using Sonic.Business.Extended.Orders.Processor.Taxes;
using Sonic.Business.Tests.Utils;
using Sonic.DTO.Extended.Orders.Items;
using Sonic.DTO.Extended.Orders;
using Sonic.DTO.Extended.Store;
using Sonic.DTO.Basic.Items;

namespace Sonic.Business.Tests.Extended.Orders.Processor.Strategy
{
    public class ServiceOrderItemProcessingStrategyTests
    {
        private OrderBuilderUtils _builderUtils;

        public ServiceOrderItemProcessingStrategyTests()
        {
            _builderUtils = new OrderBuilderUtils();
        }

        [Fact]
        public void BasicServiceOrderItemGetOrderTotalTest()
        {
            var orderItem = _builderUtils.BuildOrderItem(1, "Delivery Service", 5.5f, 1, OrderItemType.Service);

            var location = _builderUtils.BuildLocation();

            var target = BuildTestTarget();

            var result = target.GetOrderItemTotal(orderItem, location);

            // 5.5 * 1 = 5.5
            var expected = 5.5f;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ServiceOrderItemGetOrderTotalTest()
        {
            var orderItem = _builderUtils.BuildOrderItem(1, "Delivery Service", 5.5f, 13, OrderItemType.Service);

            var location = _builderUtils.BuildLocation();

            var target = BuildTestTarget();

            var result = target.GetOrderItemTotal(orderItem, location);

            // 5.5 * 13 = 71.5
            var expected = 71.5f;

            Assert.Equal(expected, result);
        }

        private IOrderItemProcessingStrategy BuildTestTarget()
        {
            return new ServiceOrderItemProcessingStrategy();
        }
    }
}

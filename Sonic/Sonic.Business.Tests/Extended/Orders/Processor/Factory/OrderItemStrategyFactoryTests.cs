using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Sonic.Business.Extended.Orders.Processor.Strategy.Factory;
using Sonic.Business.Extended.Orders.Processor.Strategy;
using Sonic.Business.Extended.Orders.Processor.Taxes;
using Sonic.Business.Tests.Utils;
using Sonic.DTO.Extended.Orders.Items;
using Sonic.DTO.Basic.Items;

namespace Sonic.Business.Tests.Extended.Orders.Processor.Factory
{
    public class OrderItemStrategyFactoryTests
    {
        private Mock<ITaxRateService> _taxRateService;
        private OrderBuilderUtils _builderUtils;

        public OrderItemStrategyFactoryTests()
        {
            _taxRateService = new Mock<ITaxRateService>();
            _builderUtils = new OrderBuilderUtils();
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

            var orderItem = _builderUtils.BuildOrderItem(1, "Cheese Burger", 5.5f, 1, OrderItemType.Material);

            var target = BuildTestTarget();

            var result = target.GetOrderItemProcessingStrategy(orderItem);

            Assert.Equal(expected, result.GetType());
        }

        [Fact]
        private void GetServiceOrderItemProcessingStrategyTest()
        {
            var expected = typeof(ServiceOrderItemProcessingStrategy);

            var orderItem = _builderUtils.BuildOrderItem(1, "Cheese Burger", 5.5f, 1, OrderItemType.Service);

            var target = BuildTestTarget();

            var result = target.GetOrderItemProcessingStrategy(orderItem);

            Assert.Equal(expected, result.GetType());
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
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
    public class MaterialOrderItemProcessingStrategyTests
    {
        private float _salesTax = .08625f;
        private Mock<ITaxRateService> _taxRateService;
        private OrderBuilderUtils _builderUtils;

        public MaterialOrderItemProcessingStrategyTests()
        {
            _taxRateService = new Mock<ITaxRateService>();
            _taxRateService.Setup(x => x.GetTaxRate(It.IsAny<Location>())).Returns(_salesTax);
            _builderUtils = new OrderBuilderUtils();
        }

        [Fact]
        public void BasicMaterialOrderItemGetOrderTotalTest()
        {
            var orderItem = _builderUtils.BuildOrderItem(1, "Cheese Burger", 5.5f, 1, OrderItemType.Material);

            var location = _builderUtils.BuildLocation();

            var target = BuildTestTarget();

            var result = target.GetOrderItemTotal(orderItem, location);

            // 5.5 + .474375 = 5.974375
            var expected = 5.974375f;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void MaterialOrderItemQuantityGetOrderTotalTest()
        {
            var orderItem = _builderUtils.BuildOrderItem(1, "Cheese Burger", 5.5f, 13, OrderItemType.Material);

            var location = _builderUtils.BuildLocation();

            var target = BuildTestTarget();

            var result = target.GetOrderItemTotal(orderItem, location);

            // 71.5 + 6.166875 = 77.66688
            var expected = 77.66688f;

            Assert.Equal(expected, result);
        }

        private IOrderItemProcessingStrategy BuildTestTarget()
        {
            return new MaterialOrderItemProcessingStrategy(_taxRateService.Object);
        }
    }
}

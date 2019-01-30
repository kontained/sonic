using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Sonic.Business.Extended.Orders.Processor.Taxes;
using Sonic.Business.Tests.Utils;
using Sonic.DTO.Extended.Store;

namespace Sonic.Business.Tests.Extended.Orders.Processor.Taxes
{
    public class TaxRateServiceTests
    {
        private OrderBuilderUtils _builderUtils;

        public TaxRateServiceTests()
        {
            _builderUtils = new OrderBuilderUtils();
        }

        [Fact]
        public void GetTaxRateTest()
        {
            var location = _builderUtils.BuildLocation();

            var expected = 0.08625f;

            var target = BuildTestTarget();

            var result = target.GetTaxRate(location);

            Assert.Equal(expected, result);
        }

        private ITaxRateService BuildTestTarget()
        {
            return new TaxRateService();
        }
    }
}

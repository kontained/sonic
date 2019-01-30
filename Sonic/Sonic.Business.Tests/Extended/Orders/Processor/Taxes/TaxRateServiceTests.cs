using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Sonic.Business.Extended.Orders.Processor.Taxes;
using Sonic.DTO.Extended.Store;

namespace Sonic.Business.Tests.Extended.Orders.Processor.Taxes
{
    public class TaxRateServiceTests
    {
        [Fact]
        public void GetTaxRateTest()
        {
            var location = BuildLocation();

            var expected = 0.08625f;

            var target = BuildTestTarget();

            var result = target.GetTaxRate(location);

            Assert.Equal(expected, result);
        }

        private Location BuildLocation()
        {
            return new Location();
        }

        private ITaxRateService BuildTestTarget()
        {
            return new TaxRateService();
        }
    }
}

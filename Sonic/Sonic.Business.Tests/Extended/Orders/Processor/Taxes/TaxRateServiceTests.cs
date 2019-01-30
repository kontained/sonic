using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Sonic.Business.Extended.Orders.Processor.Taxes;
using Sonic.Business.Tests.Utils;
using Sonic.DataAccess.Extended.Orders.Processor.Taxes;
using Sonic.DTO.Extended.Store;

namespace Sonic.Business.Tests.Extended.Orders.Processor.Taxes
{
    public class TaxRateServiceTests
    {
        private Mock<IDATaxRateService> _daTaxRateService;

        private OrderBuilderUtils _builderUtils;


        public TaxRateServiceTests()
        {
            _daTaxRateService = new Mock<IDATaxRateService>();
            _builderUtils = new OrderBuilderUtils();
        }

        [Fact]
        public void GetTaxRateTest()
        {
            var location = _builderUtils.BuildLocation();

            var expected = 0.08625f;

            _daTaxRateService.Setup(x => x.GetTaxRate(It.IsAny<Location>())).Returns(expected);

            var target = BuildTestTarget();

            var result = target.GetTaxRate(location);

            Assert.Equal(expected, result);
        }

        private ITaxRateService BuildTestTarget()
        {
            return new TaxRateService(_daTaxRateService.Object);
        }
    }
}

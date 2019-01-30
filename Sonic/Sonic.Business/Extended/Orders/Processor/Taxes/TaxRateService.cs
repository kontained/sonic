using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DataAccess.Extended.Orders.Processor.Taxes;
using Sonic.DTO.Extended.Store;

namespace Sonic.Business.Extended.Orders.Processor.Taxes
{
    public class TaxRateService : ITaxRateService
    {
        private IDATaxRateService _daTaxRateService;

        public TaxRateService(IDATaxRateService daTaxRateService)
        {
            _daTaxRateService = daTaxRateService;
        }

        public float GetTaxRate(Location storeLocation)
        {
            return _daTaxRateService.GetTaxRate(storeLocation);
        }
    }
}

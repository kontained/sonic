using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Extended.Store;

namespace Sonic.Business.Extended.Orders.Processor.Taxes
{
    public class TaxRateService : ITaxRateService
    {
        private float _taxRate = .08625f;

        public float GetTaxRate(Location storeLocation)
        {
            // Normally this value would come from a data access class below the business layer.
            // Since we don't have a database here, I'll cheat a bit. :)
            return _taxRate;
        }
    }
}

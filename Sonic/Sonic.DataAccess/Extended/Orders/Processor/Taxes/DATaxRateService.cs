using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Extended.Store;

namespace Sonic.DataAccess.Extended.Orders.Processor.Taxes
{
    public class DATaxRateService : IDATaxRateService
    {
        private float _taxRate = .08625f;

        public float GetTaxRate(Location storeLocation)
        {
            // Normally this value would come from the database
            // but Since we don't have a database here, I'll cheat a bit. :)
            return _taxRate;
        }
    }
}

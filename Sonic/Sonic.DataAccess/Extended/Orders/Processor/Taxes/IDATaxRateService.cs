using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Extended.Store;

namespace Sonic.DataAccess.Extended.Orders.Processor.Taxes
{
    public interface IDATaxRateService
    {
        /// <summary>
        /// Retrieves the applicable tax rate for the store.
        /// </summary>
        /// <param name="storeLocation"></param>
        /// <returns></returns>
        float GetTaxRate(Location storeLocation);
    }
}

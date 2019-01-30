using System;
using System.Collections.Generic;
using System.Text;
using Sonic.Business.Extended.Orders.Processor.Taxes;
using Sonic.DTO.Extended.Orders.Items;
using Sonic.DTO.Extended.Store;

namespace Sonic.Business.Extended.Orders.Processor.Strategy
{
    public class MaterialOrderItemProcessingStrategy : IOrderItemProcessingStrategy
    {
        private ITaxRateService _taxRateService;

        public MaterialOrderItemProcessingStrategy(ITaxRateService taxRateService)
        {
            _taxRateService = taxRateService;
        }

        public float GetOrderItemTotal(OrderItem orderItem, Location storeLocation)
        {
            var price = (orderItem.Item.Price * orderItem.Quantity);
            var salesTax = price * _taxRateService.GetTaxRate(storeLocation);
            var totalPrice = price + salesTax;

            return totalPrice;
        }
    }
}

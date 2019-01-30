using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Extended.Orders.Items;
using Sonic.DTO.Extended.Store;

namespace Sonic.Business.Extended.Orders.Processor.Strategy
{
    public interface IOrderItemProcessingStrategy
    {
        /// <summary>
        /// Retrieves the total price for an order item.
        /// </summary>
        /// <param name="orderItem"></param>
        /// <param name="storeLocation"></param>
        /// <returns></returns>
        float GetOrderItemTotal(OrderItem orderItem, Location storeLocation);
    }
}

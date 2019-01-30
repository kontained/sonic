using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Extended.Orders.Items;

namespace Sonic.Business.Extended.Orders.Processor.Strategy.Factory
{
    public interface IOrderItemStrategyFactory
    {
        /// <summary>
        /// Retrieves a processing strategy for an order item.
        /// </summary>
        /// <param name="orderItem"></param>
        /// <returns></returns>
        IOrderItemProcessingStrategy GetOrderItemProcessingStrategy(OrderItem orderItem);
    }
}

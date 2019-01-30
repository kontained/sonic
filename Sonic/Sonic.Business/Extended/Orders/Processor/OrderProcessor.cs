using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Extended.Orders;
using Sonic.Business.Extended.Orders.Processor.Strategy.Factory;

namespace Sonic.Business.Extended.Orders.Processor
{
    public class OrderProcessor : IOrderProcessor
    {
        private IOrderItemStrategyFactory _orderItemStrategyFactory;

        public OrderProcessor(IOrderItemStrategyFactory orderItemStrategyFactory)
        {
            _orderItemStrategyFactory = orderItemStrategyFactory;
        }

        public float GetOrderTotal(Order order)
        {
            if (order == null) { throw new ArgumentNullException("Order cannot be null in OrderProcessor.GetOrderTotal!"); }

            float totalPrice = 0;

            foreach (var item in order.OrderItems)
            {
                totalPrice += _orderItemStrategyFactory.GetOrderItemProcessingStrategy(item).GetOrderItemTotal(item, order.StoreLocation);
            }

            return (float)Math.Round(totalPrice, 2, MidpointRounding.AwayFromZero);
        }
    }
}

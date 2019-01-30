using System;
using System.Collections.Generic;
using System.Text;
using Sonic.Business.Extended.Orders.Processor.Strategy;
using Sonic.DTO.Extended.Orders.Items;
using Sonic.DTO.Extended.Orders;

namespace Sonic.Business.Extended.Orders.Processor.Strategy.Factory
{
    public class OrderItemStrategyFactory : IOrderItemStrategyFactory
    {
        private IDictionary<OrderItemType, IOrderItemProcessingStrategy> _orderItemProcessingStrategyMap;

        public OrderItemStrategyFactory(
            IOrderItemProcessingStrategy materialOrderItemProcessingStrategy,
            IOrderItemProcessingStrategy serviceOrderItemProcessingStrategy)
        {
            _orderItemProcessingStrategyMap = new Dictionary<OrderItemType, IOrderItemProcessingStrategy>
            {
                { OrderItemType.Material, materialOrderItemProcessingStrategy },
                { OrderItemType.Service, serviceOrderItemProcessingStrategy }
            };
        }
        public IOrderItemProcessingStrategy GetOrderItemProcessingStrategy(OrderItem orderItem)
        {
            if (orderItem == null) { throw new ArgumentNullException("OrderItem cannot be null in OrderItemStrategyFactory.GetOrderItemProcesingStrategy!"); }

            if (_orderItemProcessingStrategyMap.ContainsKey(orderItem.Type))
            {
                return _orderItemProcessingStrategyMap[orderItem.Type];
            }

            throw new ArgumentOutOfRangeException("Order type not found in OrderItemStrategyFactory.GetOrderItemProcesingStrategy!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Extended.Orders.Items;
using Sonic.DTO.Extended.Store;

namespace Sonic.Business.Extended.Orders.Processor.Strategy
{
    public class ServiceOrderItemProcessingStrategy : IOrderItemProcessingStrategy
    {
        public float GetOrderItemTotal(OrderItem orderItem, Location storeLocation)
        {
            var totalPrice = orderItem.Item.Price * orderItem.Quantity;

            return totalPrice;
        }
    }
}

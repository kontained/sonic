using System;
using System.Collections.Generic;
using System.Text;
using Sonic.Business.Extended.Orders.Processor;
using Sonic.DTO.Extended.Orders;

namespace Sonic.Business.Extended.Orders
{
    public class OrderService : IOrderService
    {
        private IOrderProcessor _orderProcessor;

        public OrderService(IOrderProcessor orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }

        public float GetOrderTotal(Order order)
        {
            if (order == null) { throw new ArgumentNullException("Order cannot be null in OrderService.GetOrderTotal!"); }

            return _orderProcessor.GetOrderTotal(order);
        }
    }
}

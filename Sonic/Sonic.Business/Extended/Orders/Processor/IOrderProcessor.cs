using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Extended.Orders;

namespace Sonic.Business.Extended.Orders.Processor
{
    public interface IOrderProcessor
    {
        /// <summary>
        /// Gets the total price of an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>float</returns>
        float GetOrderTotal(Order order);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Extended.Orders;

namespace Sonic.Business.Extended.Orders
{
    public interface IOrderService
    {
        /// <summary>
        /// Gets the total price of an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        float GetOrderTotal(Order order);
    }
}

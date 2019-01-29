using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonic.DTO.Order.Items;

namespace Sonic.DTO.Order
{
    public class Order
    {
        private OrderItem[] _orderItems;

        public Order(OrderItem[] orderItems)
        {
            _orderItems = orderItems;
        }

        public float GetOrderTotal(float taxRate)
        {
            throw new NotImplementedException();
        }

        public ICollection<OrderItem> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}

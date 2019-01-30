using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sonic.DTO.Basic.Items;
using Sonic.DTO.Basic.Orders.Items;

namespace Sonic.DTO.Basic.Orders
{
    [Serializable]
    public class Order
    {
        private OrderItem[] _orderItems;

        public Order(OrderItem[] orderItems)
        {
            _orderItems = orderItems;
        }

        public float GetOrderTotal(float taxRate)
        {
            float totalPrice = 0;

            foreach (var item in _orderItems)
            {
                if (item.GetType() == typeof(MaterialOrderItem))
                {
                    totalPrice += CalculateMaterialOrderItemPrice(item, taxRate);
                }
                else if (item.GetType() == typeof(ServiceOrderItem))
                {
                    totalPrice += CalculateServiceOrderItemPrice(item);
                }
            }

            return (float)Math.Round(totalPrice, 2, MidpointRounding.AwayFromZero);
        }

        public ICollection<Item> GetItems()
        {
            var items = _orderItems.Select(x => x.Item);

            return items.OrderBy(x => x.Name).ToList();
        }

        private float CalculateMaterialOrderItemPrice(OrderItem orderItem, float taxRate)
        {
            var price = CalculateBasePrice(orderItem);
            var salesTax = price * taxRate;
            var totalPrice = price + salesTax;

            return totalPrice;
        }

        private float CalculateServiceOrderItemPrice(OrderItem orderItem)
        {
            var totalPrice = CalculateBasePrice(orderItem);

            return totalPrice;
        }

        private float CalculateBasePrice(OrderItem orderItem)
        {
            return (orderItem.Item.Price * orderItem.Quantity);
        }
    }
}

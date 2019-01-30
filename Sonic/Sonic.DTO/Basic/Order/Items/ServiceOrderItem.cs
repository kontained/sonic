using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Basic.Items;

namespace Sonic.DTO.Basic.Order.Items
{
    public class ServiceOrderItem : OrderItem
    {
        public ServiceOrderItem(Item item, int quantity) : base(item, quantity) { }

        public override float CalculateOrderPrice(float taxRate = 0.0f)
        {
            var totalPrice = Item.Price * Quantity;

            return (float)Math.Round(totalPrice, 2, MidpointRounding.AwayFromZero);
        }
    }
}

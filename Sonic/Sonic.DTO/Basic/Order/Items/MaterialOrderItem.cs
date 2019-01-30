using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Basic.Items;

namespace Sonic.DTO.Basic.Order.Items
{
    public class MaterialOrderItem : OrderItem
    {
        public MaterialOrderItem(Item item, int quantity) : base(item, quantity) { }

        public override float CalculateOrderPrice(float taxRate)
        {
            var price = (Item.Price * Quantity);
            var salesTax = price * taxRate;
            var totalPrice = price + salesTax;

            return (float)Math.Round(totalPrice, 2, MidpointRounding.AwayFromZero);
        }
    }
}

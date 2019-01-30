using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Basic.Items;

namespace Sonic.DTO.Basic.Orders.Items
{
    [Serializable]
    public abstract class OrderItem
    {
        public OrderItem(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public Item Item { get; }
        public int Quantity { get; }
    }
}

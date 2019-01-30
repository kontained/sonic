using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Basic.Items;

namespace Sonic.DTO.Extended.Orders.Items
{
    public enum OrderItemType
    {
        Material = 1,
        Service = 2
    }

    public class OrderItem
    {
        public OrderItem(Item item, int quantity, OrderItemType type)
        {
            Item = item;
            Quantity = quantity;
            Type = type;
        }

        public Item Item { get; }
        public int Quantity { get; }
        public OrderItemType Type { get; }
    }
}

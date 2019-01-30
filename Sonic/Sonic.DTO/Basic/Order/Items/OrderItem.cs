using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Basic.Items;

namespace Sonic.DTO.Basic.Order.Items
{
    public abstract class OrderItem
    {
        public Item Item{ get; }
        public int Quantity { get; }
    }
}

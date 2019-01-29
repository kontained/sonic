using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Items;

namespace Sonic.DTO.Order.Items
{
    public class OrderItem
    {
        public Item Item{ get; }
        public int Quantity { get; }
    }
}

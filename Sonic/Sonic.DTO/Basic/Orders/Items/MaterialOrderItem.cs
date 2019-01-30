using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Basic.Items;

namespace Sonic.DTO.Basic.Orders.Items
{
    [Serializable]
    public class MaterialOrderItem : OrderItem
    {
        public MaterialOrderItem(Item item, int quantity) : base(item, quantity) { }
    }
}

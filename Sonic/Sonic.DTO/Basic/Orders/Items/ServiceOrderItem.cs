using System;
using System.Collections.Generic;
using System.Text;
using Sonic.DTO.Basic.Items;

namespace Sonic.DTO.Basic.Orders.Items
{
    [Serializable]
    public class ServiceOrderItem : OrderItem
    {
        public ServiceOrderItem(Item item, int quantity) : base(item, quantity) { }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sonic.DTO.Items
{
    public class Item
    {
        public Item(int key, string name, float price)
        {
            Key = key;
            Name = name;
            Price = price;
        }

        public int Key { get; }

        public string Name { get; }

        public float Price { get; }
    }
}

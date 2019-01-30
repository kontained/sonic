using System;
using System.Collections.Generic;
using System.Text;

namespace Sonic.DTO.Basic.Items
{
    [Serializable]
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

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + Key.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                hash = hash * 23 + Price.GetHashCode();

                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var item = obj as Item;

            return
                Key == item.Key &&
                Name == item.Name &&
                Price == item.Price;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Sonic.DTO.Basic.Items;

namespace Sonic.DTO.Tests.Basic.Items
{
    public class ItemTests
    {
        [Fact]
        public void GetHashCodeEqualTest()
        {
            var item1 = new Item(1, "Cheeseburger", 5.50f);
            var item2 = new Item(1, "Cheeseburger", 5.50f);

            Assert.Equal(item1.GetHashCode(), item2.GetHashCode());
        }

        [Fact]
        public void GetHashCodeNotEqualTest()
        {
            var item1 = new Item(1, "Cheeseburger", 5.50f);
            var item2 = new Item(2, "Corn Dog", 2.353f);

            Assert.NotEqual(item1.GetHashCode(), item2.GetHashCode());
        }

        [Fact]
        public void EqualsTrueTest()
        {
            var item1 = new Item(1, "Cheeseburger", 5.50f);
            var item2 = new Item(1, "Cheeseburger", 5.50f);

            Assert.True(item1.Equals(item2));
            Assert.True(item2.Equals(item1));
        }

        [Fact]
        public void EqualsFalseTest()
        {
            var item1 = new Item(1, "Cheeseburger", 5.50f);
            var item2 = new Item(2, "Corn Dog", 2.353f);

            Assert.False(item1.Equals(item2));
            Assert.False(item2.Equals(item1));
        }
    }
}

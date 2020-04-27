using System;
using System.Collections.Generic;
using Hobgoblin.Model;

namespace Hobgoblin.Utils
{
    public class ShopData
    {
        public List<Item> items;
        public int selectedItemIndex;
        public int itemCount;
        public ShopData()
        {
            items = new List<Item>();
            selectedItemIndex = 0;
            itemCount = 0;
        }
    }
}

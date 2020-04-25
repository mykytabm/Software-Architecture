using System;
using System.Collections.Generic;
using Hobgoblin.Model;

namespace Hobgoblin.Utils
{
    public class ShopData
    {
        public List<Item> items = new List<Item>(); //items in the store
        public int selectedItemIndex;
        public int itemCount;
    }
}

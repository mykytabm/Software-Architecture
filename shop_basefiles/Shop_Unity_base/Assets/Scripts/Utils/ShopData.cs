using System;
using System.Collections.Generic;
using Hobgoblin.Model;

namespace Hobgoblin.Utils
{
    public class ShopData
    {
        public List<Item> items;
        public List<string> messages;
        public int itemCount;
        public Item selectedItem;
        public int selectedItemIndex;
        public ShopData()
        {
            items = new List<Item>();
            messages = new List<string>();
            itemCount = 0;
            selectedItem = null;
            selectedItemIndex = 0;
        }
    }
}

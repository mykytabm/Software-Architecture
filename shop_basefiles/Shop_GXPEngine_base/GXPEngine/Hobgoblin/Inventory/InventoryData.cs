using System;
using System.Collections.Generic;
using Hobgoblin.Model;
namespace Hobgoblin.InventoryMvc
{
    public class InventoryData
    {
        public List<Item> items;
        public int gold;
        public int selectedItemIndex;
        public int itemCount;
        public InventoryData()
        {
            items = new List<Item>();
            gold = 0;
            selectedItemIndex = 0;
            itemCount = 0;
        }
    }
}

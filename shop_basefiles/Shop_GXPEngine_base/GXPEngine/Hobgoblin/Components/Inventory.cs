using System;
using System.Collections.Generic;
using Hobgoblin.Core;
using Hobgoblin.Model;
using Hobgoblin.Enums;

namespace Hobgoblin.Components
{
    public class Inventory : Component
    {
        private List<Item> _items;


        public Inventory(int pSlots)
        {
            _items = new List<Item>(pSlots);
        }

        public bool AddItem(Item pItem)
        {
            _items.Add(pItem);
            return true;
        }

        private bool StackItem(Item pItem)
        {
            return false;
        }

        private bool SameItemExists(Item pItem)
        {
            return _items.Exists(item => item == pItem);
        }
    }
}

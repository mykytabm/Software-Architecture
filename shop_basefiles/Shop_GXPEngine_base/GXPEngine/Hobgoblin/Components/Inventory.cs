using System;
using System.Collections.Generic;
using Hobgoblin.Core;
using Hobgoblin.Model;
using Hobgoblin.Utils;
using Hobgoblin.Enums;

namespace Hobgoblin.Components
{
    public class Inventory : Component
    {
        private List<Item> _items;
        private int _gold;

        public int Gold { get { return _gold; } }

        public Inventory(int pSlots, int pGold)
        {
            _items = new List<Item>(pSlots);
            _gold = pGold;
        }
        public Inventory(List<Item> pItems, int pSlots, int pGold)
        {
            _items = pItems;
            _items.Capacity = _items.Count + pSlots;
            _gold = pGold;
        }

        public void AddItem(Item pItem)
        {
            _items.Add(pItem);
        }

        private bool StackItem(Item pItem)
        {
            return false;
        }

        public List<Item> GetItems()
        {
            return HUtils.DeepCopyList(_items);
        }
        private bool SameItemExists(Item pItem)
        {
            return _items.Exists(item => item == pItem);
        }
    }
}

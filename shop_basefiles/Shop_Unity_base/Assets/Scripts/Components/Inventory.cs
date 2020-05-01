using System;
using System.Collections.Generic;
using Hobgoblin.Core;
using Hobgoblin.Model;
using Hobgoblin.Utils;
using Hobgoblin.Enums;
using Hobgoblin.Interfaces;

namespace Hobgoblin.Components
{
    public class Inventory : Component, IPrototype
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

        public void RemoveItemAt(int pId)
        {
            if (pId >= 0 && pId < _items.Count)
            {
                _items.RemoveAt(pId);
            }
        }

        public void AddGold(int pGold)
        {
            _gold += pGold;
        }

        public void AddItem(Item pItem)
        {
            _items.Add(pItem);
        }
        public Item GetItemAt(int pId)
        {
            if (pId >= 0 && pId < _items.Count)
            {
                return (Item)_items[pId].Clone();
            }
            else
            {
                return null;
            }
        }
        public void RemoveItem(Item pItem)
        {
            _items.Remove(pItem);
        }

        public List<Item> GetItems()
        {
            return HUtils.DeepCopyList(_items);
        }

        private bool SameItemExists(Item pItem)
        {
            return _items.Exists(item => item == pItem);
        }

        public override IPrototype Clone()
        {
            var deepCopyItemList = HUtils.DeepCopyList(_items);
            return new Inventory(deepCopyItemList, deepCopyItemList.Capacity - deepCopyItemList.Count, _gold);
        }
    }
}

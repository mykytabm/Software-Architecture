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
        public Action ContentUpdated;
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
            ContentUpdated?.Invoke();
        }

        public void AddItem(Item pItem)
        {
            _items.Add(pItem);
            ContentUpdated?.Invoke();
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
            ContentUpdated?.Invoke();
        }
        public int GetItemIndex(Item pItem)
        {
            if (_items.Contains(pItem))
            {
                return _items.IndexOf(pItem);
            }
            else
            {
                return -1;
            }
        }

        public List<Item> GetItems()
        {
            return HUtils.DeepCopyList(_items);
        }

        public override IPrototype Clone()
        {
            var deepCopyItemList = HUtils.DeepCopyList(_items);
            return new Inventory(deepCopyItemList, deepCopyItemList.Capacity - deepCopyItemList.Count, _gold);
        }
    }
}

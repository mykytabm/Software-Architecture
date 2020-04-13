using System;
using System.Collections.Generic;
using GXPEngine;
using Model;
namespace Core
{
    public class Player : GameObject
    {
        Inventory _inventory;
        public Player()
        {
            _inventory = new Inventory(10);
        }
        public void Buy(Item pItem)
        {
            _inventory.AddItem(pItem);
        }
        public void Sell(Item pItem)
        {
        }
    }

    public class Inventory
    {
        private List<Item> _items;
        private Dictionary<Item, int> _inv;

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

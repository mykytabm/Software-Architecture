using System;
using System.Collections.Generic;
using GXPEngine;
using Hobgoblin.Model;
using Hobgoblin.Components;
using Hobgoblin.Utils;
namespace Hobgoblin.Core
{
    public class Player : GGameObject
    {
        //Inventory _inventory;
        //InputController _inputController;
        public Player()
        {
            //_inventory = new Inventory(10);
            //_inputController = new InputController();
            //_inputController.AddEvent(new KeyEvent(Key.W, MoveUp));
            //AddComponent(_inputController);
        }
        public void Buy(Item pItem)
        {
            //_inventory.AddItem(pItem);
        }
        public void Sell(Item pItem)
        {
        }
        public void MoveUp()
        {
            Console.WriteLine("moving up");
        }
        public void MoveDown()
        {
            Console.WriteLine("moving down");
        }
        public override void Update()
        {
            base.Update();
        }
    }

    public class Inventory
    {
        private List<Item> _items;
        //private Dictionary<Item, int> _inv;

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

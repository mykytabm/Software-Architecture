using System;
using System.Collections.Generic;
using Hobgoblin.Components;
using Hobgoblin.Model;
using Hobgoblin.Utils;

namespace Hobgoblin.InventoryMvc
{
    public class InventoryModel : IObservable<InventoryData>
    {
        private List<IObserver<InventoryData>> _observers;
        private InventoryData _data;

        private List<string> _messages;
        private const int MaxMessageQueueCount = 4; //it caches the last four messages
        private int _selectedItemIndex = 0;
        private Inventory _inventory;

        public InventoryModel(Inventory pInventory)
        {
            _inventory = pInventory;
            _observers = new List<IObserver<InventoryData>>();
            _messages = new List<string>();

            _data = new InventoryData();
            UpdateData();
        }

        public void RemoveCurrentItem()
        {
            _inventory.RemoveItemAt(_selectedItemIndex);
            if (_selectedItemIndex > _inventory.GetItems().Count - 1)
            {
                _selectedItemIndex = _inventory.GetItems().Count - 1;
            }
            else if (_selectedItemIndex < 0)
            {
                _selectedItemIndex = 0;
            }

            UpdateData();
            NotifyObservers();
        }

        public void AddGold(int pGold)
        {
            _inventory.AddGold(pGold);
        }

        public List<Item> GetItems()
        {
            return _inventory.GetItems();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  AddMessage()
        //------------------------------------------------------------------------------------------------------------------------
        //adds a message to the cache, cleaning it up if the limit is exceeded
        public void AddMessage(string message)
        {
            _messages.Add(message);
            while (_messages.Count > MaxMessageQueueCount)
            {
                _messages.RemoveAt(0);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetSelectedItem()
        //------------------------------------------------------------------------------------------------------------------------        
        //returns the selected item
        public Item GetSelectedItem()
        {
            return _inventory.GetItemAt(_selectedItemIndex);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  SelectItem()
        //------------------------------------------------------------------------------------------------------------------------
        //attempts to select the given item, fails silently
        public void SelectItem(Item pItem)
        {
            if (pItem != null && _inventory.GetItems().Contains(pItem))
            {
                int index = _inventory.GetItems().IndexOf(pItem);
                _selectedItemIndex = index;
                UpdateData();
                NotifyObservers();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  SelectItemByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        //attempts to select the item, specified by 'index', fails silently
        public void SelectItemByIndex(int index)
        {
            if (index >= 0 && index < _inventory.GetItems().Count)
            {
                _selectedItemIndex = index;
                UpdateData();
                NotifyObservers();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetSelectedItemIndex()
        //------------------------------------------------------------------------------------------------------------------------
        //returns the index of the current selected item
        public int GetSelectedItemIndex()
        {
            return _selectedItemIndex;
        }


        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetItemCount()
        //------------------------------------------------------------------------------------------------------------------------        
        //returns the number of items
        private int GetItemCount()
        {
            return _inventory.GetItems().Count;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetItemByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        //tries to get an item, specified by index. returns null if unsuccessful
        public Item GetItemByIndex(int pIndex)
        {
            return _inventory.GetItemAt(pIndex);
        }

        public IDisposable Subscribe(IObserver<InventoryData> observer)
        {
            // Check whether observer is already registered. If not, add it
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                // Provide observer with existing data.
                observer.OnNext(_data);
            }
            return new Unsubscriber<InventoryData>(_observers, observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(_data);
            }
        }

        private List<string> DeepCopyMessages()
        {
            //var deepCopyList = new List<string>();
            //foreach (var msg in _messages)
            //{
            //    deepCopyList.Add((string)msg.Clone());
            //}
            //return deepCopyList;
            return _messages;
        }

        public void UpdateData()
        {
            _data.items = _inventory.GetItems();
            _data.gold = _inventory.Gold;
            _data.selectedItemIndex = _selectedItemIndex;
            _data.itemCount = _inventory.GetItems().Count;
            _data.messages = DeepCopyMessages();

        }
    }
}

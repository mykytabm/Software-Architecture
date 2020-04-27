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

        private List<Item> _items;
        private int _selectedItemIndex = 0;
        private int _gold;


        public InventoryModel(Inventory pInventory)
        {
            _observers = new List<IObserver<InventoryData>>();
            _items = pInventory.GetItems();
            _gold = pInventory.Gold;
            _data = new InventoryData();
            UpdateData();
        }

        public List<Item> GetItems()
        {
            return HUtils.DeepCopyList(_items);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetSelectedItem()
        //------------------------------------------------------------------------------------------------------------------------        
        //returns the selected item
        public Item GetSelectedItem()
        {
            if (_selectedItemIndex >= 0 && _selectedItemIndex < _items.Count)
            {
                return _items[_selectedItemIndex];
            }
            else
            {
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  SelectItem()
        //------------------------------------------------------------------------------------------------------------------------
        //attempts to select the given item, fails silently
        public void SelectItem(Item item)
        {
            if (item != null)
            {
                int index = _items.IndexOf(item);
                if (index >= 0)
                {
                    _selectedItemIndex = index;
                    UpdateData();
                    NotifyObservers();
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  SelectItemByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        //attempts to select the item, specified by 'index', fails silently
        public void SelectItemByIndex(int index)
        {
            if (index >= 0 && index < _items.Count)
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
            return _items.Count;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetItemByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        //tries to get an item, specified by index. returns null if unsuccessful
        public Item GetItemByIndex(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                return _items[index];
            }
            else
            {
                return null;
            }
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

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(_data);
            }
        }

        private void UpdateData()
        {
            _data.items = GetItems();
            _data.gold = _gold;
            _data.selectedItemIndex = _selectedItemIndex;
            _data.itemCount = _items.Count;
        }
    }
}

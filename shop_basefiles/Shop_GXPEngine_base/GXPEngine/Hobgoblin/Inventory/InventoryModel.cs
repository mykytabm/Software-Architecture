using System;
using System.Collections.Generic;
using Hobgoblin.Model;
using Hobgoblin.Utils;

namespace Hobgoblin.Inventory
{
    public class InventoryModel : IObservable<InventoryData>
    {
        private List<IObserver<InventoryData>> _observers;
        private InventoryData _data;

        private List<Item> _items;
        private int _selectedItemIndex = 0;
        private int _gold;


        public InventoryModel(List<Item> pItems, int pGold)
        {
            _items = pItems;
            _gold = pGold;
            _data = new InventoryData();
            UpdateData();
        }

        private void UpdateData()
        {
            _data.items = GetItems();
            _data.gold = _gold;
            _data.selectedItemIndex = _selectedItemIndex;
            _data.itemCount = _items.Count;
        }

        public List<Item> GetItems()
        {
            return HUtils.DeepCopyList(_items);
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(_data);
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
    }
}

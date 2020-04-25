namespace Hobgoblin.Model
{
    using System;
    using System.Collections.Generic;
    using Utils;
    using View;

    //This class holds the model of our Shop. It contains an ItemList. In its current setup, view and controller need to get
    //data via polling. Advisable is, to set up an event system for better integration with View and Controller.
    public class ShopModel : IObservable<ShopData>
    {
        const int MaxMessageQueueCount = 4; //it caches the last four messages
        private List<string> messages = new List<string>();

        private List<Item> itemList; //items in the store
        private int _selectedItemIndex = 0; //selected item index
        private ShopData _shopData;

        private List<IObserver<ShopData>> _observers;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  ShopModel()
        //------------------------------------------------------------------------------------------------------------------------        
        public ShopModel(List<Item> pItems)
        {
            _selectedItemIndex = 3;
            Console.WriteLine("ctor");
            _observers = new List<IObserver<ShopData>>();
            itemList = new List<Item>(pItems);
            _shopData = new ShopData();
            _shopData.selectedItemIndex = _selectedItemIndex;
            _shopData.itemCount = GetItemCount();
            _shopData.items = pItems;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetSelectedItem()
        //------------------------------------------------------------------------------------------------------------------------        
        //returns the selected item
        public Item GetSelectedItem()
        {
            if (_selectedItemIndex >= 0 && _selectedItemIndex < itemList.Count)
            {
                return itemList[_selectedItemIndex];
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
                int index = itemList.IndexOf(item);
                if (index >= 0)
                {
                    _selectedItemIndex = index;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  SelectItemByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        //attempts to select the item, specified by 'index', fails silently
        public void SelectItemByIndex(int index)
        {
            if (index >= 0 && index < itemList.Count)
            {
                _selectedItemIndex = index;

                _shopData.selectedItemIndex = _selectedItemIndex;
                _shopData.itemCount = GetItemCount();
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
        //                                                  GetItems()
        //------------------------------------------------------------------------------------------------------------------------        
        //returns a list with all current items in the shop.
        public List<Item> GetItems()
        {                                    //TODO: apply prototype
            return new List<Item>(itemList); //returns a copy of the list, so the original is kept intact, 
                                             //however this is shallow copy of the original list, so changes in 
                                             //the original list will likely influence the copy, apply 
                                             //creational patterns like prototype to fix this. 
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetItemCount()
        //------------------------------------------------------------------------------------------------------------------------        
        //returns the number of items
        public int GetItemCount()
        {
            return itemList.Count;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetItemByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        //tries to get an item, specified by index. returns null if unsuccessful
        public Item GetItemByIndex(int index)
        {
            if (index >= 0 && index < itemList.Count)
            {
                return itemList[index];
            }
            else
            {
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetMessage()
        //------------------------------------------------------------------------------------------------------------------------        
        //returns the cached list of messages
        public string[] GetMessages()
        {
            return messages.ToArray();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  AddMessage()
        //------------------------------------------------------------------------------------------------------------------------
        //adds a message to the cache, cleaning it up if the limit is exceeded
        private void AddMessage(string message)
        {
            messages.Add(message);
            while (messages.Count > MaxMessageQueueCount)
            {
                messages.RemoveAt(0);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Buy()
        //------------------------------------------------------------------------------------------------------------------------        
        //not implemented yet TODO
        public bool Buy()
        {
            Item selectedItem = GetSelectedItem();
            if (selectedItem == null)
            {
                AddMessage("You can't buy this item!");
                return false;
            }
            selectedItem.amount--;

            if (selectedItem.amount <= 0)
            {
                itemList.Remove(selectedItem);
            }
            return true;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Sell()
        //------------------------------------------------------------------------------------------------------------------------        
        //not implemented yet TODO
        public void Sell()
        {
            if (GetSelectedItem() != null)
            {
                GetSelectedItem().amount++;
            }
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(_shopData);
            }
        }

        public IDisposable Subscribe(IObserver<ShopData> observer)
        {
            // Check whether observer is already registered. If not, add it
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                // Provide observer with existing data.
                Console.WriteLine("provide data");

                observer.OnNext(_shopData);
            }
            return new Unsubscriber<ShopData>(_observers, observer);
        }
    }
}

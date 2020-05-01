namespace Hobgoblin.Controller
{
    using System;
    using Core;
    using Hobgoblin.Model;


    public class ShopController
    {
        private ShopModel _shopModel;
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Initialize()
        //------------------------------------------------------------------------------------------------------------------------        
        //Ties this controller to a model
        public ShopController(ShopModel shopModel)
        {
            this._shopModel = shopModel;
            Browse();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  SelectItem()
        //------------------------------------------------------------------------------------------------------------------------
        //attempt to select an item
        public void SelectItem(Item pItem)
        {
            if (pItem != null)
            {
                _shopModel.SelectItem(pItem);
            }
        }

        public void AddMessage(string pMessage)
        {
            _shopModel.AddMessage(pMessage);
            UpdateShopData();
            UpdateView();
        }

        private void UpdateShopData()
        {
            _shopModel.UpdateShopData();
        }

        private void UpdateView()
        {
            _shopModel.NotifyObservers();
        }

        public int GetItemPrice()
        {
            return _shopModel.GetSelectedItem().price;
        }

        public void SelectItem(int pIndex)
        {
            _shopModel.SelectItemByIndex(pIndex);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Browse()
        //------------------------------------------------------------------------------------------------------------------------
        public void Browse()
        {
            _shopModel.SelectItemByIndex(0);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Buy()
        //------------------------------------------------------------------------------------------------------------------------        
        public Item SellItem()
        {
            return _shopModel.SellItem();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Sell()
        //------------------------------------------------------------------------------------------------------------------------        
       
        public int BuyItem(Item pItem)
        {
            return _shopModel.BuyItem(pItem);
        }
    }
}

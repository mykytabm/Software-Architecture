﻿namespace Hobgoblin.Controller
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
        public void Buy()
        {
            _shopModel.Buy();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Sell()
        //------------------------------------------------------------------------------------------------------------------------        
        public void Sell()
        {
            _shopModel.Sell();
        }
    }
}

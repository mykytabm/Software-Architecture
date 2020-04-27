using System;
using GXPEngine;
using Hobgoblin.Core;
namespace Hobgoblin.States
{
    using Hobgoblin.Model;
    using Hobgoblin.View;
    using Hobgoblin.Controller;
    using System.Collections.Generic;

    public class ShopBrowseState : HGameObject
    {
        private ShopController _shopController;
        private ShopView _shopView;
        private ShopMessageView _shopMessageView;
        private ItemInfoView _itemInfoView;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  ShopBrowseState()
        //------------------------------------------------------------------------------------------------------------------------
        public ShopBrowseState(List<Item> items, Actor pCustumer)
        {
            //create shop
            ShopModel shop = new ShopModel(items);

            //create controller
            _shopController = new ShopController(shop);


            //create shop view
            _shopView = new ShopView(_shopController, pCustumer);
            _shopView.Subscribe(shop);
            AddChild(_shopView);
            Helper.AlignToCenter(_shopView, true, true);

            //create item info view
            _itemInfoView = new ItemInfoView();
            _itemInfoView.Subscribe(shop);
            AddChild(_itemInfoView);


            //create message view
            _shopMessageView = new ShopMessageView();
            _shopMessageView.Subscribe(shop);
            AddChild(_shopMessageView);
            Helper.AlignToCenter(_shopMessageView, true, false);
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Step()
        //------------------------------------------------------------------------------------------------------------------------
        //update the views
        public void Step()
        {
            _shopView.Step();
            _shopMessageView.Step();
            _itemInfoView.Step();
        }

    }
}

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
        private ItemInfoView _itemIfoView;
        //public ShopCommandManager _shopCommandManager;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  ShopBrowseState()
        //------------------------------------------------------------------------------------------------------------------------
        public ShopBrowseState(List<Item> items)
        {
            //create shop
            ShopModel shop = new ShopModel(items);

            //create controller
            _shopController = new ShopController(shop);

            //_shopCommandManager = new ShopCommandManager(_shopController);


            //create shop view
            _shopView = new ShopView(_shopController);
            _shopView.Subscribe(shop);
            AddChild(_shopView);
            Helper.AlignToCenter(_shopView, true, true);

            //create item info view
            _itemIfoView = new ItemInfoView();
            _itemIfoView.Subscribe(shop);
            AddChild(_itemIfoView);
            

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
            _itemIfoView.Step();
        }

    }
}

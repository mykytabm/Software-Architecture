using System;
using GXPEngine;
using Core;
namespace States
{
    using Model;
    using View;
    using Controller;
    using System.Collections.Generic;

    public class ShopBrowseState : MBGameObject
    {
        private ShopController _shopController;
        private ShopView _shopView;
        private ShopMessageView _shopMessageView;
        public ShopCommandExecutor _shopCommandManager;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  ShopBrowseState()
        //------------------------------------------------------------------------------------------------------------------------
        public ShopBrowseState(List<Item> items)
        {
            //create shop
            ShopModel shop = new ShopModel(items);

            //create controller
            _shopController = new ShopController(shop);

            //create shop view
            _shopView = new ShopView(shop, _shopController);
            AddChild(_shopView);
            //shopView.Subscribe(shop);
            Helper.AlignToCenter(_shopView, true, true);

            _shopCommandManager = new ShopCommandExecutor(_shopController);
            ServiceLocator.Instance.AddService(_shopCommandManager);
            //create message view
            _shopMessageView = new ShopMessageView(shop);
            AddChild(_shopMessageView);
            //shopMessageView.Subscribe(shop);
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
        }

    }
}

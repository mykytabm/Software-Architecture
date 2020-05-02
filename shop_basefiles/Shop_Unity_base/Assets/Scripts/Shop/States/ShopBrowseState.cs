using System;
using UnityEngine;

namespace Hobgoblin.States
{
    using Hobgoblin.Core;
    using Hobgoblin.Model;
    using Hobgoblin.View;
    using Hobgoblin.Controller;

    //This state takes the model that is contained in the ModelContainer object, and allow us to browse it using
    //a controller and two views. Both views are on the same child. On renders the shop as icons, the other renders it
    //as text (messages). There is no event system, so the text is printed every frame.
    public class ShopBrowseState : MonoBehaviour
    {
        private ShopModel _shopModel;

        private ShopController _shopController;
        private ShopView _shopView;
        private ShopMessageView _shopMessageView;
        private ShopItemInfoView _shopItemInfoView;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Start()
        //------------------------------------------------------------------------------------------------------------------------
        protected void Start()
        {
            Initialize();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Initialize()
        //------------------------------------------------------------------------------------------------------------------------
        public void Initialize()
        {
            var itemGenerator = new Generator(new NormalItemFactory());
            //Set up the model and controller
            _shopModel = new ShopModel(itemGenerator.CreateRandomItems(Globals.ItemsPerShop));
            _shopController = new ShopController(_shopModel);

            //get view from children
            _shopView = GetComponentInChildren<ShopView>();
            _shopView.Subscribe(_shopModel);
            Debug.Assert(_shopView != null);

            //get mesageview from children
            _shopMessageView = GetComponentInChildren<ShopMessageView>();
            _shopMessageView.Subscribe(_shopModel);
            Debug.Assert(_shopMessageView != null);

            //get itemInfoView from children
            _shopItemInfoView = GetComponentInChildren<ShopItemInfoView>();
            _shopItemInfoView.Subscribe(_shopModel);

            //setup model and controller

            //link them


            _shopView.Initialize(_shopController, Game.PlayerHumanoid);//view1
            _shopMessageView.Initialize(_shopModel);//view2
        }

        public ShopController ShopController()
        {
            return _shopController;
        }

    }
}

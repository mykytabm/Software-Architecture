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
        private ShopModel shopModel;

        private ShopController shopController;
        private ShopView shopView;
        private ShopMessageView shopMessageView;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Start()
        //------------------------------------------------------------------------------------------------------------------------
        //This method gets the whole setup going
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
            shopModel = new ShopModel(itemGenerator.CreateRandomItems(Globals.ItemsPerShop));
            shopController = new ShopController(shopModel);

            //get view from children
            shopView = GetComponentInChildren<ShopView>();
            shopView.Subscribe(shopModel);
            Debug.Assert(shopView != null);

            //get mesageview from children
            shopMessageView = GetComponentInChildren<ShopMessageView>();
            shopMessageView.Subscribe(shopModel);
            Debug.Assert(shopMessageView != null);

            //setup model and controller

            //link them
            shopView.Initialize( shopController);//view1
            shopMessageView.Initialize(shopModel);//view2
        }

    }
}

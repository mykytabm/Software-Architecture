using System;
using Hobgoblin.Core;
using Hobgoblin.Components;
using Hobgoblin.InventoryMvc;
using Hobgoblin.Model;
using System.Collections.Generic;
using Hobgoblin.View;
using GXPEngine;
using Hobgoblin.Controller;

namespace Hobgoblin.States
{
    public class InventoryBrowseState : GameObject
    {
        private Inventory _inventory;
        private List<Item> _items;
        private HGameObject _owner;
        private InventoryModel _model;
        private InventoryView _view;
        private InventoryMessageView _messageView;
        private InventoryController _controller;

        public InventoryBrowseState(Inventory pInventory, ShopController pShopController = null)
        {
            _inventory = pInventory;

            _model = new InventoryModel(_inventory);

            _controller = new InventoryController(_model);

            _view = new InventoryView(_controller, pShopController);
            _view.Subscribe(_model);
            AddChild(_view);
            Helper.AlignToCenter(_view, true, true);
            _view.x = Globals.offsetX;

            _messageView = new InventoryMessageView();
            _messageView.Subscribe(_model);
            AddChild(_messageView);
            Helper.AlignToCenter(_messageView, true, false);
        }

        public void Step()
        {
            _view.Step();
            _messageView.Step();
        }

    }
}

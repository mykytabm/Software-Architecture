using System;
using Hobgoblin.Core;
using Hobgoblin.Components;
using Hobgoblin.InventoryMvc;
using Hobgoblin.Model;
using System.Collections.Generic;
using Hobgoblin.View;

namespace Hobgoblin.States
{
    public class InventoryBrowseState : HGameObject
    {
        private Inventory _inventory;
        private List<Item> _items;
        private HGameObject _owner;
        private InventoryModel _model;
        private InventoryView _view;
        private InventoryController _controller;

        public InventoryBrowseState(Inventory pInventory)
        {
            _inventory = pInventory;

            _model = new InventoryModel(_inventory);

            _controller = new InventoryController(_model);

            _view = new InventoryView(_controller);
            _view.Subscribe(_model);
            AddChild(_view);
            Helper.AlignToCenter(_view, true, true);
        }

        public void Step()
        {
            _view.Step();
        }

    }
}

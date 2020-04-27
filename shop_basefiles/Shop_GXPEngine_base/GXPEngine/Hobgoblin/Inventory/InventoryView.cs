using System;
using GXPEngine;
using Hobgoblin.Core;

namespace Hobgoblin.Inventory
{
    public class InventoryView:Canvas, IObserver<InventoryData>
    {
        const int Columns = 4;
        const int Spacing = 80;
        const int Margin = 18;

        private int _selectedItemId;
        private int _itemCount;

        private InventoryController _controller;
        private CommandManager _commandManager;
        
        public InventoryView() : base(340, 340)
        {

        }

        public void Subscribe(InventoryModel pProvider)
        {
            pProvider.Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception pError)
        {
            throw new NotImplementedException();
        }

        public void OnNext(InventoryData pData)
        {
         
        }
    }
}

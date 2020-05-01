using System;
using Hobgoblin.Interfaces;
using Hobgoblin.InventoryMvc;

namespace Hobgoblin.Commands.InventoryCommands
{
    public class MoveInventorySelectionCommand : ICommand
    {
        private InventoryController _inventoryController;
        private InventoryView _inventoryView;
        private int _newX;
        private int _newY;

        public MoveInventorySelectionCommand(
            InventoryController pController, InventoryView pView, int pNewX, int pNewY)
        {
            _inventoryController = pController;
            _inventoryView = pView;
            _newX = pNewX;
            _newY = pNewY;
        }

        public void Execute()
        {
            var newSelectedItemId = _inventoryView.GetNewSelectedItemId(_newX, _newY);
            _inventoryController.SelectItem(newSelectedItemId);
        }
    }
}

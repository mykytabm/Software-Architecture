using System;
using Hobgoblin.Controller;
using Hobgoblin.Interfaces;
using Hobgoblin.View;
using Hobgoblin.Enums;

namespace Hobgoblin.ShopCommands
{
    public class MoveSelectionCommand : ICommand
    {
        private ShopController _shopController;
        private ShopView _shopView;
        private int _newX;
        private int _newY;

        public MoveSelectionCommand(
            ShopController pShopController, ShopView pShopView, int pNewX, int pNewY)
        {
            _shopController = pShopController;
            _shopView = pShopView;
            _newX = pNewX;
            _newY = pNewY;
        }

        public void Execute()
        {
            //var newSelectedItemId = _shopView.GetNewSelectedItemId(_newX, _newY);
            //_shopController.SelectItem(newSelectedItemId);
        }
    }
}

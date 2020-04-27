using System;
using Hobgoblin.Controller;
using Hobgoblin.Interfaces;

namespace Hobgoblin.ShopCommands
{
    public class SellItemCommand : ICommand
    {
        private ShopController _shopController;

        public SellItemCommand(ShopController pShopController)
        {
            _shopController = pShopController;
        }

        public void Execute()
        {
            _shopController.Sell();
        }
    }
}

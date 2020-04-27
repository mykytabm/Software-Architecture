using System;
using Hobgoblin.Controller;
using Hobgoblin.Interfaces;

namespace Hobgoblin.ShopCommands
{
    public class BuyItemCommand : ICommand
    {
        private ShopController _shopController;
        public BuyItemCommand(ShopController pShopController)
        {
            _shopController = pShopController;
        }
        public void Execute()
        {
            _shopController.Buy();
        }
    }
}

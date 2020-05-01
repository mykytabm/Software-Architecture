using System;
using Hobgoblin.Components;
using Hobgoblin.Controller;
using Hobgoblin.Core;
using Hobgoblin.Interfaces;

namespace Hobgoblin.ShopCommands
{
    public class BuyItemCommand : ICommand
    {
        private Actor _customer;
        private ShopController _shopController;
        public BuyItemCommand(ShopController pShopController, Actor pCustomer)
        {
            _customer = pCustomer;
            _shopController = pShopController;
        }
        public void Execute()
        {
            var inventory = _customer.GetComponent<Inventory>();
            if (inventory.Gold > _shopController.GetItemPrice())
            {
                var itemToBuy = _shopController.SellItem();
                inventory.AddItem(itemToBuy);
                inventory.AddGold(-itemToBuy.price);
            }
            else
            {
                _shopController.AddMessage("You do not have enough gold");
            }
        }
    }
}

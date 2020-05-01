using System;
using Hobgoblin.Controller;
using Hobgoblin.Interfaces;
using Hobgoblin.InventoryMvc;
using Hobgoblin.Model;

namespace Hobgoblin.Commands.InventoryCommands
{
    public class SellItemCommand : ICommand
    {
        InventoryController _inventoryController;
        ShopController _shopController;
        public SellItemCommand(InventoryController pInventoryController, ShopController pShopController)
        {
            _inventoryController = pInventoryController;
            _shopController = pShopController;
        }

        public void Execute()
        {
            Item itemToSell = _inventoryController.GetSelectedItem();
            if (itemToSell != null)
            {
                itemToSell = (Item)itemToSell.Clone();
                int gold = _shopController.BuyItem(itemToSell);
                _inventoryController.RemoveCurrentItem();
                _inventoryController.AddGold(gold);
            }

        }
    }
}

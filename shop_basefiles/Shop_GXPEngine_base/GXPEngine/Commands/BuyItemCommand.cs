using System;
using Controller;
using Interfaces;

namespace Commands
{
    public class BuyItemCommand : IShopCommand
    {
        public void Execute(ShopController pShopController)
        {
            pShopController.Buy();
        }

        public void Execute()
        {

        }
    }
}

using System;
using Controller;
using Interfaces;
namespace Commands
{
    public class SellItemCommand : IShopCommand
    {
        public void Execute(ShopController pShopController)
        {
            pShopController.Sell();
        }

        public void Execute()
        {

        }
    }
}

using System;
using Interfaces;
using Controller;
namespace Core
{
    public class ShopCommandExecutor:ICommandExecutor<IShopCommand>
    {
        private readonly ShopController _shopController;
        public ShopCommandExecutor(ShopController pController)
        {
            _shopController = pController;
        }

        public void Execute(IShopCommand pCommand)
        {
            pCommand.Execute(_shopController);
        }
    }
}

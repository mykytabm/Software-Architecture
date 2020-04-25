using System;
using Hobgoblin.Interfaces;
using Hobgoblin.Controller;
namespace Hobgoblin.Core
{
    public class ShopCommandManager : ICommandExecutor<IShopCommand>
    {
        private readonly ShopController _shopController;
        public ShopCommandManager(ShopController pController)
        {
            _shopController = pController;
        }

        public void Execute(IShopCommand pCommand)
        {
            //pCommand.Execute(_shopController);
        }
    }
}

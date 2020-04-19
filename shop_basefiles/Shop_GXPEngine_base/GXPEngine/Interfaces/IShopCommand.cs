using System;
using Controller;
namespace Interfaces
{
    public interface IShopCommand:ICommand
    {
        void Execute(ShopController pShopController);
    }
}

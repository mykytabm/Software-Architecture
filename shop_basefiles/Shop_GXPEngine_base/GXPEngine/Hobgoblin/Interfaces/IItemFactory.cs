using System;
using Hobgoblin.Model;
namespace Hobgoblin.Interfaces
{
    public interface IItemFactory
    {
        Item CreatePotion(int pMaxAmount);
        Item CreateWeapon(int pMaxAmount);
    }
}

using System;
using Hobgoblin.Items;
using Hobgoblin.Model;
namespace Hobgoblin.Interfaces
{
    public interface ItemFactory
    {
        Potion CreatePotion(int pMaxAmount);
        Weapon CreateWeapon(int pMaxAmount);
    }
}

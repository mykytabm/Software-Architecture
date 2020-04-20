using System;
using Items;
using Model;
namespace Interfaces
{
    public interface ItemFactory
    {
        Potion CreatePotion(int pMaxAmount);
        Weapon CreateWeapon(int pMaxAmount);
    }
}

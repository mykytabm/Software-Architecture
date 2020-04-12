using System;
using Model;
using Items;
using Utils;
namespace Interfaces
{
    public interface ItemFactory
    {
        Potion CreatePotion(string pName, string Pimage, int pAmount, EPotion pType);

        Weapon CreateWeapon(string pName, string Pimage, int pAmount, EWeapon pType);
    }
}

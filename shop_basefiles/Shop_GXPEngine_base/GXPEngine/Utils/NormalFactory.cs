using System;
using Interfaces;
using Items;
using Model;

namespace Utils
{
    public class NormalFactory : ItemFactory
    {
        public Potion CreatePotion(string pName, string Pimage, int pAmount, EPotion pType)
        {
            return new Potion(pName, "item", pAmount, pType);
        }

        public Weapon CreateWeapon(string pName, string Pimage, int pAmount, EWeapon pType)
        {
            return new Weapon(pName, Pimage, pAmount, pType);
        }
    }
}

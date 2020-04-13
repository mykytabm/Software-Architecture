using System;
using Core;
using Enums;
using Model;
namespace Items
{
    public class Weapon : Item
    {
        private readonly EWeapon _type;
        public Weapon(string name, string iconName, int amount, EWeapon pType) :
            base(name, iconName, amount)
        {
            _type = pType;
        }
    }
}

using System;
using Hobgoblin.Core;
using Hobgoblin.Enums;
using Hobgoblin.Model;
namespace Hobgoblin.Items
{
    public class Weapon : Item
    {
        public readonly EWeapon type;
        public Weapon(string name, string iconName, int amount, EWeapon pType) :
            base(name, iconName, amount)
        {
            type = pType;
        }
    }
}

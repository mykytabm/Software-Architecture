using System;
using Core;
using Model;
using Enums;
namespace Items
{
    public class Potion : Item
    {
        public readonly EPotion type;
        public Potion(string name, string iconName, int amount, EPotion pType)
            : base(name, iconName, amount)
        {
            type = pType;
        }
    }
}

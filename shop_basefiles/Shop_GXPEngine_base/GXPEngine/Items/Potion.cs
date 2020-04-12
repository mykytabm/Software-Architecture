using System;
using Model;
using Utils;
namespace Items
{
    public class Potion : Item
    {
        private readonly EPotion _type;
        public Potion(string name, string iconName, int amount, EPotion pType)
            : base(name, iconName, amount)
        {
            _type = pType;
        }
    }
}

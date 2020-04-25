using System;
using Hobgoblin.Core;
using Hobgoblin.Model;
using Hobgoblin.Enums;
namespace Hobgoblin.Items
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

using System.Collections.Generic;
using Hobgoblin.Core;
using Hobgoblin.Enums;
using Hobgoblin.Interfaces;
namespace Hobgoblin.Model
{
    //This class holds data for an Item. Currently it has a name, an iconName and an amount.
    public class Item : HGameObject, IPrototype
    {
        public readonly ERarity rarity;
        public readonly string iconName;
        public readonly int price = 20;
        public int Amount { get; set; }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Item()
        //------------------------------------------------------------------------------------------------------------------------

        public Item(string name, string iconName, int amount, ERarity pRarity = ERarity.Common)
        {
            this.name = name;
            this.iconName = iconName;
            this.Amount = amount;
            rarity = pRarity;
        }

        public virtual IPrototype Clone()
        {
            return new Item(name, iconName, Amount);
        }
    }
}

using System;
using Interfaces;
using Items;
using Enums;
using Utils;
using Model;
namespace Core
{
    public class NormalFactory : ItemFactory
    {
        public Potion CreatePotion(int pMaxAmount)
        {
            var amount = Globals.random.Next(1, pMaxAmount + 1); // Random.Next(inclusive min, exclusive max)
            var type = Utils.Utils.RandomEnumValue<EPotion>(Globals.random);
            return new Potion($"Potion of {type}", "item", amount, type);
        }

        public Weapon CreateWeapon(int pMaxAmount)
        {
            var amount = Globals.random.Next(1, pMaxAmount + 1); // Random.Next(inclusive min, exclusive max)
            var type = Utils.Utils.RandomEnumValue<EWeapon>(Globals.random);
            return new Weapon($"{type}", "item", amount, type);
        }
    }
}

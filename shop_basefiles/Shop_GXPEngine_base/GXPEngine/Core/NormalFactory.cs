using System;
using Interfaces;
using Items;
using Enums;
using Utils;
namespace Core
{
    public class NormalFactory : ItemFactory
    {
        public Potion CreatePotion(int pSeed)
        {
            var rand = new Random(pSeed);
            var amount = rand.Next(1, 20);
            var type = Utils.Utils.RandomEnumValue<EPotion>(pSeed);
            return new Potion($"Potion of {type}", "item", amount, type);
        }

        public Weapon CreateWeapon(int pSeed)
        {
            var rand = new Random(pSeed);
            var amount = rand.Next(1, 10);
            var type = Utils.Utils.RandomEnumValue<EWeapon>(pSeed);
            return new Weapon($"{type}", "item", amount, type);
        }
    }
}

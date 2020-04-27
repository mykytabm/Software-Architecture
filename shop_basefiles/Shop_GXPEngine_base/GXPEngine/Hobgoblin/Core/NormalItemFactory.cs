using System;
using Hobgoblin.Interfaces;
using Hobgoblin.Items;
using Hobgoblin.Enums;
using Hobgoblin.Utils;
using Hobgoblin.Model;
namespace Hobgoblin.Core
{
    public class NormalItemFactory : IItemFactory
    {
        public Potion CreatePotion(int pMaxAmount)
        {
            var amount = Globals.random.Next(1, pMaxAmount + 1); // Random.Next(inclusive min, exclusive max)
            var type = HUtils.RandomEnumValue<EPotion>(Globals.random);
            return new Potion($"Potion of {type}", "potion", amount, type);
        }

        public Weapon CreateWeapon(int pMaxAmount)
        {
            var amount = Globals.random.Next(1, pMaxAmount + 1); // Random.Next(inclusive min, exclusive max)
            var type = HUtils.RandomEnumValue<EWeapon>(Globals.random);
            return new Weapon($"{type}", "dagger", amount, type);
        }
    }
}

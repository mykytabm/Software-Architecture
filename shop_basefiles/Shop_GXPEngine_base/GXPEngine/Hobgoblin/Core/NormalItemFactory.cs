using System;
using Hobgoblin.Interfaces;
using Hobgoblin.Enums;
using Hobgoblin.Utils;
using Hobgoblin.Model;
using Hobgoblin.Components;
using System.Collections.Generic;

namespace Hobgoblin.Core
{
    public class NormalItemFactory : IItemFactory
    {
        public Item CreatePotion(int pMaxAmount)
        {
            var amount = Globals.random.Next(1, pMaxAmount + 1); // Random.Next(inclusive min, exclusive max)
            var type = HUtils.RandomEnumValue<EEffect>(Globals.random);
            var potion = new Item($"Potion of {type}", "potion", amount);
            var drinkableComponent = new Drinkable(new List<EEffect>() { type }, 10);
            potion.AddComponent(drinkableComponent);

            return potion;
        }

        public Item CreateWeapon(int pMaxAmount)
        {
            var amount = Globals.random.Next(1, pMaxAmount + 1); // Random.Next(inclusive min, exclusive max)
            var type = HUtils.RandomEnumValue<EWeapon>(Globals.random);
            var weapon = new Item($"{type}", "dagger", amount);
            var equipableComponent = new Equipable(null, EItemSlot.LeftHand, 100);
            weapon.AddComponent(equipableComponent);

            return weapon;
        }
    }
}

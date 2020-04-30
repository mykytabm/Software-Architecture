using System;
using System.Collections.Generic;
using Hobgoblin.Components;
using Hobgoblin.Enums;
using Hobgoblin.Model;

namespace Hobgoblin.Core
{
    public class Humanoid : Actor
    {
        uint _health = 10;
        int _awesomeness = 10;
        int _motivation = 9;
        public uint Health { get { return _health; } }
        public int Awesomeness { get { return _awesomeness; } }
        public int Motivation { get { return _motivation; } }


        public Humanoid(
            List<Item> pInventoryItems,
            int pAdditionalInventorySlots,
            int pGold,
            int pBeltSlots)
        {
            this.AddComponent(new Equipment(pBeltSlots));
            this.AddComponent(new Inventory(pInventoryItems, pAdditionalInventorySlots, pGold));
        }

        public void Heal(uint pHealAmount)
        {
            _health += pHealAmount;
        }

        public void ApplyEffect(EEffect pEffect)
        {
            switch (pEffect)
            {
                case EEffect.none:
                    break;
                case EEffect.Invisibility:
                    break;
                case EEffect.Strength:
                    _health += 2;
                    break;
                case EEffect.Agility:
                    break;
                case EEffect.Awesomeness:
                    _awesomeness -= 2;
                    break;
                case EEffect.Confusion:
                    _motivation -= 2;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using GXPEngine;
using Hobgoblin.Core;
using Hobgoblin.Enums;
using Hobgoblin.Interfaces;

namespace Hobgoblin.Components
{
    public class Equipable : Component, IPrototype
    {
        public readonly List<EEffect> effects;
        public readonly EItemSlot slot;
        private int _durability;

        public int Durability { get { return _durability; } private set { _durability = value; } }

        public Equipable(List<EEffect> pEffects, EItemSlot pSlot, int pDurability)
        {
            effects = pEffects;
            slot = pSlot;
            _durability = pDurability;
        }

        public IPrototype Clone()
        {
            return new Equipable(effects, slot, _durability);
        }
    }
}

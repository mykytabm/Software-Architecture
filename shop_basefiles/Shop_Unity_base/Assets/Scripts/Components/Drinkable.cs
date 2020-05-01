using System;
using Hobgoblin.Core;
using Hobgoblin.Enums;
using System.Collections.Generic;
using Hobgoblin.Interfaces;

namespace Hobgoblin.Components
{

    public class Drinkable : Component, IPrototype
    {
        public readonly EEffect effect;
        public readonly int duration;
        public Drinkable(EEffect Peffect, int pDuration)
        {
            effect = Peffect;
            duration = pDuration;
        }

        public IPrototype Clone()
        {
            return new Drinkable(effect, duration);
        }

        public void Use(Humanoid pHumanoid)
        {
        }
    }
}

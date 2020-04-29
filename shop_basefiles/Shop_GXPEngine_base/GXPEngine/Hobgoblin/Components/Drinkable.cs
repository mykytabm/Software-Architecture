using System;
using Hobgoblin.Core;
using Hobgoblin.Enums;
using System.Collections.Generic;
using Hobgoblin.Interfaces;

namespace Hobgoblin.Components
{

    public class Drinkable : Component, IPrototype
    {
        public readonly List<EEffect> effects;
        public readonly int duration;
        public Drinkable(List<EEffect> pEffects, int pDuration)
        {
            effects = pEffects;
            duration = pDuration;
        }

        public IPrototype Clone()
        {
            return new Drinkable(effects, duration);
        }

        public void Use(Actor pActor)
        {
            foreach (var effect in effects)
            {
                pActor.ApplyEffect(effect, duration);
            }
        }
    }
}

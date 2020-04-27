using System;
using Hobgoblin.Core;
using Hobgoblin.Enums;
using System.Collections.Generic;

namespace Hobgoblin.Components
{

    public class Drinkable : Component
    {
        public readonly List<EEffect> effects;
        public readonly int duration;
        public Drinkable(List<EEffect> pEffects, int pDuration)
        {
            effects = pEffects;
            duration = pDuration;
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

using System;
using Hobgoblin.Core;
using Hobgoblin.Enums;
namespace Hobgoblin.Components
{
    public class Attackable : Component
    {
        public readonly EWeapon type;
        private int _damage;
        private int _maxDamage;

        public Attackable(EWeapon pType, int pDamage)
        {
            type = pType;
            _maxDamage = pDamage;
        }

        // this is just an idea how would components interact between each other
        // the problem is: user of this system can forget to add equipable
        // to an item which is attackable
        //                              solutions:
        //  1: "required components"
        //     they would add default components automatically to an item
        //  2: remove durability from component and add it to an item;
        //  3: remove durability and do not add it to an item, keep setup simple;
        private void ComputeActualDamage()
        {
            var equipable = _owner.GetComponent<Equipable>();
            if (equipable != null)
            {
                _damage = _maxDamage - 100 / equipable.Durability;
            }
        }
    }
}

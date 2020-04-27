using System;
using System.Collections.Generic;
using Hobgoblin.Core;
using Hobgoblin.Model;
using Hobgoblin.Enums;
namespace Hobgoblin.Components
{
    public class Equipment : Component
    {
        private List<EquipmentSlot> _body;
        private List<EquipmentSlot> _belt;

        public Equipment(int pBeltSlots, List<EquipmentSlot> pBody = null)
        {
            _body = pBody != null ? pBody : new List<EquipmentSlot>()
                {
                    new EquipmentSlot(EItemSlot.Head),
                    new EquipmentSlot(EItemSlot.Chest),
                    new EquipmentSlot(EItemSlot.Legs),
                    new EquipmentSlot(EItemSlot.RightHand),
                    new EquipmentSlot(EItemSlot.LeftHand)
                };
            _belt = new List<EquipmentSlot>(pBeltSlots);
            Console.WriteLine(_belt.Capacity);
            for (int i = 0; i < _belt.Capacity; i++)
            {
                _belt.Add(new EquipmentSlot(EItemSlot.BeltPocket));
            }
            Console.WriteLine(_belt.Count);
            Console.WriteLine(_belt.Capacity);
        }
    }
}

using System;
using System.Collections.Generic;
using Hobgoblin.Core;
using Hobgoblin.Model;
using Hobgoblin.Enums;
using Hobgoblin.Interfaces;

namespace Hobgoblin.Components
{
    public class Equipment : Component, IPrototype
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
            for (int i = 0; i < _belt.Capacity; i++)
            {
                _belt.Add(new EquipmentSlot(EItemSlot.BeltPocket));
            }
        }
        public Equipment(List<EquipmentSlot> pBody, List<EquipmentSlot> pBelt)
        {
            _body = pBody;
            _belt = pBelt;
        }

        public IPrototype Clone()
        {
            return new Equipment(_body, _belt);
        }

        public bool TryEquip(Item pItem)
        {
            var equipable = pItem.GetComponent<Equipable>();
            if (equipable != null)
            {
                foreach (var equipmentSlot in _body)
                {
                    if (equipmentSlot.slot == equipable.slot)
                    {
                        equipmentSlot.item = pItem;
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
}

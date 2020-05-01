using System;
using Hobgoblin.Enums;
using Hobgoblin.Model;
namespace Hobgoblin.Core
{
    public class EquipmentSlot
    {
        public readonly EItemSlot slot;
        public Item item;

        public EquipmentSlot(EItemSlot pSlot, Item pItem)
        {
            slot = pSlot;
            item = pItem;
        }

        public EquipmentSlot(EItemSlot pSlot)
        {
            slot = pSlot;
            item = null;
        }
    }
}

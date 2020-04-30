using System;
using Hobgoblin.Core;
using Hobgoblin.Interfaces;
using Hobgoblin.Components;
using Hobgoblin.InventoryMvc;

namespace Hobgoblin.Commands.InventoryCommands
{
    public class EquipItemCommand : ICommand
    {
        Actor _actor;
        InventoryController _controller;
        public EquipItemCommand(Actor pActor, InventoryController pController)
        {
            _controller = pController;
            _actor = pActor;
        }

        public void Execute()
        {
            var itemToEquip = _controller.GetSelectedItem();
            if (itemToEquip != null)
            {
                var actorEquipment = _actor.GetComponent<Equipment>();
                if (actorEquipment != null)
                {
                    if (actorEquipment.TryEquip(itemToEquip))
                    {
                        _controller.AddMessage("item sucessfully equiped, all because you are using cool component system");
                    }
                    else
                    {
                        _controller.AddMessage("this item is not equipable, you cant equip it.");
                    }
                }
                else
                {
                    _controller.AddMessage("you do not have equipment so you cant equip this item. ");
                }
            }


        }
    }
}

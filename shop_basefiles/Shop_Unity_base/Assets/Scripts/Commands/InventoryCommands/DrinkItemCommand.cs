using System;
using Hobgoblin.Components;
using Hobgoblin.Core;
using Hobgoblin.Interfaces;
using Hobgoblin.InventoryMvc;
using Hobgoblin.Model;

namespace Hobgoblin.Commands.InventoryCommands
{
    public class DrinkItemCommand : ICommand
    {
        private Humanoid _actor;
        private InventoryController _controller;

        public DrinkItemCommand(Humanoid pActor, InventoryController pController)
        {
            _actor = pActor;
            _controller = pController;
        }

        public void Execute()
        {
            var itemToDrink = _controller.GetSelectedItem();
            if (itemToDrink != null)
            {
                var drinkable = itemToDrink.GetComponent<Drinkable>();
                if (drinkable != null)
                {
                    _actor.ApplyEffect(drinkable.effect);
                    _controller.AddMessage($"you are under effect of {drinkable.effect}");
                    _controller.RemoveCurrentItem();
                }
            }
        }
    }
}

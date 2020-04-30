using System;
using GXPEngine;
using Hobgoblin.Interfaces;

namespace Hobgoblin.Commands.PlayerCommands
{
    public class ToggleShopCommand : ICommand
    {
        private MyGame _game;
        public ToggleShopCommand(MyGame pGame)
        {
            _game = pGame;
        }
        public void Execute()
        {
            if (_game != null)
            {

            }
        }
    }
}

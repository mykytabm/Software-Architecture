using GXPEngine;
using Hobgoblin.States;
using Hobgoblin.Core;
using Hobgoblin.Model;
using Hobgoblin.Interfaces;
using System.Collections.Generic;
using System;

namespace Hobgoblin
{
    public class MyGame : Game
    {

        private ShopBrowseState _shopBrowseState;
        private CommandManager _commandManager;
        private Player _player;

        public Generator generator;
        public static Player Player;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  MyGame()
        //------------------------------------------------------------------------------------------------------------------------        
        public MyGame() : base(800, 600, false)
        {
            CreateServices();

            RegisterServices();

            CreateObjects();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  CreateServices()
        //------------------------------------------------------------------------------------------------------------------------        
        private void CreateServices()
        {
            _commandManager = new CommandManager();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  RegisterServices()
        //------------------------------------------------------------------------------------------------------------------------        
        private void RegisterServices()
        {
            ServiceLocator.Instance.AddService(_commandManager);

        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  CreateObjects()
        //------------------------------------------------------------------------------------------------------------------------        
        private void CreateObjects()
        {


            _player = new Player();
            Player = _player;
            generator = new Generator(new NormalItemFactory());
            var shopItemList = generator.CreateRandomItems(10);
            _shopBrowseState = new ShopBrowseState(shopItemList);
            AddChild(_player);
            AddChild(_shopBrowseState);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Update()
        //------------------------------------------------------------------------------------------------------------------------        
        void Update()
        {
            _shopBrowseState.Step();
            _commandManager.Step();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Main()
        //------------------------------------------------------------------------------------------------------------------------        
        static void Main()
        {
            new MyGame().Start();
        }
    }
}

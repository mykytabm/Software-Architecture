using GXPEngine;
using Hobgoblin.States;
using Hobgoblin.Core;
using Hobgoblin.Components;
using Hobgoblin.Model;
using Hobgoblin.Interfaces;
using System.Collections.Generic;
using Hobgoblin.Commands.PlayerCommands;
using Hobgoblin.Utils;
using System;

namespace Hobgoblin
{
    public class MyGame : Game
    {
        public Generator generator;
        public static Actor Player;

        private ShopBrowseState _shopBrowseState;
        private InventoryBrowseState _inventoryBrowseState;

        private CommandManager _commandManager;
        private Actor _player;
        private Action _stepAction;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  MyGame()
        //------------------------------------------------------------------------------------------------------------------------        
        public MyGame() : base(800, 600, false)
        {
            CreateServices();

            RegisterServices();

            CreateObjects();

            SetupCommands();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  CreateServices()
        //------------------------------------------------------------------------------------------------------------------------        
        private void CreateServices()
        {
            _commandManager = new CommandManager();
            _stepAction += _commandManager.Step;
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
            // ------------------------/ Item Generator /---------------------------
            generator = new Generator(new NormalItemFactory());

            // ------------------------/ Item Lists /---------------------------
            var _shopItemList = generator.CreateRandomItems(10);
            var inventoryItemList = generator.CreateRandomItems(3);


            // ------------------------/ Player Components /---------------------------
            var playerInventory = new Inventory(inventoryItemList, 4, 100);
            var playerEquipment = new Equipment(2);

            // ------------------------/ Player /---------------------------
            _player = new Humanoid();
            Player = _player;
            _player.AddComponent(playerInventory);
            _player.AddComponent(playerEquipment);

            // -----------------------/ Shop Browse State /---------------------------
            _shopBrowseState = new ShopBrowseState(_shopItemList, _player);
            AddChild(_shopBrowseState);
            _stepAction += _shopBrowseState.Step;
            _shopBrowseState.RegisterViewCommands();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Setup Commands()
        //------------------------------------------------------------------------------------------------------------------------        
        private void SetupCommands()
        {
            var toggleInventory = new KeyCommand(Key.I, new ToggleInventoryCommand(this));
            _commandManager.RegisterCommand(toggleInventory);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Toggle Inventory()
        //------------------------------------------------------------------------------------------------------------------------        
        public void ToggleInventory()
        {
            if (HasChild(_inventoryBrowseState))
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Open Inventory()
        //------------------------------------------------------------------------------------------------------------------------        
        private void OpenInventory()
        {
            _inventoryBrowseState = new InventoryBrowseState(_player.GetComponent<Inventory>());
            AddChild(_inventoryBrowseState);
            _stepAction += _inventoryBrowseState.Step;
            if (_shopBrowseState != null)
            {
                _shopBrowseState.DeregisterViewCommands();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Close Inventory()
        //------------------------------------------------------------------------------------------------------------------------        
        private void CloseInventory()
        {
            _inventoryBrowseState.LateDestroy();
            _stepAction -= _inventoryBrowseState.Step;
            if (_shopBrowseState != null)
            {
                _shopBrowseState.RegisterViewCommands();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Update()
        //------------------------------------------------------------------------------------------------------------------------        
        void Update()
        {
            _stepAction();

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

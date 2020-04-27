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
        private Action _updateAction;

        private List<Item> _shopItems;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  MyGame()
        //------------------------------------------------------------------------------------------------------------------------        
        public MyGame() : base(800, 600, false)
        {
            CreateServices();
            RegisterServices();

            CreateObjects();

            Setup();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  CreateServices()
        //------------------------------------------------------------------------------------------------------------------------        
        private void CreateServices()
        {
            _commandManager = new CommandManager();
            _updateAction += _commandManager.Step;
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
            generator = new Generator(new NormalItemFactory());
            _shopItems = generator.CreateRandomItems(10);
            var inventoryItems = generator.CreateRandomItems(3);

            var playerInventory = new Inventory(inventoryItems, 4, 200);
            _player = new Humanoid();
            _player.AddComponent(playerInventory);
            Player = _player;
            AddChild(_player);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Update()
        //------------------------------------------------------------------------------------------------------------------------        
        private void Setup()
        {
            var toggleShop = new KeyCommand(Key.S, new ToggleShopCommand(this));
            var toggleInventory = new KeyCommand(Key.I, new ToggleInventoryCommand(this));

            _commandManager.RegisterCommand(toggleShop);
            _commandManager.RegisterCommand(toggleInventory);
        }

        public void ToggleInventory()
        {
            if (HasChild(_inventoryBrowseState))
            {
                CloseInventory();
            }
            else
            {
                if (HasChild(_shopBrowseState))
                {
                    CloseShop();
                }
                OpenInventory();
            }
        }

        private void OpenInventory()
        {
            _inventoryBrowseState = new InventoryBrowseState(_player.GetComponent<Inventory>());
            AddChild(_inventoryBrowseState);
            _updateAction += _inventoryBrowseState.Step;
        }

        private void CloseInventory()
        {
            _inventoryBrowseState.LateDestroy();
            _updateAction -= _inventoryBrowseState.Step;
        }

        public void ToggleShop()
        {
            if (HasChild(_shopBrowseState))
            {

                CloseShop();
            }
            else
            {
                if (HasChild(_inventoryBrowseState))
                {
                    CloseInventory();
                }

                OpenShop();
            }
        }

        private void OpenShop()
        {
            _shopBrowseState = new ShopBrowseState(_shopItems);
            AddChild(_shopBrowseState);
            _updateAction += _shopBrowseState.Step;
        }

        private void CloseShop()
        {
            _shopBrowseState.LateDestroy();
            _updateAction -= _shopBrowseState.Step;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Update()
        //------------------------------------------------------------------------------------------------------------------------        
        void Update()
        {
            _updateAction();

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

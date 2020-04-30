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
using System.Drawing;

namespace Hobgoblin
{
    public class MyGame : Game
    {
        public Generator generator;
        public static Humanoid Player;

        private ShopBrowseState _shopBrowseState;
        private InventoryBrowseState _inventoryBrowseState;

        private CommandManager _commandManager;
        private Humanoid _player;
        private Action _stepAction;
        private Canvas _controlCanvas;
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  MyGame()
        //------------------------------------------------------------------------------------------------------------------------        
        public MyGame() : base(800, 600, false)
        {
            CreateServices();

            RegisterServices();

            SetupCommands();

            CreateObjects();
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
            //                          Item Generator 
            generator = new Generator(new NormalItemFactory());

            //                          Item Lists 
            var _shopItemList = generator.CreateRandomItems(10);
            var inventoryItemList = generator.CreateRandomItems(3);


            //                          Player 
            _player = new Humanoid(inventoryItemList, 4, 100, 2);
            Player = _player;

            //                          Shop Browse State 
            _shopBrowseState = new ShopBrowseState(_shopItemList, _player);
            AddChild(_shopBrowseState);
            _stepAction += _shopBrowseState.Step;
            _shopBrowseState.RegisterViewCommands();

            _controlCanvas = new Canvas(width, 100);
            _controlCanvas.y = height - _controlCanvas.height;
            AddChild(_controlCanvas);
            _stepAction += DrawControls;
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
            _inventoryBrowseState = new InventoryBrowseState(
                _player.GetComponent<Inventory>(),
                _shopBrowseState.GetController()
                );
            AddChild(_inventoryBrowseState);
            _stepAction += _inventoryBrowseState.Step;
            UnsubscribeShop();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Close Inventory()
        //------------------------------------------------------------------------------------------------------------------------        
        private void CloseInventory()
        {
            _inventoryBrowseState.LateDestroy();
            _stepAction -= _inventoryBrowseState.Step;
            SubscribeShop();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Subscribe Shop()
        //------------------------------------------------------------------------------------------------------------------------        
        private void SubscribeShop()
        {
            if (_shopBrowseState != null)
            {
                _stepAction += _shopBrowseState.Step;
                _shopBrowseState.RegisterViewCommands();
            }
        }
        private void DrawControls()
        {
            _controlCanvas.graphics.Clear(Color.DarkOliveGreen);
            _controlCanvas.graphics.DrawString(" Use ARROW KEYS to navigate", SystemFonts.CaptionFont, Brushes.White, 0, 0);
            _controlCanvas.graphics.DrawString(" Press 'I' to toggle Inventory", SystemFonts.CaptionFont, Brushes.White, 0, SystemFonts.CaptionFont.Height);
            _controlCanvas.graphics.DrawString(" Press 'Space' to buy item when in Shop and sell when in Inventory ", SystemFonts.CaptionFont, Brushes.White, 0, SystemFonts.CaptionFont.Height * 2);

        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Unsubscribe Shop()
        //------------------------------------------------------------------------------------------------------------------------        
        private void UnsubscribeShop()
        {
            if (_shopBrowseState != null)
            {
                _stepAction -= _shopBrowseState.Step;
                _shopBrowseState.DeregisterViewCommands();
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

using System;
using System.Collections.Generic;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;
using Hobgoblin.Commands.InventoryCommands;
using Hobgoblin.Core;
using Hobgoblin.Model;
using Hobgoblin.Utils;

namespace Hobgoblin.InventoryMvc
{
    public class InventoryView : Canvas, IObserver<InventoryData>
    {
        const int Columns = 4;
        const int Spacing = IconSize + 20;
        const int Margin = 18;
        const int IconSize = 64;

        private List<KeyCommand> _keyCommands;
        private List<Item> _items;

        private int _gold = 0;
        private int _selectedItemId;
        private int _itemCount;

        private InventoryController _controller;
        private CommandManager _commandManager;

        public InventoryView(InventoryController pController) : base(340, 340)
        {
            _controller = pController;
            _commandManager = ServiceLocator.Instance.GetService<CommandManager>();
            _items = new List<Item>();
            _keyCommands = new List<KeyCommand>();

            //----------------------------- Create Commands --------------------------------//
            var moveSelectionLeft = new MoveInventorySelectionCommand(_controller, this, -1, 0);
            var moveSelectionRight = new MoveInventorySelectionCommand(_controller, this, 1, 0);
            var moveSelectionUp = new MoveInventorySelectionCommand(_controller, this, 0, -1);
            var moveSelectionDown = new MoveInventorySelectionCommand(_controller, this, 0, 1);
            var equipItem = new EquipItemCommand(MyGame.Player, _controller);


            //-------------------------- Add Commands to list ------------------------------//
            _keyCommands = new List<KeyCommand>()
            {
                new KeyCommand(Key.LEFT, moveSelectionLeft),
                new KeyCommand(Key.RIGHT, moveSelectionRight),
                new KeyCommand(Key.UP, moveSelectionUp),
                new KeyCommand(Key.DOWN, moveSelectionDown),
                new KeyCommand(Key.E,equipItem)
        };

            RegisterCommands();
        }

        public void Step()
        {
            DrawBackground();
            DrawName();
            DrawItems();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  MoveSelection()
        //------------------------------------------------------------------------------------------------------------------------        
        public int GetNewSelectedItemId(int moveX, int moveY)
        {
            int currentSelectionX = GetColumnByIndex(_selectedItemId);
            int currentSelectionY = GetRowByIndex(_selectedItemId);
            int requestedSelectionX = currentSelectionX + moveX;
            int requestedSelectionY = currentSelectionY + moveY;

            if (requestedSelectionX >= 0 && requestedSelectionX < Columns) //check horizontal boundaries
            {
                int newItemIndex = GetIndexFromGridPosition(requestedSelectionX, requestedSelectionY);
                if (newItemIndex >= 0 && newItemIndex <= _itemCount) //check vertical boundaries
                {
                    return newItemIndex;
                }
                return _selectedItemId;
            }
            return _selectedItemId;
        }
        public void Subscribe(InventoryModel pProvider)
        {
            pProvider.Subscribe(this);
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetColumnByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        private int GetIndexFromGridPosition(int column, int row)
        {
            return row * Columns + column;
        }
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception pError)
        {
            throw new NotImplementedException();
        }

        public void OnNext(InventoryData pData)
        {
            _selectedItemId = pData.selectedItemIndex;
            _itemCount = pData.itemCount;
            _items = pData.items;
            _gold = pData.gold;
        }

        protected override void OnDestroy()
        {
            DeregisterCommands();
            base.OnDestroy();
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  RegisterCommands()
        //------------------------------------------------------------------------------------------------------------------------        
        private void RegisterCommands()
        {
            foreach (var keyCommand in _keyCommands)
            {
                _commandManager.RegisterCommand(keyCommand);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DeregisterCommands()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DeregisterCommands()
        {
            foreach (var keyCommand in _keyCommands)
            {
                _commandManager.DeregisterCommand(keyCommand);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetColumnByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        private int GetColumnByIndex(int index)
        {
            return index % Columns;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetRowByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        private int GetRowByIndex(int index)
        {
            return index / Columns; //rounds down
        }

        private void DrawName()
        {
            graphics.DrawString("  Inventory of a player", SystemFonts.CaptionFont, Brushes.White, 0, 0);
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawBackground()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawBackground()
        {
            graphics.Clear(Color.DarkOliveGreen);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawItems()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawItems()
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                Item item = _items[i];
                int iconX = GetColumnByIndex(i) * Spacing + Margin;
                int iconY = GetRowByIndex(i) * Spacing + Margin;
                if (i == _selectedItemId)
                {
                    DrawItem(item, iconX, iconY);
                    DrawSelectionIcon(iconX, iconY);
                }
                else
                {
                    if (item != null)
                        DrawItem(item, iconX, iconY);
                }
            }
        }
        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawSelectionIcon()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawSelectionIcon(int iconX, int iconY)
        {
            Texture2D iconTexture = IconCache.GetCachedTexture("frame");
            graphics.DrawImage(iconTexture.bitmap, iconX, iconY);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawItem()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawItem(Item item, int iconX, int iconY)
        {
            Texture2D iconTexture = IconCache.GetCachedTexture(item.iconName);
            graphics.DrawImage(iconTexture.bitmap, iconX, iconY, IconSize, IconSize);
        }
    }
}

namespace View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using GXPEngine;
    using GXPEngine.Core;
    using Model;
    using Controller;
    using Utils;
    using Core;
    using Commands;

    //This Class draws the icons for the items in the store
    public class ShopView : Canvas, IObserver<ShopData>
    {
        const int Columns = 4;
        const int Spacing = 80;
        const int Margin = 18;

        private int _selectedItemId;
        private int _itemCount;
        private ShopModel shop;
        private ShopController shopController;
        private ShopCommandExecutor _shopCommandManager;

        //the icon cache is built in here, that violates the S.R. principle.
        private Dictionary<string, Texture2D> iconCache;

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  ShopView()
        //------------------------------------------------------------------------------------------------------------------------        
        public ShopView(ShopModel shop, ShopController shopController) : base(340, 340)
        {
            this.shop = shop;
            this.shopController = shopController;
            _shopCommandManager = ServiceLocator.Instance.GetService<ShopCommandExecutor>();
            iconCache = new Dictionary<string, Texture2D>();
            Console.WriteLine($" current selected item: {_selectedItemId}");
            x = (game.width - width) / 2;
            y = (game.height - height) / 2;
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Step()
        //------------------------------------------------------------------------------------------------------------------------        
        public void Step()
        {
            DrawBackground();
            DrawItems();
            HandleNavigation();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  HandleNavigation()
        //------------------------------------------------------------------------------------------------------------------------        
        private void HandleNavigation()
        {
            if (Input.GetKeyDown(Key.LEFT))
            {
                _shopCommandManager.Execute(new MoveSelectionCommand(GetNewSelectedItemId(-1, 0)));
            }

            if (Input.GetKeyDown(Key.RIGHT))
            {
                _shopCommandManager.Execute(new MoveSelectionCommand(GetNewSelectedItemId(1, 0)));
            }

            if (Input.GetKeyDown(Key.UP))
            {
                _shopCommandManager.Execute(new MoveSelectionCommand(GetNewSelectedItemId(0, -1)));
            }

            if (Input.GetKeyDown(Key.DOWN))
            {
                _shopCommandManager.Execute(new MoveSelectionCommand(GetNewSelectedItemId(0, 1)));
            }

            if (Input.GetKeyDown(Key.SPACE))
            {
                _shopCommandManager.Execute(new BuyItemCommand());
            }

            if (Input.GetKeyDown(Key.BACKSPACE))
            {
                shopController.Sell();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  MoveSelection()
        //------------------------------------------------------------------------------------------------------------------------        
        private int GetNewSelectedItemId(int moveX, int moveY)
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

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetColumnByIndex()
        //------------------------------------------------------------------------------------------------------------------------        
        private int GetIndexFromGridPosition(int column, int row)
        {
            return row * Columns + column;
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

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawBackground()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawBackground()
        {
            graphics.Clear(Color.White);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawItems()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawItems()
        {
            List<Item> items = shop.GetItems();
            for (int index = 0; index < items.Count; index++)
            {
                Item item = items[index];
                int iconX = GetColumnByIndex(index) * Spacing + Margin;
                int iconY = GetRowByIndex(index) * Spacing + Margin;
                if (item == shop.GetSelectedItem())
                {
                    DrawSelectedItem(item, iconX, iconY);
                }
                else
                {
                    DrawItem(item, iconX, iconY);
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawItem()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawItem(Item item, int iconX, int iconY)
        {
            Texture2D iconTexture = GetCachedTexture(item.iconName);
            graphics.DrawImage(iconTexture.bitmap, iconX, iconY);
            graphics.DrawString(item.name, SystemFonts.CaptionFont, Brushes.Black, iconX + 16, iconY + 16);
            graphics.DrawString(item.amount.ToString(), SystemFonts.CaptionFont, Brushes.Black, iconX + 16, iconY + 32);
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawSelectedItem()
        //------------------------------------------------------------------------------------------------------------------------        
        private void DrawSelectedItem(Item item, int iconX, int iconY)
        {
            if (GXPEngine.Utils.Random(0, 2) == 0)
            {
                DrawItem(item, iconX, iconY);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  GetCachedTexture()
        //------------------------------------------------------------------------------------------------------------------------        
        private Texture2D GetCachedTexture(string filename)
        {
            if (!iconCache.ContainsKey(filename))
            {
                iconCache.Add(filename, new Texture2D("media/" + filename + ".png"));
            }
            return iconCache[filename];
        }

        public void Subscribe(ShopModel pProvider)
        {
            pProvider.Subscribe(this);
        }
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception pError)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ShopData pData)
        {
            _selectedItemId = pData.selectedItemIndex;
            _itemCount = pData.itemCount;
        }
    }
}
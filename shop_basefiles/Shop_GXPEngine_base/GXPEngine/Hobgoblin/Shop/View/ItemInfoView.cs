using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;
using Hobgoblin.Model;
using Hobgoblin.Utils;

namespace Hobgoblin.View
{
    public class ItemInfoView : Canvas, IObserver<ShopData>
    {
        

        private const int _iconSize = 100;

        private int _itemIconX;
        private int _itemIconY;

        private Item _item;
        private Texture2D _itemTexture;
        public ItemInfoView() : base(210, 340)
        {
            x += Globals.offsetX;
            y = (game.height - height) / 2;
            _itemIconX = (width - _iconSize) / 2;
            _itemIconY = 20;
        }


        //------------------------------------------------------------------------------------------------------------------------
        //                                                  Step()
        //------------------------------------------------------------------------------------------------------------------------
        public void Step()
        {
            DrawBackground();
            DrawItemInfo();
        }

        //------------------------------------------------------------------------------------------------------------------------
        //                                                  DrawBackground()
        //------------------------------------------------------------------------------------------------------------------------
        private void DrawBackground()
        {
            graphics.Clear(Color.DarkOliveGreen);
        }

        private void DrawItemInfo()
        {
            if (_item == null) return;
            graphics.DrawImage(_itemTexture.bitmap, _itemIconX, _itemIconY, _iconSize, _iconSize);
            graphics.DrawString($"{_item.name}", SystemFonts.CaptionFont, Brushes.White, Globals.offsetX, 120);
            graphics.DrawString($"Amount: {_item.Amount}", SystemFonts.CaptionFont, Brushes.White, Globals.offsetX, 140);
            graphics.DrawString($"price:{_item.price} gold", SystemFonts.CaptionFont, Brushes.White, Globals.offsetX, 260);
        }

        public void Subscribe(ShopModel pProvider)
        {
            pProvider.Subscribe(this);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ShopData pData)
        {
            _item = pData.selectedItem;
            if (_item != null)
            {
                _itemTexture = IconCache.GetCachedTexture(_item.iconName);

            }
            else
            {
                _itemTexture = IconCache.GetCachedTexture("item");
            }
        }
    }
}

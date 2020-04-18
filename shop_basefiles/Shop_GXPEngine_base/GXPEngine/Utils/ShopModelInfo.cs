using System;
using System.Collections.Generic;
using Model;

namespace Utils
{
    public class ShopModelInfo
    {
         public List<Item> items = new List<Item>(); //items in the store
        public int selectedItemIndex = 0;
    }
}

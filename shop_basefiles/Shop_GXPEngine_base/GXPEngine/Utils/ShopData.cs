using System;
using System.Collections.Generic;
using Model;

namespace Utils
{
    public class ShopData
    {
        public List<Item> items = new List<Item>(); //items in the store
        public int selectedItemIndex = 0;
        public int itemCount = 0;
    }
}

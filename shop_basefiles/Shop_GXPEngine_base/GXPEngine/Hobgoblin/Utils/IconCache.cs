using System;
using System.Collections.Generic;
using GXPEngine.Core;

namespace Hobgoblin.Utils
{
    public static class IconCache
    {
        static private Dictionary<string, Texture2D> _cache = new Dictionary<string, Texture2D>();

        public static Texture2D GetCachedTexture(string pName)
        {
            if (!_cache.ContainsKey(pName))
            {
                var texture = new Texture2D("media/" + pName + ".png");
                if (texture != null)
                {
                    _cache.Add(pName, texture);
                }
                else
                {
                    return null;
                }
            }
            return _cache[pName];
        }

    }
}

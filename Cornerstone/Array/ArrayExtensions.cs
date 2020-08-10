using System;
using System.Collections.Generic;
using System.Text;

namespace Cornerstone
{
    public static class ArrayExtensions
    {
        public static T[] Append<T>(this T[] source, params T[] toAdd)
        {
            var list = new List<T>(source);
            list.AddRange(toAdd);
            return list.ToArray();
        }
        public static T[] Prepend<T>(this T[] source, params T[] toAdd)
        {
            var list = new List<T>(toAdd);
            list.AddRange(source);
            return list.ToArray();
        }
    }
}

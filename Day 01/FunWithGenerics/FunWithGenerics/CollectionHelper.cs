using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FunWithGenerics
{
    public static class CollectionHelper
    {
        public static T TheSmallestItemOf<T>(IEnumerable<T> source)
            where T: IComparable<T>
        {
            var isFirst = true;

            T min = default(T);

            foreach (var item in source)
            {
                if (isFirst)
                {
                    min = item;
                    isFirst = false;
                } else
                {
                    if (item.CompareTo(min) < 0) min = item;
                }
            }

            return min;
        }
    }
}

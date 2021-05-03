using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Text;

namespace FunBeforeLinq
{
    public static class EnumerableHelper
    {
        public static IEnumerable<int> RangeTo(this int start, int finish)
        {
            var current = start;
            while (current <= finish)
            {
                yield return current;
                current++;
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            foreach (var item in source)
            {
                if (condition(item))
                    yield return item;
            }
        }

        public static IEnumerable<TRes> Map<TSrc, TRes>(this IEnumerable<TSrc> source, Func<TSrc, TRes> projection)
        {
            foreach (var item in source)
            {
                yield return projection(item);
            }
        }
    }
}

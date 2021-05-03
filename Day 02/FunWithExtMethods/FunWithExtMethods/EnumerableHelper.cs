using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithExtMethods
{
    public static class EnumerableHelper
    {
        public static int Product(this IEnumerable<int> source)
        {
            var res = 1;
            foreach (var item in source)
            {
                res = res * item;
            }

            return res;
        }

        public static IEnumerable<int> Multipliers(this int n)
        {
            var current = 0;
            while(true)
            {
                current += n;
                yield return current;
            }
        }

        public static IEnumerable<T> Limit<T>(this IEnumerable<T> source, int count)
        {
            var counter = 0;
            foreach (var item in source)
            {
                counter++;
                yield return item;
                if (counter >= count) break;
            }
        }

        public static IEnumerable<int> GenerateSomeItems()
        {
            yield return 2;
            yield return 6;
            yield return 8;
            yield return 10;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2Solution
{
    public static class EnumerableHelper
    {
        public static IEnumerable<int> Multipliers(int n)
        {
            return new MultiplierEnumerable(n);
        }

        public static IEnumerable<T> Limit<T>(IEnumerable<T> source, int count)
        {
            return new LimiterEnumerable<T>(source, count);
        }
    }
}

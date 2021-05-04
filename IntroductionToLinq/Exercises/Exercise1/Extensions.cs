using System;
using System.Collections.Generic;

namespace IntroductionToLinq.Exercise1
{
    public static class Extensions
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (var s in source)
            {
                yield return selector(s);
            }
        }

        public static IEnumerable<TResult> MySelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var s in source)
            {
                foreach (var v in selector(s))
                {
                    yield return v;
                }
            }
        }

        public static int MySum(this IEnumerable<int> source)
        {
            int sum = 0;
            foreach (var s in source)
            {
                sum += s;
            }

            return sum;
        }

        public static int MyCount<TSource>(this IEnumerable<TSource> source)
        {
            int count = 0;
            foreach (var s in source)
            {
                count++;
            }

            return count;
        }
    }
}
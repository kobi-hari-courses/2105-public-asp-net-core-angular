using System;
using System.Collections.Generic;

namespace IntroductionToLinq.Exercise1
{
    public static class ExtensionsSolution
    {
        public static IEnumerable<TResult> MySelect<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<TResult> MySelectMany<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TResult>> selector)
        {
            throw new NotImplementedException();
        }

        public static int MySum(this IEnumerable<int> source)
        {
            throw new NotImplementedException();
        }

        public static int MyCount<TSource>(this IEnumerable<TSource> source)
        {
            throw new NotImplementedException();
        }
    }
}
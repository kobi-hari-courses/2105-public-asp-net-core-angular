using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1Solution
{
    public static class EnumerableHelper
    {
        // returns the items in source, except for the first 'count' items
        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            var counter = 0;
            foreach (var item in source)
            {
                counter++;
                if (counter > count)
                    yield return item;
            }
        }

        // returns the items in source, except all the first items that do not match a condition
        // once one item is found that matches the condition, the rest of the items are returned regardless of the condition
        public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            var foundTrueItem = false;

            foreach (var item in source)
            {
                foundTrueItem = foundTrueItem | condition(item);
                if (foundTrueItem) yield return item;
            }
        }

        // takes 2 enumerables as source, and returns one of each alternating between them until one of them is completed
        public static IEnumerable<T> Alternate<T>(this IEnumerable<T> source, IEnumerable<T> source2)
        {
            // note that since we need 2 enumerators to co-exist at the same time, we cannot use `foreach` and need to create 
            // the enumerators explicitly

            using (var enumerator1 = source.GetEnumerator())
            using (var enumerator2 = source2.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator1.MoveNext())
                    {
                        yield return enumerator1.Current;
                    }
                    else
                    {
                        break;
                    }

                    if (enumerator2.MoveNext())
                    {
                        yield return enumerator2.Current;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public static bool Assert<T>(this IEnumerable<T> source, params T[] expected)
        {
            using (var enumerator1 = source.GetEnumerator())
            using (var enumerator2 = expected.ToList().GetEnumerator())
            {
                while(true)
                {
                    var hasItem1 = enumerator1.MoveNext();
                    var hasItem2 = enumerator2.MoveNext();

                    // if both enumerabes ended at the same time, they are equal
                    if (!hasItem1 && !hasItem2) return true;

                    // if one of them ended and one did not, the are not equals
                    if (!hasItem1 || !hasItem2) return false;

                    // if we got here, both enumerators are still pointing to a current item
                    // if the current items are different, they are not equal
                    if (!Equals(enumerator1.Current, enumerator2.Current)) return false;

                    // otherwise, move on to the next item
                }
            }
        }
    }
}

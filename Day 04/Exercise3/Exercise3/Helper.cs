using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public static class Helper
    {
        public static IEnumerable<T[]> Window<T>(this IEnumerable<T> source, int count)
        {
            var queue = new Queue<T>();
            foreach (var item in source)
            {
                queue.Enqueue(item);
                if (queue.Count > count) queue.Dequeue();

                if (queue.Count == count)
                    yield return queue.ToArray();
            }
        }
    }
}

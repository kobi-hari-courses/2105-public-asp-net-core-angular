using System;
using System.Collections;

namespace Exercise2Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = EnumerableHelper.Limit(EnumerableHelper.Multipliers(1), 10);

            foreach (var row in rows)
            {
                var items = EnumerableHelper.Limit(EnumerableHelper.Multipliers(row), 10);

                foreach (var item in items)
                {
                    Console.Write($"{item,5}");
                }
                Console.WriteLine();
            }
        }
    }
}

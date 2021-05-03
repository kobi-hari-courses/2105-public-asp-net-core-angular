using System;

namespace FunBeforeLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in 2.RangeTo(50)
                .Filter(i => i > 5)
                .Filter(i => i % 3 == 0)
                .Filter(i => i % 10 == 5)
                .Map(i => -i)
                )
            {
                Console.WriteLine(item);
            }
        }

    }
}

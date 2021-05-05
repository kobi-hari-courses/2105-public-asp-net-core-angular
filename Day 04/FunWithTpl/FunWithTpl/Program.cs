using System;
using System.Diagnostics;
using System.Linq;

namespace FunWithTpl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.WriteLine("Started...");

            Stopwatch s = new Stopwatch();
            s.Start();

            var primes = Helper.GetAllPrimesParallelUpTo(200000).ToList();
            s.Stop();

            Console.WriteLine($"There are {primes.Count} numbers");
            Console.WriteLine($"And it took {s.ElapsedMilliseconds} milliseconds to calcualte it");

            Console.WriteLine(string.Join(", ", primes.Take(30)));
        }
    }
}

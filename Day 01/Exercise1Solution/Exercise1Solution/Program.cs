using System;

namespace Exercise1Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var md = new MultiDictionary<int, string>();

            md.Add(12, "Hi");
            md.Add(12, "Hello");
            md.Add(15, "Yellow");
            md.Add(17, "Red");

            md.Remove(12, "Hello");
            md.Remove(15, "Yellow");

            Console.WriteLine("The keys are:");
            foreach (var key in md.Keys)
            {
                Console.WriteLine(key);
                Console.WriteLine("With Values: ");
                foreach (var val in md[key])
                {
                    Console.WriteLine(val);
                }
            }

        }
    }
}

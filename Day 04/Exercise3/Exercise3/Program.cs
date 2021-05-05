using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Question1();
            Question2();
            Question3();
            Question4();
        }

        public static void Question1()
        {
            var source = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";

            var indexed = source
                .Split(',')
                .Select((item, index) => $"{index+1}. {item.Trim()}");

            var res = string.Join(", ", indexed);
            Console.WriteLine("Question 1");
            Console.WriteLine(res);
        }

        public static void Question2()
        {
            var source = "Jason Puncheon, 26 / 06 / 1986; Jos Hooiveld, 22 / 04 / 1983; Kelvin Davis, 29 / 09 / 1976; Luke Shaw, 12 / 07 / 1995; Gaston Ramirez, 02 / 12 / 1990; Adam Lallana, 10 / 05 / 1988";

            var res = source.Split(';')
                .Select(txt => txt.Split(','))
                .Select(texts => (name: texts[0].Trim(), age: DateTime.Now - DateTime.Parse(texts[1])))
                .OrderBy(tuple => tuple.age);

            Console.WriteLine("Question 2");
            foreach (var item in res)
            {
                Console.WriteLine($"{item.name}, {(int)item.age.TotalDays/365}");
            }
        }

        public static void Question3()
        {
            var source = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";

            var res = source.Split(',')
                .Select(txt => TimeSpan.Parse($"00:{txt}"))
                .Aggregate((time1, time2) => time1 + time2);

            Console.WriteLine("Question 3");
            Console.WriteLine($"{res.Minutes} minutes and {res.Seconds} seconds");
        }

        public static void Question4()
        {
            var pairs = Enumerable.Range(0, 3)
                .SelectMany(x => Enumerable.Range(0, 3).Select(y => (x: x, y: y)))
                .Select(pair => $"[{pair.x}, {pair.y}]");

            var res = string.Join(", ", pairs);
            Console.WriteLine("Question 4");
            Console.WriteLine(res);
        }


    }
}

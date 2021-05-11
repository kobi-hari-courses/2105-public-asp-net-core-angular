﻿using System;
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
            Question5();
            Question6();
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

        public static void Question5_BAD()
        {
            // what is wrong with this solution?

            var source = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";

            var times = $"00:00, {source}"
                .Split(',')
                .Select(str => TimeSpan.Parse($"00:{str.Trim()}"));

            var res = times
                .Zip(times.Skip(1))
                .Select(pair => pair.Second - pair.First);

            Console.WriteLine("Question 5");
            Console.WriteLine(string.Join(", ", res));
        }

        public static void Question5()
        {
            var source = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";
            var res = $"00:00,{source}"
                .Split(',')
                .Select(str => TimeSpan.Parse($"00:{str.Trim()}"))
                .Window(2)
                .Select(pair => pair[1] - pair[0]);

            Console.WriteLine("Question 5");
            Console.WriteLine(string.Join(", ", res));
        }

        public static void Question6()
        {
            var source = "2,5,7 - 10,11,17 - 18";
            var res = source
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => str
                                .Split("-", StringSplitOptions.RemoveEmptyEntries)
                                .Select(s => int.Parse(s))
                                .ToArray())
                .SelectMany(items => items.Length == 1
                                ? Enumerable.Repeat(items[0], 1)
                                : Enumerable.Range(items[0], items[1] - items[0] + 1));

            Console.WriteLine("Question 5");
            Console.WriteLine(string.Join(" ", res));
        }




    }
}

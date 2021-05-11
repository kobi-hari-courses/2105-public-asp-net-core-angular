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
            Question5();
            Question6();
            Question7();
            Question8();
            Question9();
            Question10();
            Question11();
            Question12();
            Question13();
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

            Console.WriteLine("Question 6");
            Console.WriteLine(string.Join(" ", res));
        }

        public static void Question7()
        {
            var source = "10,5,0,8,10,1,4,0,10,1";

            var res = source
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => int.Parse(str))
                .OrderBy(num => num)
                .Skip(3)
                .Sum();

            Console.WriteLine("Question 7");
            Console.WriteLine(res);
        }

        public static void Question8()
        {
            var source = ('c', 6);

            var oneToEight = Enumerable.Range(1, 8);

            var upLeft = oneToEight
                .Select(i => ((char)(source.Item1 - i), source.Item2 - i))
                .TakeWhile(pair => (pair.Item1 >= 'a') && (pair.Item2 >= 1));

            var upRight = oneToEight
                .Select(i => ((char)(source.Item1 - i), source.Item2 + i))
                .TakeWhile(pair => (pair.Item1 >= 'a') && (pair.Item2 <= 8));

            var downLeft = oneToEight
                .Select(i => ((char)(source.Item1 + i), source.Item2 - i))
                .TakeWhile(pair => (pair.Item1 <= 'h') && (pair.Item2 >= 1));

            var downRight = oneToEight
                .Select(i => ((char)(source.Item1 + i), source.Item2 + i))
                .TakeWhile(pair => (pair.Item1 <= 'h') && (pair.Item2 <= 8));

            var res = upLeft
                .Concat(upRight)
                .Concat(downLeft)
                .Concat(downRight)
                .Select(pair => $"{pair.Item1}{pair.Item2}");

            Console.WriteLine("Question 8");
            Console.WriteLine(string.Join(" ", res));
        }
        public static void Question9()
        {
            var source = "0,6,12,18,24,30,36,42,48,53,58,63,68,72,77,80,84,87,90,92,95,96,98,99,99,100,99,99,98,96,95,92,90,87,84,80,77,72,68,63,58,53,48,42,36,30,24,18,12,6,0,-6,-12,-18,-24,-30,-36,-42,-48,-53,-58,-63,-68,-72,-77,-80,-84,-87,-90,-92,-95,-96,-98,-99,-99,-100,-99,-99,-98,-96,-95,-92,-90,-87,-84,-80,-77,-72,-68,-63,-58,-53,-48,-42,-36,-30,-24,-18,-12,-6";

            var res = source
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .Where((item, index) => index % 5 == 4);

            Console.WriteLine("Question 9");
            Console.WriteLine(string.Join(", ", res));
        }

        public static void Question10()
        {
            var source = "Yes,Yes,No,Yes,No,Yes,No,No,No,Yes,Yes,Yes,Yes,No,Yes,No,No,Yes,Yes";

            var res = source
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s == "Yes" ? +1 : -1)
                .Sum();

            Console.WriteLine("Question 10");
            Console.WriteLine(res);
        }

        public static void Question11()
        {
            var source = "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog";

            var res = source
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => (str == "Dog") || (str == "Cat")
                                    ? str
                                    : "Other")
                .GroupBy(str => str)
                .Select(group => (name: group.Key, count: group.Count()));

            Console.WriteLine("Question 11");
            Console.WriteLine(string.Join(", ", res));
        }

        public static void Question12()
        {
            var source = "1,2,1,1,0,3,1,0,0,2,4,1,0,0,0,0,2,1,0,3,1,0,0,0,6,1,3,0,0,0";

            var res = source
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Aggregate((current: 0, max: 0),
                           (acc, item) => item != "0" ? (current: 0, max: acc.max)
                                                      : (current: acc.current + 1, max: Math.Max(acc.max, acc.current + 1)),
                           acc => acc.max);

            Console.WriteLine("Question 12");
            Console.WriteLine(res);
        }

        public static void Question13()
        {
            var source = "Santi Cazorla, Per Mertesacker, Alan Smith, Thierry Henry, Alex Song, Paul Merson, Alexis Sánchez, Robert Pires, Dennis Bergkamp, Sol Campbell";

            var res = source
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(str => str.Trim())
                .GroupBy(fullName => string.Join(" ", fullName
                                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                                        .Select(str => str[0])))
                .Where(group => group.Count() > 1);

            Console.WriteLine("Question 13");
            foreach (var group in res)
            {
                Console.WriteLine(string.Join(", ", group));
            }
        }




    }
}

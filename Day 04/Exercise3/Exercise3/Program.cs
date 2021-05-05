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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public static class ConsoleHelper
    {
        public static void Print(this string str, ConsoleColor color = ConsoleColor.White)
        {
            var tmp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = tmp;
        }

        public static (int index, string option) GetUserSelection(this IEnumerable<string> options)
        {
            var all = options
                .OrderBy(m => m)
                .Select((m, index) => (name: m, index: index))
                .ToList();

            "Please Select: ".Print(ConsoleColor.Green);
            foreach (var item in all)
            {
                $"{item.index + 1} {item.name}".Print(ConsoleColor.Yellow);
            }

            while (true)
            {
                var choice = Console.ReadLine();
                if (int.TryParse(choice, out var optionIndex))
                {
                    if ((optionIndex > 0) && (optionIndex <= all.Count))
                    {
                        return (index: optionIndex, option: all[optionIndex - 1].name);
                    }

                    Print($"Please select an option between 1 and {all.Count}", ConsoleColor.Red);
                }
                else
                {
                    Print("Please enter a number", ConsoleColor.Red);
                }
            }
        }

    }
}

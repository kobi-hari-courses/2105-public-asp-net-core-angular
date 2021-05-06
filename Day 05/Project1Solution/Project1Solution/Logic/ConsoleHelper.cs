using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Solution
{
    public static class ConsoleHelper
    {
        public static void Print(this string str, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
        }

        public static (int index, string option) GetUserSelection(this IEnumerable<string> options)
        {
            var all = options
                .OrderBy(m => m)
                .Select((option, index) => (option, index))
                .ToList();

            "Please Select: ".Print(ConsoleColor.Green);
            foreach (var item in all)
            {
                $"{item.index + 1}. {item.option}".Print(ConsoleColor.Yellow);
            }

            while(true)
            {
                var choice = Console.ReadLine();
                if (int.TryParse(choice, out var optionIndex))
                {
                    if ((optionIndex < 1) || (optionIndex > all.Count))
                    {
                        $"Please select an option between 1 and {all.Count}".Print(ConsoleColor.Red);
                    } else
                    {
                        return (index: optionIndex, option: all[optionIndex - 1].option);
                    }

                } else
                {
                    "Please enter a valid number".Print(ConsoleColor.Red);
                }
            }
        }
    }
}

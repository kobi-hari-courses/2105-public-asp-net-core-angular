using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToLinq
{
    /*
     * Available in C# 7.0 and later, the tuples feature provides concise syntax to
     * group multiple data elements in a lightweight data structure
     *
     * Unlike Anonynmous Types you can return them from a function
     */

    class Tuples
    {
        public void Run()
        {
            Construction();

            ReturnFromFunction();
        }

        private void Construction()
        {
            // Constructing a tuple

            (string, string) name1 = ("Bill", "Gates");
            
            Console.WriteLine($"{name1.Item1} and {name1.Item2}.");

            // Naming the items

            (string FirstName, string LastName) name2 = ("Bill", "Gates");
            
            Console.WriteLine($"{name2.FirstName} and {name2.LastName}.");

            // Deconstruction into individiual variables

            (string name, int age) = GetManagerInfo();
            Console.WriteLine($"{name}, {age}");
        }

        private void ReturnFromFunction()
        {
            // Assigning the return value of a function to a tuple

            (string, int) info1 = GetStudentInfo();
            Console.WriteLine($"Name: {info1.Item1}, Age: {info1.Item2}");

            (string Name, int Age) info2 = GetStudentInfo();
            Console.WriteLine($"Name: {info2.Name}, Age: {info2.Age}");

            var info3 = GetManagerInfo();
            Console.WriteLine($"Name: {info3.Name}, Age: {info3.Age}");
        }

        // Can return tuple values from a function

        private (string, int) GetStudentInfo()
        {
            return ("Annie", 25);
        }

        // Can return tuple values with named items from a function

        private (string Name, int Age) GetManagerInfo()
        {
            return ("Mary", 35);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithTpl
{
    public static class Helper
    {
        public static bool IsPrime(this int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static IEnumerable<int> GetAllPrimesUpTo(int number)
        {
            return Enumerable.Range(1, number)
                .Where(i => i.IsPrime());
        }

        public static IEnumerable<int> GetAllPrimesParallelUpTo(int number)
        {
            return Enumerable.Range(1, number)
                .AsParallel()
                .Where(i => i.IsPrime());
        }

    }
}

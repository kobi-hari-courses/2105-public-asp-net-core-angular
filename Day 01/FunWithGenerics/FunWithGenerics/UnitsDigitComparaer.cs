using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FunWithGenerics
{
    public class UnitsDigitComparaer : IComparer<int>
    {
        public int Compare([AllowNull] int x, [AllowNull] int y)
        {
            var xunit = x % 10;
            var yunit = y % 10;

            return xunit.CompareTo(yunit);
        }
    }
}

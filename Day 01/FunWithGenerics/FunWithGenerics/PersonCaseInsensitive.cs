using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FunWithGenerics
{
    public class PersonCaseInsensitive : IComparer<Person>
    {
        public int Compare([AllowNull] Person x, [AllowNull] Person y)
        {
            var xfirst = x.FirstName.ToLower();
            var yfirst = y.FirstName.ToLower();
            var xlast = x.LastName.ToLower();
            var ylast = y.LastName.ToLower();

            if (xlast.Equals(ylast))
            {
                return xfirst.CompareTo(yfirst);
            } else
            {
                return xlast.CompareTo(ylast);
            }
        }
    }
}

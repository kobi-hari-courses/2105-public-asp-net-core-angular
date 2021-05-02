using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FunWithGenerics
{
    public class Person: IEquatable<Person>, IComparable<Person>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(Person other)
        {
            if (this.LastName.Equals(other.LastName))
            {
                return this.FirstName.CompareTo(other.FirstName);
            }

            return this.LastName.CompareTo(other.LastName);
        }

        public bool Equals(Person other)
        {
            return FirstName.Equals(other.FirstName)
                && LastName.Equals(other.LastName);
        }
    }
}

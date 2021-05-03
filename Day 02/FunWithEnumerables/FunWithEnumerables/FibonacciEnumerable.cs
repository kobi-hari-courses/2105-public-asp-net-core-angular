using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FunWithEnumerables
{
    public class FibonacciEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new FibonacciEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

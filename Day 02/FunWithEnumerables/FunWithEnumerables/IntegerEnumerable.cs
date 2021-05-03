using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FunWithEnumerables
{
    public class IntegerEnumerable : IEnumerable<int>
    {
        private int _max;

        public IntegerEnumerable(int max)
        {
            _max = max;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new IntegerEnumerator(_max);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

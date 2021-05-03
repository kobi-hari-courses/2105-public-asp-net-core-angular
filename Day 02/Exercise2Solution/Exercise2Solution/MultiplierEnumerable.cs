using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise2Solution
{
    public class MultiplierEnumerable : IEnumerable<int>
    {
        private int _n;

        public MultiplierEnumerable(int n)
        {
            _n = n;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new MultiplierEnumerator(_n);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

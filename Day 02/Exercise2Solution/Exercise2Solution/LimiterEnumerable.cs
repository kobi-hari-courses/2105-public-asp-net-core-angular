using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise2Solution
{
    public class LimiterEnumerable<T> : IEnumerable<T>
    {
        private IEnumerable<T> _source;
        private int _count;

        public LimiterEnumerable(IEnumerable<T> source, int count)
        {
            _source = source;
            _count = count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LimiterEnumerator<T>(_source, _count);   
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

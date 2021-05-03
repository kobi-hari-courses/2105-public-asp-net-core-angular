using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Exercise2Solution
{
    public class LimiterEnumerator<T> : IEnumerator<T>
    {
        private bool _isDisposed = false;
        private int _count;
        private IEnumerable<T> _source;
        private IEnumerator<T> _sourceEnumerator;
        private int _counter = 0;

        private void _validate()
        {
            if (_isDisposed) throw new ObjectDisposedException(null);
        }

        public LimiterEnumerator(IEnumerable<T> source, int count)
        {
            _count = count;
            _source = source;
            _sourceEnumerator = source.GetEnumerator();
        }

        public void Reset()
        {
            throw new InvalidOperationException();
        }

        public void Dispose()
        {
            _isDisposed = true;
            _sourceEnumerator.Dispose();
        }

        public T Current
        {
            get
            {
                _validate();
                return _sourceEnumerator.Current;
            }
        }

        object IEnumerator.Current => Current;


        public bool MoveNext()
        {
            var sourceRes = _sourceEnumerator.MoveNext();
            _counter++;

            return sourceRes && (_counter <= _count);
        }

    }
}

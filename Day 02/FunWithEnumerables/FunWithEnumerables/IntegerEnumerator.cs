using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FunWithEnumerables
{
    public class IntegerEnumerator : IEnumerator<int>
    {
        private int _counter = -1;
        private int _max;
        private bool _disposed = false;

        public IntegerEnumerator(int max)
        {
            _max = max;
        }

        public int Current
        {
            get
            {
                _validate();
                return _counter;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        private void _validate()
        {
            if (_disposed)
                throw new ObjectDisposedException(null);
        }

        public void Dispose()
        {
            _disposed = true;
        }

        public bool MoveNext()
        {
            _validate();
            if (_counter == -1)
            {
                _counter = 1;
                return true;
            }

            _counter++;
            return _counter <= _max;
        }

        public void Reset()
        {
            throw new InvalidOperationException();
        }
    }
}

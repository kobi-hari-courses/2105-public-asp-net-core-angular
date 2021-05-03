using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FunWithEnumerables
{
    public class FibonacciEnumerator : IEnumerator<int>
    {
        private bool _isDisposed = false;
        private int _current = -1;
        private int _previous = -1;

        public int Current
        {
            get
            {
                _validate();
                return _current;
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
            if (_isDisposed)
                throw new ObjectDisposedException(null);
        }

        public void Dispose()
        {
            _isDisposed = true;
        }

        public bool MoveNext()
        {
            if (_current == -1)
            {
                _current = 1;
                return true;
            }

            if (_previous == -1)
            {
                _previous = 1;
                return true;
            }

            // _current 8
            // _previous 5

            var temp = _current; // temp = 8
            _current = _current + _previous; // _current = 8 + 5 = 13
            _previous = temp; // _previous = 8

            return true;
        }

        public void Reset()
        {
            throw new InvalidOperationException();
        }
    }
}

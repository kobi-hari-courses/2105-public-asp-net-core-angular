using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exercise2Solution
{
    public class MultiplierEnumerator : IEnumerator<int>
    {
        private bool _isDisposed = false;
        private int _current = 0;
        private int _n;

        private void _validate()
        {
            if (_isDisposed) throw new ObjectDisposedException(null);
        }

        public MultiplierEnumerator(int n)
        {            
            _n = n;
        }

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

        public void Dispose()
        {
            _isDisposed = true;
        }

        public bool MoveNext()
        {
            _validate();
            _current += _n;
            return true;
        }

        public void Reset()
        {
            throw new InvalidOperationException();
        }
    }
}

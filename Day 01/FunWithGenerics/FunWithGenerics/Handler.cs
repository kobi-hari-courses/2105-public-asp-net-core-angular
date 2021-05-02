using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithGenerics
{
    public class Handler<T>
    {
        private HashSet<T> _handled;

        public Handler()
        {
            _handled = new HashSet<T>();
        }

        public void Handle(T value)
        {
            this._handled.Add(value);
        }

        public bool WasHandled(T value)
        {
            return _handled.Contains(value);
        }
    }
}

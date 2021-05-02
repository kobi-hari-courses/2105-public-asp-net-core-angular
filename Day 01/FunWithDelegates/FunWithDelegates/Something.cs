using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithDelegates
{
    public class Something
    {
        int _a;

        public Something()
        {
            _a = 5;
        }

        public void Increase(int delta)
        {
            _a += delta;
        }

        public void Decrease(int delta)
        {
            _a -= delta;
        }
    }
}

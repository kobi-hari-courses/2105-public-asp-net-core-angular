using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FunWithDelegates
{
    public class Printer
    {
        public event EventHandler<int> OnPrint;

        public void Print(string[] text)
        {
            Thread.Sleep(1500);
            if (OnPrint != null)
            {
                OnPrint.Invoke(this, text.Length);
            }
        }
    }
}

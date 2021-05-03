using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithDelegates
{
    public class Logger
    {
        public Logger(Printer printer)
        {
            printer.OnPrint += (sender, pages) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Logger, logged to file the fact that we have printed {pages} pages");
            };
        }
    }
}

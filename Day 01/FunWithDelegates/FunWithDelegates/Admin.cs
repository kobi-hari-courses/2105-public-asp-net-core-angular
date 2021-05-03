using System;
using System.Collections.Generic;
using System.Text;

namespace FunWithDelegates
{
    public class Admin
    {
        private Printer _printer;

        public Admin(Printer printer)
        {
            _printer = printer;

            printer.OnPrint += Printer_OnPrint; 
        }

        private void Printer_OnPrint(object sender, int pages)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Admin: There are enough pages left after printing {pages} pages");
        }

        public void Disconnect()
        {
            _printer.OnPrint -= Printer_OnPrint;
        }
    }
}

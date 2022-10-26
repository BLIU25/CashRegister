using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class SpyPrinter : Printer
    {
        public bool HasPrinted { get; set; }
        public override void Print(string content)
        {
            // send message to a real printer
            base.Print(content);
            HasPrinted = true;
        }
    }
}

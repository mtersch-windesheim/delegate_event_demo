using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventDemo
{
    public class PrintValues
    {
        // declare delegate
        public delegate void Print(int value);
        private Print printDel;

        public PrintValues()
        {
            // Korte stijl (direct '= <methodenaam>')
            printDel = PrintNumber;
            printDel(200);
            // Nette stijl (instantieer delegate met methode als parameter)
            printDel = new Print(PrintMoney);
            printDel(200);
            // Achter elkaar aan
            Console.WriteLine("Nu achter elkaar:");
            printDel = PrintNumber;
            printDel += PrintMoney;
            printDel(200);
        }
        public static void PrintNumber(int num)
        {
            Console.WriteLine("Number: {0,12:N0}", num);
        }
        public static void PrintMoney(int money)
        {
            Console.WriteLine("Money: {0:C}", money);
        }
    }
}

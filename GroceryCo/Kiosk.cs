using GroceryCo.Services;
using System;

namespace GroceryCo
{
    class Kiosk
    {
        static void Main(string[] args)
        { 
            CashierConsole cashierConsole = new CashierConsole();
            cashierConsole.run();

            Console.WriteLine("\n Press 'Pay For my Purchase' below to continue.");
            Console.ReadKey();
        }
    }
}

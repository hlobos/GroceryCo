using GroceryCo.Services;
using System;

namespace GroceryCo
{
    class Kiosk
    {
        static void Main(string[] args)
        { 
            ConsoleHelper.CenterAndWriteConsoleText("Welcome to GROCERYCO Check-Out Kiosk\n");
            Console.WriteLine("\t" + DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd hh:mm") + "\n");

            CashierConsole cashierConsole = new CashierConsole();
            cashierConsole.run();

            Console.WriteLine("\n Press 'Pay For my Purchase' below to continue.");
            Console.ReadKey();
        }
    }
}

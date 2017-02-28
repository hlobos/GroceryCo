using GroceryCo.Services;
using System;

namespace GroceryCo
{
    class Kiosk
    {
        static void Main(string[] args)
        { 
            Services.Console.CenterAndWriteConsoleText("Welcome to GROCERYCO Check-Out Kiosk\n");
            System.Console.WriteLine("\t" + DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd hh:mm") + "\n");

            CashierConsole cashierConsole = new CashierConsole();
            cashierConsole.run();

            System.Console.WriteLine("\nPress any key to Exit!");
            System.Console.ReadKey();
        }
    }
}

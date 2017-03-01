using System;
using System.Text;

namespace GroceryCo.Services
{
    public static class Receipt
    {
        public static void PrintReceipt(string receiptBody, decimal receiptTotal)
        {
            GenerateHeader();
            Console.WriteLine(receiptBody);
            GenerateFooterTotal(receiptTotal);
        }

        public static void GenerateHeader()
        {
            ConsoleHelper.CenterAndWriteConsoleText("Welcome to GROCERYCO Check-Out Kiosk\n");
            Console.WriteLine("\t" + DateTime.Now.ToLocalTime().ToString("yyyy-MM-dd hh:mm") + "\n");
        }

        public static void GenerateFooterTotal(decimal total)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("\t----------------------------------------");

            builder.AppendFormat("{0,-35}{1:C} ", "\n\tTOTAL: ", total);
      
            builder.Append("\n\t----------------------------------------");

            Console.WriteLine(builder.ToString());
        }
    }
}

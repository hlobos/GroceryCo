using System;

namespace GroceryCo.Services
{
    public class ConsoleHelper
    {
        public static void CenterAndWriteConsoleText(string text)
        {
            Console.Write(new string(' ', (Console.WindowWidth - text.Length) / 2));
            Console.WriteLine(text);
        }
    }
}

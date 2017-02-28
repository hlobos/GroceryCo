using System;

namespace GroceryCo.Services
{
    public class Console
    {
        public static void CenterAndWriteConsoleText(string text)
        {
            System.Console.Write(new string(' ', (System.Console.WindowWidth - text.Length) / 2));
            System.Console.WriteLine(text);
        }
    }
}

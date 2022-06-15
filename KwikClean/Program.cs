using System;

namespace KwikClean
{
    class Program
    {
        static void Main()
        {
            SetupConsole();
            ShowMenu();
        }

        private static void SetupConsole()
        {
            Console.Title = "KwikClean";
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ShowMenu()
        {
            Console.Write("Would you like to remove all unwanted files on your PC to free up disk space? (This may take a while.) Y/N: ");
            string input = Console.ReadLine().ToLower();

            if (input == "y") BeginCleanupProcess();
            else Environment.Exit(0);
        }

        private static void BeginCleanupProcess()
        {
            // TODO: Add code to remove unwanted files.
        }
    }
}

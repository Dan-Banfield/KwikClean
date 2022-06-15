using System;
using System.IO;

namespace KwikClean
{
    class Program
    {
        static void Main()
        {
            SetUpConsole();
            ShowMenu();
        }

        private static void SetUpConsole()
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
            DeleteUnwantedFiles();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();

            Environment.Exit(0);
        }

        private static void DeleteUnwantedFiles()
        {
            Console.Write("\n");
            DeleteTemporaryFiles();
        }

        private static void DeleteTemporaryFiles()
        {
            DeleteTemporaryAppDataFiles();
            DeleteTemporaryWindowsFiles();

            Console.WriteLine("All temporary files were deleted successfully.");

            DeleteSoftwareDistributionFiles();

            Console.WriteLine("All Windows update files were deleted successfully.");
        }

        private static void DeleteTemporaryAppDataFiles()
        {
            DeleteAllFilesFromDirectory(GetTemporaryAppDataDirectory());
        }

        private static void DeleteTemporaryWindowsFiles()
        {
            DeleteAllFilesFromDirectory(GetTemporaryWindowsDirectory());
        }

        private static void DeleteSoftwareDistributionFiles()
        {
            DeleteAllFilesFromDirectory(GetSoftwareDistributionDirectory());
        }

        private static void DeleteAllFilesFromDirectory(string directory)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                try { file.Delete(); }
                catch { }
            }

            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                try { dir.Delete(true); }
                catch { }
            }
        }

        private static string GetTemporaryAppDataDirectory()
        {
            return @"C:\Users\" + Environment.UserName + @"\AppData\Local\Temp";
        }

        private static string GetTemporaryWindowsDirectory()
        {
            return @"C:\Windows\Temp";
        }

        private static string GetSoftwareDistributionDirectory()
        {
            return @"C:\Windows\SoftwareDistribution";
        }
    }
}

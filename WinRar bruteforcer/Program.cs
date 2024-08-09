using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Zipwn | Made by Ebola Man";
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n" +
            "   ███████╗██╗██████╗ ██╗    ██╗███╗   ██╗\n" +
            "   ╚══███╔╝██║██╔══██╗██║    ██║████╗  ██║\n" +
            "     ███╔╝ ██║██████╔╝██║ █╗ ██║██╔██╗ ██║\n" +
            "    ███╔╝  ██║██╔═══╝ ██║███╗██║██║╚██╗██║\n" +
            "   ███████╗██║██║     ╚███╔███╔╝██║ ╚████║\n" +
            "   ╚══════╝╚═╝╚═╝      ╚══╝╚══╝ ╚═╝  ╚═══╝");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("" +
        "             Made By Ebola Man         \n");
        if (!Directory.Exists(@"C:\Program Files\7-Zip"))
        {
            Console.WriteLine("7-Zip not installed!");
            wait();
        }
        Console.Write("Enter Archive(path): ");
        string archive = Console.ReadLine();
        if (!File.Exists(archive))
        {
            Console.WriteLine("Archive not found!");
            wait();
        }
        Console.Write("Enter Wordlist(path): ");
        string wordlist = Console.ReadLine();
        if (!File.Exists(wordlist))
        {
            Console.WriteLine("Wordlist not found!");
            wait();
        }
        Console.WriteLine("Cracking...");
        foreach (string password in File.ReadLines(wordlist))
        {
            Console.WriteLine($"ATTEMPT : {password}");
            if (Attempt(archive, password))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSuccess! Password Found: {password}");
                wait();
            }
        }

        Console.WriteLine("shitty wordlist dumbass");
        wait();
    }
    static bool Attempt(string archive, string password)
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = @"C:\Program Files\7-Zip\7z.exe",
            Arguments = $"x -p{password} \"{archive}\" -o\"cracked\" -y",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (var process = Process.Start(processInfo))
        {
            process.WaitForExit();
            return process.ExitCode == 0;
        }
    }
    static void wait()
    {
        Console.WriteLine("Press any key to continue...\n#FREE EbolaMan");
        Console.ReadKey();
        Environment.Exit(0);
    }
}

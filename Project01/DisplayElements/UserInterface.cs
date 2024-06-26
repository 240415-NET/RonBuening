namespace Project01;
using System;
using System.Collections.Generic;
using System.IO;
public class UserInterface
{
    public static void menuPrintBase(string[] args)
    {
        //calls submethods appropriately for the arguments passed
        string[] initialPrompt = args;
        UserInterface.menuFillVertical(initialPrompt);
        UserInterface.menuFillHorizontal(initialPrompt);
        UserInterface.menuFillVertical(initialPrompt);
    }
    public static void menuFillVertical(string[] args)
    {
        //creates vertical spacing appropriate for the number of menu items in array passed
        int wConsole = Console.WindowWidth;
        int hConsole = Console.WindowHeight;
        string[] menuPrint = args;

        for (int h = 0; h < (hConsole - menuPrint.Length - 2)/2; h++)
        {
            for (int w = 0; w < wConsole; w++)
            {
                Console.Write("=");
            }
            Console.Write('\n');
        }
    }
    public static void menuFillHorizontal(string[] args)
    {
        //prints string array for menu centered in columns
        int wConsole = Console.WindowWidth;
        int hConsole = Console.WindowHeight;
        string[] menuPrint = args;

        for (int s = 0; s < menuPrint.Length; s++)
        {
            Console.Write("===");
            if (menuPrint[s].Length % 2 == 0)
            {
                for (int w = 0; w < (wConsole - (menuPrint[s].Length + 6))/2; w++)
                {
                    Console.Write(" ");
                }
                Console.Write(menuPrint[s]);
                for (int w = 0; w < (wConsole - (menuPrint[s].Length + 6))/2; w++)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                for (int w = 0; w < (wConsole - (menuPrint[s].Length + 6))/2; w++)
                {
                    Console.Write(" ");
                }
                Console.Write(menuPrint[s]);
                for (int w = 0; w < (wConsole - (menuPrint[s].Length + 6))/2; w++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(" ===");
            Console.Write('\n');
        }
    }
    public static string exitChecker(string exitCheck)
    {  
        //this will either return the same string or begin the exit checker process as needed
        exitCheck = exitCheck.Trim();
        if (exitCheck.ToLower() == "q" || exitCheck.ToLower() == "quit")
        {
            exitConfirm();
        }
        return exitCheck;
    }
    public static void exitConfirm()
    {
        //This is a public method to confirm exit when processes have begun in either employee or shopper modes
        Console.WriteLine("Are you sure? Data will not be saved! Confirm by typing 'g'");
        if (Console.ReadLine().ToLower() == "g")
        {
            Console.WriteLine("Exiting. Goodbye!");
            Environment.Exit(0);
        }
    }
    public static void exit()
    {
        //Simplified exit method for use when there is no data being handled
        Console.WriteLine("Are you sure? Confirm by typing 'g'");
        if (Console.ReadLine().ToLower() == "g")
        {
            Console.WriteLine("Exiting. Goodbye!");
            Environment.Exit(0);
        }
    }
}
namespace Week2Team2Hackathon;
using System;
using System.Collections.Generic;
using System.IO;

/*
1 - Prompts the user for multiple values -- DONE!
2 - Save the values to an Array -- A list, but DONE!
3 - Handles any exceptions that may arise during the running of the application (no hard crashing) -- Done (I think)
4 - Manage and update the values for the array using inputs from the User -- DONE!
5 - Continues to run until the user quits the application, from within the application (no ctrl+c) -- DONE!
*/

class Program
{
    public static void Main(string[] args)
    {
        string userTypeSelect;
        bool validSelect = false;
        do
        {
            try
            {
                Console.WriteLine("Hello user! Are you an employee or a shopper?");
                Console.WriteLine("Please enter 'e' for employee or 's'for shopper.");
                userTypeSelect = Console.ReadLine().Trim().ToLower();
                if (userTypeSelect == "e" || userTypeSelect == "employee")
                {
                    validSelect = true;
                    StockTake.StartStock();
                }
                else if (userTypeSelect == "s" || userTypeSelect == "shopper")
                {
                    validSelect = true;
                    ListCreation.Create();
                }
                else
                {
                    Console.WriteLine("Please enter valid selection.");
                }
            }
            catch(Exception f)
            {
                Console.WriteLine($"{f.Message} Please enter a valid selection");
            }
        }
        while (validSelect == false);
    }


    public static string exitChecker (string exitCheck)
    {  
        //this will either return the same string or begin the exit checker process as needed
        exitCheck = exitCheck.Trim();
        if (exitCheck.ToLower() == "q" || exitCheck.ToLower() == "quit")
        {
            exitConfirm();
        }
    return exitCheck;
    }
    public static void exitConfirm ()
    {
        //This is a public method to confirm exit when processes have begun in either employee or shopper modes
        Console.WriteLine("Are you sure? Data will not be saved! Confirm by typing 'g'");
        if (Console.ReadLine().ToLower() == "g")
        {
        Console.WriteLine("Exiting. Goodbye!");
        Environment.Exit(0);
        }
    }
}

namespace Week2Team2Hackathon;
using System;
using System.Collections.Generic;
using System.IO;

/*
1 - Create a Class to model some sort of object
    -- Done in ShopObjects.cs
2 - Prompt the user for values for that object
    -- Done in StockTake.StartStock
3 - Use these values to create objects that we define (maybe use a Constructor?)
    -- Done for shopper mode, ShopObjects.cs
4 - We want to store these objects in a List (or Array)
    -- Done, stored in Lists for shopper mode (ListCreation.Create) and Dictionaries for employee mode (StockTake.StartStock)
5 - Handles any exceptions that may arise during the running of the application (no hard crashing)
    -- Done, in multiple locations
6 - We want to be able to manage and update the values for our objects stored in the list 
    -- Done, for both shopper mode (ListCreation.ChangeShoppingList) and employee mode (StockTake.changeInventory)
7 - Continues to run until the user quits the application, from within the application (no ctrl+c) 
    -- Done, multiple exit conditions and paths (quit without saving (Program.exitConfirm), saving(FileHandling.SaveList or FileHandling.SaveInventory))
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

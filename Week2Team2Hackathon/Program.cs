namespace Week2Team2Hackathon;
using System;
using System.Collections.Generic;

/*
1 - Prompts the user for multiple values -- DONE!
2 - Save the values to an Array -- A list, but DONE!
3 - Handles any exceptions that may arise during the running of the application (no hard crashing) -- Done (I think)
4 - Manage and update the values for the array using inputs from the User -- DONE!
5 - Continues to run until the user quits the application, from within the application (no ctrl+c) -- DONE!
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Shopper! We're ready to begin your shopping list.");
        Console.WriteLine("During any point, type 'q' to quit program without saving.");
        Console.WriteLine("Please enter an item for your shopping list");
        string userInput = Console.ReadLine().Trim();
        bool quit = false;
        int itemNum = 1;
        int alterItem;
        List<string> shoppingList = new List<string>();

        if (userInput.ToLower() == "q" || userInput.ToLower() == "quit")
        {
            Environment.Exit(0);
        }
        else
        {
            shoppingList.Add(itemNum + ". " + userInput);
            itemNum++;
        }
    
        while (quit == false)
        {
            Console.WriteLine("Please enter an item for your shopping list or type 'print' to print list");
            userInput = Console.ReadLine().Trim();
            if (userInput.ToLower() == "q" || userInput.ToLower() == "quit")
            {
                Environment.Exit(0);
            }
            else if (userInput.ToLower() == "p" || userInput.ToLower() == "print")
            {
                PrintShoppingList(shoppingList);
            }
            else
            {
                shoppingList.Add(itemNum + ". " + userInput);
                itemNum++;
            }
        }
        
    }

    static List<string> PrintShoppingList (List<string> printableList)
    {
        List<string> localList = printableList.ToList();
        int itemItt = 1;
        Console.Clear();
        
        localList.ForEach(Console.WriteLine);
        Console.WriteLine("Do you need to add more items or change an existing item?");
        Console.WriteLine("'y' for yes, 'n' for no, 'c' to change");
        string userPrintSelect = Console.ReadLine().Trim().ToLower();
        if (userPrintSelect == "n" || userPrintSelect == "q" || userPrintSelect == "no" || userPrintSelect == "quit")
        {
            Console.Clear();
            localList.ForEach(Console.WriteLine);
            Console.WriteLine("Ready to enter shopping mode");
            ShoppingMode(localList);
        }
        else if (userPrintSelect == "c" || userPrintSelect == "change")
        {
            ChangeShoppingList(localList);
        }
        else
        {
            Console.WriteLine("Please enter valid selection.");
        }

        return localList;
    }

    static List<string> ChangeShoppingList (List<string> existingList2)
    {
        List<string> existingList = existingList2.ToList();
        try
        {
            Console.WriteLine("Please enter an index to change");
            int changeItem = Convert.ToInt32(Console.ReadLine().Trim());
            Console.WriteLine("What do you want to replace " + existingList[changeItem-1] + " with?");
            string changedItem = Console.ReadLine().Trim();
            existingList[changeItem-1] = changeItem + ". " + changedItem;
            Console.Clear();
            existingList.ForEach(Console.WriteLine);
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message} Please enter a valid number");
        }
        return existingList;
    }

    static void ShoppingMode (List<string> printedList)
    {
        List<string> checkList = printedList.ToList();
        string userTicks;
        int itemComplete;
        int countCompleted = 0;
        bool[] completedItems = new bool[checkList.Count()];
        //completedItems.foreach()
        bool listComplete = false;
        do
        {
            Console.WriteLine("Enter index number once item has been collected, 's' to save, or 'q' to quit");
            userTicks = Console.ReadLine().Trim().ToLower();
            try
            {
                if (userTicks == "s" || userTicks == "save")
                {
                    Console.WriteLine("Saving is not yet implemented.");
                }
                else if (userTicks == "q" || userTicks == "quit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    itemComplete = Convert.ToInt32(userTicks);
                    completedItems[itemComplete-1] = true;
                    countCompleted++;
                    if (countCompleted == checkList.Count())
                    {
                        listComplete = true;
                    }
                }
                PrintTruncatedList(checkList,completedItems);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Please enter a valid number or option");
            }
        }
        while (listComplete == false);
        Environment.Exit(0);
    }

    static void PrintTruncatedList (List<string> TruncatedList,bool[] omittedItems)
    {
        List<string> prettyPrint = TruncatedList.ToList();
        Console.Clear();
        for (int i = 0; i < TruncatedList.Count(); i++)
        {
            if (omittedItems[i] != true)
            {
                Console.WriteLine(prettyPrint[i]);
            }
        }
    }
        
  
}

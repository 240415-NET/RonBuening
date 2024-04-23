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
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Shopper! We're ready to begin your shopping list.");
        Console.WriteLine("During any point, type 'q' to quit program without saving.");
        Console.WriteLine("Please enter an item for your shopping list");
        string userInput = Console.ReadLine().Trim();
        bool quit = false;
        int itemNum = 1;
        //int alterItem;
        List<string> shoppingList = new List<string>();

        //This will set up either to exit the program completely or to add the first item to the shopping list
        if (userInput.ToLower() == "q" || userInput.ToLower() == "quit")
        {
            Environment.Exit(0);
        }
        else
        {
            shoppingList.Add(itemNum + ". " + userInput);
            itemNum++;
        }

        //This while loop will present the user with the option to add items to the list or print/view the entire list. Upon printing, a new method is called which gives additional options
        while (quit == false)
        {
            Console.Clear();
            Console.WriteLine("Please enter an item for your shopping list or type 'print' to print list");
            userInput = Console.ReadLine().Trim();
            if (userInput.ToLower() == "q" || userInput.ToLower() == "quit")
            {
                Environment.Exit(0);
            }
            else if (userInput.ToLower() == "p" || userInput.ToLower() == "print")
            {
                shoppingList = PrintShoppingList(shoppingList);
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
        //This method is called by Main and prints the currently compiled list
        List<string> localList = printableList.ToList();
        //int itemItt = 1;
        Console.Clear();
        
        localList.ForEach(Console.WriteLine);
        Console.WriteLine("Do you need to add more items or change an existing item?");
        Console.WriteLine("'y' for yes, 'n' for no, 'c' to change");
        string userPrintSelect = Console.ReadLine().Trim().ToLower();
        //Here the user can select to exit/abort, add addition items (returning to main), or change items using another method
        //Implemented confirmation dialog to improve UX since they've worked to get this far
        if (userPrintSelect == "n" ||  userPrintSelect == "no")
        {
            Console.Clear();
            localList.ForEach(Console.WriteLine);
            Console.WriteLine("Ready to enter shopping mode");
            ShoppingMode(localList);
        }
        else if (userPrintSelect == "q" || userPrintSelect == "quit")
        {
            Console.WriteLine("Are you sure? Data will not be saved! Confirm by typing 'g'");
            //quitConfirm = Console.ReadLine().ToLower();
            if (Console.ReadLine().ToLower() == "g")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Please enter a valid selection.");
            }
        }
        else if (userPrintSelect == "c" || userPrintSelect == "change")
        {
            localList = ChangeShoppingList(localList);
        }
        else
        {
            Console.WriteLine("Please enter valid selection.");
        }

        return localList;
    }

    static List<string> ChangeShoppingList (List<string> existingList2)
    {
        //The ChangeShoppingList method allows for corrections and edits to the list, returning the user to main once the edit is complete
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
        //The shopping mode method is designed to hide items from the list by marking a boolean array true in the same locations as the original list.
        List<string> checkList = printedList.ToList();
        string userTicks;
        int itemComplete;
        int countCompleted = 0;
        bool[] completedItems = new bool[checkList.Count()];
        //completedItems.foreach()
        bool listComplete = false;
        do
        {
            Console.WriteLine("Enter index number once item has been collected, 's' to save and quit, or 'q' to quit");
            userTicks = Console.ReadLine().Trim().ToLower();
            try
            {
                if (userTicks == "s" || userTicks == "save")
                {
                    SaveList(checkList);
                }
                else if (userTicks == "q" || userTicks == "quit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    itemComplete = Convert.ToInt32(userTicks);
                    completedItems[itemComplete-1] = true;
                    countCompleted = completedItems.Where(c => c).Count();
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
        Console.WriteLine("Congratulations, the shopping is done!");
        Environment.Exit(0);
    }

    static void PrintTruncatedList (List<string> TruncatedList,bool[] omittedItems)
    {
        //This method exists solely to print out the items on the list that have not been marked complete under the ShoppingMode method
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

    static void SaveList (List<string> toSave)
    {
        Console.WriteLine("Please enter a directory and file name to save or 'd' for default");
        string saveLocation;
        List<string> saveList = toSave.ToList();

        try
        {
            saveLocation = Console.ReadLine();
            if (saveLocation.ToLower() == "d")
            {
                StreamWriter fileList = new StreamWriter("C:\\ShoppingList.txt");
                saveList.ForEach(fileList.WriteLine);
                fileList.Close();
                Console.WriteLine("Your file has been saved in C:\\ShoppingList.txt");
            }
            else
            {
                StreamWriter fileList = new StreamWriter(saveLocation);
                saveList.ForEach(fileList.WriteLine);
                fileList.Close();
                Console.WriteLine("Your file has been saved in " + saveLocation);
            }
        }
       catch(Exception e)
       {
            Console.WriteLine(e.Message + " Error in saving file. Please reattempt.");
       }
       Console.WriteLine("Please make sure to take your list with you!");
       Environment.Exit(0);

    }
}

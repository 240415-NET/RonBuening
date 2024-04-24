namespace Week2Team2Hackathon;
using System;
using System.Collections;
using System.IO;

/*
1 - Prompts the user for multiple values -- DONE!
2 - Save the values to an Array -- A list, but DONE!
3 - Handles any exceptions that may arise during the running of the application (no hard crashing) -- Done (I think)
4 - Manage and update the values for the array using inputs from the User -- DONE!
5 - Continues to run until the user quits the application, from within the application (no ctrl+c) -- DONE!
*/

class ListCreation
{
    public static void Create()
    {
        Console.Clear();
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
            userInput = printCheckerSL(Console.ReadLine(),shoppingList);
            shoppingList.Add(itemNum + ". " + userInput);
            itemNum++;
        }
        
    }
    private static string printCheckerSL (string printCheck,List<string> printString)
    {
        printCheck = printCheck.Trim();
        List<string> printStringLocal = printString.ToList();
        if (printCheck.ToLower() == "p" || printCheck.ToLower() == "print")
        {
            printStringLocal = PrintShoppingList(printStringLocal);
        }
        else
        {
            printCheck = Program.exitChecker(printCheck);
        }
        return printCheck;
    }

    public static List<string> PrintShoppingList (List<string> printableList)
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
            ShoppingMode.Shop(localList);
        }
        else if (userPrintSelect == "q" || userPrintSelect == "quit")
        {
            Program.exitChecker(userPrintSelect);
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

    public static List<string> ChangeShoppingList (List<string> existingList2)
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
}
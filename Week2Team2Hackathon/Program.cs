namespace Week2Team2Hackathon;
using System;
using System.Collections.Generic;

/*
1 - Prompts the user for multiple values -- DONE!
2 - Save the values to an Array -- A list, but DONE!
3 - Handles any exceptions that may arise during the running of the application (no hard crashing) -- IN PROGRESS
4 - Manage and update the values for the array using inputs from the User -- DONE!
5 - Continues to run until the user quits the application, from within the application (no ctrl+c) -- Done!
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
            quit = true;
        }
        else
        {
            shoppingList.Add(itemNum + ". " + userInput);
            //shoppingList.ForEach(Console.WriteLine);
            itemNum++;
        }
    
        while (quit == false)
        {
            Console.WriteLine("Please enter an item for your shopping list or type 'print' to print list");
            userInput = Console.ReadLine().Trim();
            if (userInput.ToLower() == "q" || userInput.ToLower() == "quit")
            {
                quit = true;
            }
            else if (userInput.ToLower() == "p" || userInput.ToLower() == "print")
            {
                Console.Clear();
                shoppingList.ForEach(Console.WriteLine);
                Console.WriteLine("Do you need to add more items or change an existing item?");
                Console.WriteLine("'y' for yes, 'n' for no, 'c' to change");
                userInput = Console.ReadLine().Trim().ToLower();
                if (userInput == "n" || userInput == "q" || userInput == "no" || userInput == "quit")
                {
                    quit = true;
                }
                else if (userInput == "c" || userInput == "change")
                {
                    Console.WriteLine("Please enter an index to change");
                    alterItem = Convert.ToInt32(Console.ReadLine().Trim());
                    Console.WriteLine("What do you want to replace " + shoppingList[alterItem-1] + " with?");
                    userInput = Console.ReadLine().Trim();
                    shoppingList[alterItem-1] = alterItem + ". " + userInput;
                    Console.Clear();
                    shoppingList.ForEach(Console.WriteLine);
                }
            }
            else
            {
                shoppingList.Add(itemNum + ". " + userInput);
                itemNum++;
            }
        }
        
    }


/*    static void CreateShoppingList (string[] existingList)
    {
        bool quit = false;
        int itemNum = 2;
        string userInput;

        while (quit == false)
        {
            Console.WriteLine("Please enter an item for your shopping list or type 'print' to print list");
            userInput = Console.ReadLine().Trim();
            if (userInput.ToLower() == "q")
            {
                quit = true;
            }
            else if (userInput.ToLower() == "print")
            {
                shoppingList.ForEach(Console.WriteLine);
            }
            else
            {
                shoppingList.Add(itemNum + ". " + userInput);
                itemNum++;
            }
        }
    }*/
}

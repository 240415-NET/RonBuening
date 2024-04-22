namespace Week2Team2Hackathon;
using System;
using System.Collections.Generic;

/*
1 - Prompts the user for multiple values
2 - Save the values to an Array
3 - Handles any exceptions that may arise during the running of the application (no hard crashing)
4 - Manage and update the values for the array using inputs from the User
5 - Continues to run until the user quits the application, from within the application (no ctrl+c)
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
        List<string> shoppingList = new List<string>();
        
        if (userInput.ToLower() == "q")
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

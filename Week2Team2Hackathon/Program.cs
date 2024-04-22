namespace Week2Team2Hackathon;
using System;
using System.Collections.Generic;

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
        if (userInput.ToLower() == "q")
        {
            quit = true;
        }
        else
        {
            List<string> shoppingList = new List<string>();
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

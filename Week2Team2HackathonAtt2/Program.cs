namespace Week2Team2HackathonAtt2;
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
        Console.WriteLine("Hello, Shopper! We're ready to begin your shopping list of three items.");
        //Console.WriteLine("During any point, type 'q' to quit program without saving.");
        Console.WriteLine("Please enter an item for your shopping list");
        string userInput0 = Console.ReadLine().Trim();
        Console.WriteLine("Please enter an item for your shopping list");
        string userInput1 = Console.ReadLine().Trim();
        Console.WriteLine("Please enter an item for your shopping list");
        string userInput2 = Console.ReadLine().Trim();
        string[] shoppingList = {userInput0,userInput1,userInput2};
        Console.WriteLine("Here's your current list:");
        foreach (string s in shoppingList)
        {
            Console.WriteLine(s);
        }

        string alterList;
        
        try
            {
                Console.WriteLine("Do you need to update your shopping list? 'y' for yes, 'n' for no.");
                alterList = Console.ReadLine().ToLower();
                if ((alterList == "y")
                {
                    Console.WriteLine("Select an item to change")
                    
                }
                else if ((userInput == "q" || userInput == "c") && numberItems == 0)
                {
                    Console.WriteLine("Transaction cancelled");
                    quit = true;
                }
                else if (userInput == "e")
                {
                    Console.WriteLine("Transaction cancelled");
                    quit = true;
                }
                else
                {
                    itemValue = Convert.ToDouble(userInput);
                    checkoutTotal = RunningTotal(itemValue,checkoutTotal);
                    numberItems = ItterateNumItems(numberItems);
                    if (numberItems > 1)
                    {
                        Console.WriteLine($"Subtotal is ${checkoutTotal}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Please enter either a valid number or q to end transaction");
            }
    }
}

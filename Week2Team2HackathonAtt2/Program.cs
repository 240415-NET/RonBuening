﻿namespace Week2Team2HackathonAtt2;
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
        string itemNumber;
        int alterItem;
        
        try
            {
                Console.WriteLine("Do you need to update your shopping list? 'y' for yes, 'n' for no.");
                alterList = Console.ReadLine().ToLower();
                if (alterList == "y")
                {
                    Console.WriteLine("Select an item to change");
                    itemNumber = Console.ReadLine();
                    alterItem = Convert.ToInt32(itemNumber);
                    Console.WriteLine("What item should replace it?");
                    shoppingList[alterItem-1] = Console.ReadLine().Trim();
                    foreach (string s in shoppingList)
                    {
                        Console.WriteLine(s);
                    }
                }
                else
                {
                    Console.WriteLine("Please make sure to write your list on a piece of paper; it will not be retained");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Please enter either a valid selection or a number from 1 to 3");
            }
    }
}

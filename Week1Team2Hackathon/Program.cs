﻿namespace Week1Team2Hackathon;

class Program
{
    static void Main(string[] args)
    {
        /*
        Goals:
            1 - Prompts the user for some input
            2 - Does something with that input
            3 - Handles any exceptions that may arise during the running of the application (no hard crashing)
            4 - Continues to run until the user quits the application, from within the application (no ctrl+c)
        Program:
            New program created that emulates a cash register transaction
            Prompts for entry of item value or an exit
            Increments numberItems for each successful entry and keeps running subtotal for items
            Upon exit prompt, shows checkout total and prompts for payment
            If needed, provides change owed or additional amount owed by customer
        */

        double checkoutTotal = 0;
        double itemValue = 0;
        int numberItems = 0;
        string userInput;
        bool quit = false;

        do
        {
            try
            {
                Console.WriteLine("Please enter value of the item or enter 'q' to end transaction");
                userInput = Console.ReadLine().ToLower();
                if (userInput == "q" && numberItems > 0)
                {
                    endTransaction(checkoutTotal,numberItems);
                    quit = true;
                }
                else if (userInput == "q" && numberItems == 0)
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
        while (quit == false);

    }

    static int ItterateNumItems(int numberItems)
    {
        int num1 = numberItems + 1;
        return num1;
    } 
   
    static double RunningTotal (double itemValue, double total)
    {
        total = total + itemValue;
        total = Math.Truncate(100*total)/100;
        return total;
    }

    static void endTransaction (double checkoutTotal, int numberItems)
    {
        Console.WriteLine($"${Math.Round(checkoutTotal,2)} is owed today for {numberItems} items");
        try
        {
            Console.WriteLine("Please enter amount tendered");
            double amountTendered = Math.Round(Convert.ToDouble(Console.ReadLine()),2);
            if (amountTendered-checkoutTotal == 0)
            {
                Console.WriteLine("Thank you, have a great day!");
            }
            else if (amountTendered-checkoutTotal > 0)
            {
                Console.WriteLine($"${amountTendered-checkoutTotal} is owed in change");
            }
            else
            {
                Console.WriteLine($"An additional {-(amountTendered-checkoutTotal)} is needed.");
            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine($"{e.Message} Please enter either a valid payment amount");
        }
       
    }
}

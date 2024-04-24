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

class StockTake
{
    public static void StartStock()
    {
        Console.WriteLine("Employee operations beginning! Ready for inventory.");
        Console.WriteLine("During any point, type 'q' to quit program without saving.");
        

        bool quit = false;
        int itemNumL = 1;
        int aisleL;
        int stockL;
        string brandNameL;
        string productNameL;
        string deptL;
        
        

        //This will set up either to exit the program completely or to add the first item to the inventory
        try
        {
            Console.WriteLine("Please enter the first product name");
            productNameL = Program.exitChecker(Console.ReadLine());
            Console.WriteLine("Please enter the brand name");
            brandNameL = Program.exitChecker(Console.ReadLine());
            Console.WriteLine("Please enter stock on hand");
            stockL = Convert.ToInt32(Program.exitChecker(Console.ReadLine()));

            List<ShopObjects> localInventory = new List<ShopObjects>()
            {
                new ShopObjects{itemID=itemNumL, brandName=brandNameL, productName=productNameL}
            };
        }
        catch (Exception s)
        {
            Console.WriteLine($"{s.Message}. Please enter valid input.");
        }


        //This while loop will present the user with the option to add items to the list or print/view the entire list. Upon printing, a new method is called which gives additional options
/*        while (quit == false)
        {
            Console.Clear();
            Console.WriteLine("Please enter the first product name");
            productNameL = Program.exitChecker(Console.ReadLine());
            Console.WriteLine("Please enter the brand name");
            brandNameL = Program.exitChecker(Console.ReadLine());
            Console.WriteLine("Please enter stock on hand");
            stockL = Convert.ToInt32(Program.exitChecker(Console.ReadLine()));
            if (userInput.ToLower() == "q" || userInput.ToLower() == "quit")
            {
                quit = true;
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
        }*/
    }

    /*
    public static string exitChecker (string exitCheck)
    {
        exitCheck = exitCheck.Trim()
        if (userInput.ToLower() == "q" || userInput.ToLower() == "quit")
        {
            Environment.Exit(0);
        }
        return exitCheck;
    }
    */
}
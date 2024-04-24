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

class StockTake// : IENumerable<ShopObjects>
{
    public static void StartStock()
    {
        Console.WriteLine("Employee operations beginning! Ready for inventory.");
        Console.WriteLine("During any point, type 'q' to quit program without saving.");
        Console.WriteLine("When inventory is done, enter 'd' for done");
        

        bool quit = false;
        bool done1 = false;
        int itemNumL = 1;
        int aisleL;
        int stockL;
        string brandNameL;
        string productNameL;
        string deptL;
        string buffer;
        Dictionary<int,ShopObjects> localInventory = new Dictionary<int, ShopObjects>();
        


        //This while loop will present the user with the option to add items to the list or print/view the entire list. Upon printing, a new method is called which gives additional options
        while (quit == false)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("When inventory is done, enter 'd' for done");
                Console.WriteLine("Please enter the product name");
                buffer = Console.ReadLine().Trim();
                done1 = doneChecker(buffer);
                if (done1 == false)
                {
                    productNameL = Program.exitChecker(buffer);
                    Console.WriteLine("Please enter the brand name");
                    brandNameL = Program.exitChecker(Console.ReadLine());
                    Console.WriteLine("Please enter stock on hand");
                    stockL = Convert.ToInt32(Program.exitChecker(Console.ReadLine()));
                    localInventory.Add(itemNumL,new ShopObjects{itemID=itemNumL,brandName=brandNameL,productName=productNameL,stock=stockL});
                    itemNumL++;
                }
                else
                {
                    Console.Clear();
                    for (int i = 0; i < localInventory.Count(); i++)
                    {
                        localInventory[i].WriteStock();
                    }
                    Console.WriteLine("Do you need to add additional items?");
                    Console.WriteLine("'y' for yes, 'n' for no, 'c' to change existing item");
                   /* buffer = Console.ReadLine.Trim();
                    if (buffer.ToLower == "no" || buffer.ToLower == "n")
                    {
                        Console.WriteLine("Ready to save");
                        FileHandling.SaveInventory(saveInventory);
                        quit = true;
                    }
                    else
                    {
                        localInventory = editNeeded(localInventory);
                    }*/
                }
            }
            catch (Exception s)
            {
                Console.WriteLine($"{s.Message}. Please enter valid input.");
            }
        }
    }

    private static bool doneChecker(string doneCheck)
    {
        bool doneTest = false;
        if (doneCheck.ToLower() == "d" || doneCheck.ToLower() == "done")
        {
            doneTest = true;
        }
        return doneTest;
    }
/*
    private static Dictionary<int,<ShopObjects>> editNeeded(string editCheck,Dictionary<int,<ShopObjects>> printableInventory)
    {
        bool editResult = false;
        Dictionary<int,<ShopObjects>> saveInventory = printableInventory.ToDictionary(k => k.Key, k => k.Value.ToString());
        if (editCheck == "q" || editCheck == "quit")
        {
            Program.exitChecker(editCheck);
        }
        else if (editCheck == "c" || editCheck == "change")
        {
            saveInventory = changeInventory(saveInventory);
        }
        else
        {
            Console.WriteLine("Please enter valid selection.");
        }
        return saveInventory;
    }

    private static Dictionary<int,<ShopObjects>> changeInventory(Dictionary<int,<ShopObjects>> original)
    {
        Dictionary<int,<ShopObjects>> originalInventory = original.ToDictionary(k => k.Key, k => k.Value.ToString());
        int changeInv;
        string changeInvString;
        for (int i = 0; i < originalInventory.Count(); i++)
        {
            originalInventory[i].WriteStock();
        }
        Console.WriteLine("Please enter index to change");
        try
        {
            changeInv = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception i)
        {
            Console.WriteLine("Please enter integer value");
        }

    }*/
}
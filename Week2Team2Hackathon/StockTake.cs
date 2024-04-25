namespace Week2Team2Hackathon;
using System;
using System.Collections;
using System.IO;


class StockTake// : IENumerable<ShopObjects>
{
    public static void StartStock()
    {
        Console.Clear();
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
        


        //This while loop will present the user with the option to add items, change items, or exit the program (with and without saving)
        while (quit == false)
        {
            try
            {
                Console.WriteLine("Please enter the product name");
                buffer = Console.ReadLine().Trim();
                productNameL = doneChecker(buffer,localInventory);
                Console.WriteLine("Please enter the brand name");
                brandNameL = doneChecker(Console.ReadLine(),localInventory);
                Console.WriteLine("Please enter stock on hand");
                stockL = Convert.ToInt32(Console.ReadLine());
                localInventory.Add(itemNumL,new ShopObjects{itemID=itemNumL,brandName=brandNameL,productName=productNameL,stock=stockL});
                itemNumL++;

                foreach(var item in localInventory)
                {
                    Console.WriteLine($"{item.Key}. {item.Value.brandName} {item.Value.productName} {item.Value.stock}");  
                }
                Console.WriteLine("Do you need to add additional items?");
                Console.WriteLine("'y' for yes, 'n' for no, 'c' to change existing item");
                buffer = Console.ReadLine().Trim();
                if (buffer.ToLower() == "no" || buffer.ToLower() == "n")
                {
                    Console.Clear();
                    Console.WriteLine("Ready to save");
                    FileHandling.SaveInventory(localInventory);
                    quit = true;
                }
                else if (buffer.ToLower() == "c" || buffer.ToLower() == "change")
                {
                    localInventory = editNeeded(buffer,localInventory);
                }
                else
                {
                    Console.Clear();
                }
            }
            catch (Exception s)
            {
                Console.WriteLine($"{s.Message}. Please enter valid input.");
            }
        }
    }

    private static string doneChecker(string doneCheck,Dictionary<int,ShopObjects> doneList)
    {
        //this method will check for exit conditions
        bool doneTest = false;
        Dictionary<int,ShopObjects> doneInventory = doneList;
        if (doneCheck.ToLower() == "d" || doneCheck.ToLower() == "done")
        {
            FileHandling.SaveInventory(doneInventory);
        }
        else if (doneCheck.ToLower() == "q" || doneCheck.ToLower() == "quit")
        {
            Program.exitConfirm();
        }
        return doneCheck;
    }

    public static Dictionary<int,ShopObjects> editNeeded(string editCheck,Dictionary<int,ShopObjects> printableInventory)
    {
        //this method exists to check if edits to the existing list are needed
        bool editResult = false;
        
        Dictionary <int,ShopObjects> saveInventory = new Dictionary<int,ShopObjects>();
        
        saveInventory = printableInventory;
        
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

    public static Dictionary<int,ShopObjects> changeInventory(Dictionary<int,ShopObjects> original)
    {
        //this method changes the list once needed
        Dictionary<int,ShopObjects> originalInventory = original;
        int changeInv;
        string changeInvString;
        string brandNameL2;
        string productNameL2;
        string deptL2;
        int stockL2;

        Console.Clear();

        foreach(var item in originalInventory)
        {
            Console.WriteLine($"{item.Key}. {item.Value.brandName} {item.Value.productName} {item.Value.stock}");  
        }
        Console.WriteLine("Please enter index to change");
        try
        {
            changeInv = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the product name");
            changeInvString = Console.ReadLine().Trim();
            productNameL2 = Program.exitChecker(changeInvString);
            Console.WriteLine("Please enter the brand name");
            brandNameL2 = Program.exitChecker(Console.ReadLine());
            Console.WriteLine("Please enter stock on hand");
            stockL2 = Convert.ToInt32(Program.exitChecker(Console.ReadLine()));
            originalInventory[changeInv] = new ShopObjects{itemID=changeInv,brandName=brandNameL2,productName=productNameL2,stock=stockL2};

            Console.Clear();
            foreach(var item in originalInventory)
            {
                Console.WriteLine($"{item.Key}. {item.Value.brandName} {item.Value.productName} {item.Value.stock}");  
            }
        }
        catch (Exception i)
        {
            Console.WriteLine("Please enter integer value");
        }
        return originalInventory;
    }
}
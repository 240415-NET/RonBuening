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
        bool done = false;
        int itemNumL = 1;
        int aisleL;
        int stockL;
        string brandNameL;
        string productNameL;
        string deptL;
        string buffer;
        List<ShopObjects> localInventory = new List<ShopObjects>();
        

        //This will set up either to exit the program completely or to add the first item to the inventory
/*        try
        {
            Console.WriteLine("Please enter the first product brand name");
            brandNameL = Program.exitChecker(Console.ReadLine());
            Console.WriteLine("Please enter the product name");
            productNameL = Program.exitChecker(Console.ReadLine());
            Console.WriteLine("Please enter stock on hand");
            stockL = Convert.ToInt32(Program.exitChecker(Console.ReadLine()));
            localInventory.Add(new ShopObjects{itemID = itemNumL, brandName = brandNameL, productName = productNameL, stock = stockL});
            itemNumL++;
        }
        catch (Exception s)
        {
            Console.WriteLine($"{s.Message}. Please enter valid input.");
        }*/


        //This while loop will present the user with the option to add items to the list or print/view the entire list. Upon printing, a new method is called which gives additional options
        while (quit == false)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("When inventory is done, enter 'd' for done");
                Console.WriteLine("Please enter the product name");
                buffer = Console.ReadLine().Trim();
                done = doneChecker(buffer);
                if (done == false)
                {
                    productNameL = Program.exitChecker(buffer);
                    Console.WriteLine("Please enter the brand name");
                    brandNameL = Program.exitChecker(Console.ReadLine());
                    Console.WriteLine("Please enter stock on hand");
                    stockL = Convert.ToInt32(Program.exitChecker(Console.ReadLine()));
                    localInventory.Add(new ShopObjects{itemID=itemNumL,brandName=brandNameL,productName=productNameL,stock=stockL});
                    itemNumL++;
                }
                else
                {
                    Console.Clear();
                    for (int i = 0; i < localInventory.Count(); i++)
                    {
                        localInventory[i].WriteStock();
                    }
                    quit = true;
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
        bool done = false;
        if (doneCheck.ToLower() == "d" || doneCheck.ToLower() == "done")
        {
            done = true;
        }
        return done;
    }
/*
    public IEnumerator<localInventory> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        yield return localInventory[i];
    }
*/
}
class ShopObjects : IEnumerable<ShopObjects>
{
    public string brandName {get; set;}
    public string productName {get; set;}
    public string dept {get; set;}
    public int aisle {get; set;}
    public int stock {get; set;}
    public int itemID {get; set;}

    public void WriteStock()
    {
        Console.WriteLine($"{itemID}: {brandName} {productName}; {stock} on hand");
    }
    public ShopObjects(){}

    public ShopObjects (int itemID, string brandName, string productName, int stock)
    {
        this.itemID = itemID;
        this.brandName = brandName;
        this.productName = productName;
        this.stock = stock;
    }


    public IEnumerator<ShopObjects> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        yield return ShopObjects[i];
    }


    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
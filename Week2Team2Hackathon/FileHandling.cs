namespace Week2Team2Hackathon;
using System;
using System.Collections;
using System.IO;

class FileHandling
{
    public static void SaveList (List<string> toSave)
    {
        //This method will save the file, either to a default directory and file name, or a user input one.
        Console.WriteLine("Please enter a directory and file name to save or 'd' for default");
        string saveLocation;
        List<string> saveList = toSave.ToList();

        try
        {
            saveLocation = Console.ReadLine();
            if (saveLocation.ToLower() == "d")
            {
                //Initial attempt showed permissions issue; may have to revise for future commits
                StreamWriter fileList = new StreamWriter("C:\\ShoppingList.txt");
                saveList.ForEach(fileList.WriteLine);
                fileList.Close();
                Console.WriteLine("Your file has been saved in C:\\ShoppingList.txt");
            }
            else
            {
                StreamWriter fileList = new StreamWriter(saveLocation);
                saveList.ForEach(fileList.WriteLine);
                fileList.Close();
                Console.WriteLine("Your file has been saved in " + saveLocation);
            }
        }
       catch(Exception e)
       {
            Console.WriteLine(e.Message + " Error in saving file. Please reattempt.");
       }
       Console.WriteLine("Please make sure to take your list with you!");
       Environment.Exit(0);
    }

    public static void SaveInventory (Dictionary<int,ShopObjects> saveableInventory)
    {
        //This method will save the file, either to a default directory and file name, or a user input one.
        Console.WriteLine("Please enter a directory and file name to save or 'd' for default");
        string saveLocation2;
        Dictionary<int,ShopObjects> finalInventory = saveableInventory.ToDictionary(k => k.Key, k => k.Value.ToString());

        try
        {
            saveLocation2 = Console.ReadLine();
            if (saveLocation.ToLower() == "d")
            {
                //Initial attempt showed permissions issue; may have to revise for future commits
                StreamWriter fileList = new StreamWriter("C:\\ShoppingList.txt");
                foreach(var item in finalInventory)
                {
                    Console.WriteLine($"{item.Key}. {item.Value.brandName} {item.Value.productName} {item.Value.stock}");  
                }
                fileList.Close();
                Console.WriteLine("Your file has been saved in C:\\ShoppingList.txt");
            }
            else
            {
                StreamWriter fileList = new StreamWriter(saveLocation2);
                foreach(var item in finalInventory)
                {
                    Console.WriteLine($"{item.Key}. {item.Value.brandName} {item.Value.productName} {item.Value.stock}");  
                }
                fileList.Close();
                Console.WriteLine("Your file has been saved in " + saveLocation);
            }
        }
       catch(Exception e)
       {
            Console.WriteLine(e.Message + " Error in saving file. Please reattempt.");
       }
       Console.WriteLine("Thank you for conducting the monthly inventory!");
       Environment.Exit(0);
    }
}
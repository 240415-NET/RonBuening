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
        bool saveSucess = false;

        while (saveSucess == false)
        {
            try
            {
                saveLocation = Console.ReadLine();
                if (saveLocation.ToLower() == "d")
                {
                    //Initial attempt showed permissions issue; may have to revise for future commits
                    StreamWriter fileList = new StreamWriter("C:\\ShoppingList.txt");
                    saveList.ForEach(fileList.WriteLine);
                    fileList.Close();
                    Console.Clear();
                    saveSucess = true;
                    Console.WriteLine("Your file has been saved in C:\\ShoppingList.txt");
                }
                else
                {
                    StreamWriter fileList = new StreamWriter(saveLocation);
                    saveList.ForEach(fileList.WriteLine);
                    fileList.Close();
                    Console.Clear();
                    saveSucess = true;
                    Console.WriteLine("Your file has been saved in " + saveLocation);
                }
            }
            catch(Exception e)
            {
                    Console.WriteLine(e.Message + " Error in saving file. Please reattempt.");
            }
        }
    Console.WriteLine("Please make sure to take your list with you!");
    Environment.Exit(0);
    }

    public static void SaveInventory (Dictionary<int,ShopObjects> finalInventory)
    {
        //This method will save the file, either to a default directory and file name, or a user input one.
        Console.WriteLine("Please enter a directory and file name to save or 'd' for default");
        string saveLocation2;

        bool saveSuccess2 = false;
        
        while (saveSuccess2 == false)
        {
            try
            {
                saveLocation2 = Console.ReadLine();
                if (saveLocation2.ToLower() == "d")
                {
                    //Initial attempt showed permissions issue; may have to revise for future commits
                    StreamWriter fileList = new StreamWriter("C:\\ShoppingList.txt");
                    fileList.WriteLine("Key\tBrand\tProduct\tStock");
                    foreach(var item in finalInventory)
                    {
                        fileList.WriteLine($"{item.Key}.\t{item.Value.brandName}\t{item.Value.productName}\t{item.Value.stock}");  
                    }
                    fileList.Close();
                    Console.Clear();
                    Console.WriteLine("Your file has been saved in C:\\ShoppingList.txt");
                    saveSuccess2 = true;
                }
                else
                {
                    StreamWriter fileList = new StreamWriter(saveLocation2);
                    fileList.WriteLine("Key\tBrand\tProduct\tStock");
                    foreach(var item in finalInventory)
                    {
                        fileList.WriteLine($"{item.Key}.\t{item.Value.brandName}\t{item.Value.productName}\t{item.Value.stock}");  
                    }
                    fileList.Close();
                    Console.Clear();
                    Console.WriteLine("Your file has been saved in " + saveLocation2);
                    saveSuccess2 = true;
                }
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message + " Error in saving file. Please reattempt.");
                Console.WriteLine("Please enter a directory and file name to save or 'd' for default");
            }
      }
      Console.WriteLine("Thank you for conducting the monthly inventory!");
      Environment.Exit(0);
    }
}
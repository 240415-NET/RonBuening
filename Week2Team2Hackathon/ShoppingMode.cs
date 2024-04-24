namespace Week2Team2Hackathon;
using System;
using System.Collections;
using System.IO;

class ShoppingMode
{
    public static void Shop (List<string> printedList)
    {
        //The shopping mode method is designed to hide items from the list by marking a boolean array true in the same locations as the original list.
        List<string> checkList = printedList.ToList();
        string userTicks;
        int itemComplete;
        int countCompleted = 0;
        bool[] completedItems = new bool[checkList.Count()];
        //completedItems.foreach()
        bool listComplete = false;
        do
        {
            Console.WriteLine("Enter index number once item has been collected, 's' to save and quit, or 'q' to quit");
            userTicks = Console.ReadLine().Trim().ToLower();
            try
            {
                if (userTicks == "s" || userTicks == "save")
                {
                    FileHandling.SaveList(checkList);
                }
                else if (userTicks == "q" || userTicks == "quit")
                {
                    Program.exitChecker(userTicks);
                }
                else
                {
                    itemComplete = Convert.ToInt32(userTicks);
                    completedItems[itemComplete-1] = true;
                    countCompleted = completedItems.Where(c => c).Count();
                    if (countCompleted == checkList.Count())
                    {
                        listComplete = true;
                    }
                }
                PrintTruncatedList(checkList,completedItems);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} Please enter a valid number or option");
            }
        }
        while (listComplete == false);
        Console.WriteLine("Congratulations, the shopping is done!");
        Environment.Exit(0);
    }

    public static void PrintTruncatedList (List<string> TruncatedList,bool[] omittedItems)
    {
        //This method exists solely to print out the items on the list that have not been marked complete under the ShoppingMode method
        List<string> prettyPrint = TruncatedList.ToList();
        Console.Clear();
        for (int i = 0; i < TruncatedList.Count(); i++)
        {
            if (omittedItems[i] != true)
            {
                Console.WriteLine(prettyPrint[i]);
            }
        }
    }
}
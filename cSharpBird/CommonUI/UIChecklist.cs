namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class UIChecklist
{
    public static void viewList(Checklist xlist)
    {
        //calls submethods appropriately for the arguments passed
        UIChecklist.PrintHeader(xlist);
    }
    public static void PrintHeader(Checklist xlist)
    {
        User currentUser = UserController.ReadCurrentUser();
        try
        {
            string printLocation = "Location: " + xlist.locationName;
            string printCount = "0";
            
            Dictionary<int,Bird>? species = new Dictionary<int, Bird>();
            if (!(xlist.birdChecklist?.Any() ?? false))
            {
                printCount = "Species: " + xlist.birdChecklist.Count();
                species = xlist.birdChecklist;
            }
            else
                printCount = "Species: 0";
            
            string printDate = "Date: "+ xlist.checklistDateTime;
            int widthConsole = Console.WindowWidth;
            int widthColumn = widthConsole / 3;
            //Console.ForegroundColor 13;
            Console.WriteLine("{0,-widthColumn}","{1,-widthColumn}","{2,widthColumn}",printLocation,printCount,printDate);
            Console.WriteLine("Test");
            Console.ResetColor();
        }
        catch (Exception l)
        {
            Console.WriteLine(l.Message);
        }
    }
    /*
    public static void menuFillVertical(string[] args)
    {
        //creates vertical spacing appropriate for the number of menu items in array passed
        int wConsole = Console.WindowWidth;
        int hConsole = Console.WindowHeight;
        string[] menuPrint = args;

        for (int h = 0; h < (hConsole - menuPrint.Length - 2)/2; h++)
        {
            for (int w = 0; w < wConsole; w++)
            {
                Console.Write("=");
            }
            Console.Write('\n');
        }
    }
    public static void menuFillHorizontal(string[] args)
    {
        //prints string array for menu centered in columns
        int wConsole = Console.WindowWidth;
        int hConsole = Console.WindowHeight;
        string[] menuPrint = args;

        for (int s = 0; s < menuPrint.Length; s++)
        {
            Console.Write("===");
            if (ColorLength(menuPrint[s]) % 2 == 0)
            {
                for (int w = 0; w < (wConsole - (ColorLength(menuPrint[s]) + 6))/2; w++)
                {
                    Console.Write(" ");
                }
                UserInterface.WriteColors(menuPrint[s]);
                for (int w = 0; w < ((wConsole - (ColorLength(menuPrint[s]) + 6))/2)-1; w++)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                for (int w = 0; w < ((wConsole - (ColorLength(menuPrint[s]) + 6))/2); w++)
                {
                    Console.Write(" ");
                }
                UserInterface.WriteColors(menuPrint[s]);
                for (int w = 0; w < ((wConsole - (ColorLength(menuPrint[s]) + 6))/2); w++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(" ===");
            Console.Write('\n');
        }
    }*/
}
namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class UIChecklist
{
    public static void viewList(Checklist xlist,List<Bird> loggedBirds)
    {
        //calls submethods appropriately for the arguments passed
        UIChecklist.PrintHeader(xlist,loggedBirds);
        //if xlist.birdList

    }
    public static void PrintHeader(Checklist xlist,List<Bird> loggedBirds)
    {
        User currentUser = UserController.ReadCurrentUser();
        string tempName;
        try
        {
            if (currentUser.displayName == null)
                tempName = currentUser.userName;
            else
                tempName = currentUser.displayName;
            UserInterface.WriteColors("{=Magenta}" + tempName + "'s " + xlist.locationName + " checklist for " + xlist.checklistDateTime + "{/}\n");
            if (loggedBirds.Count() == 0)
                UserInterface.WriteColorsLine("{=Red}No birds logged yet{/}");
            else
                UserInterface.WriteColorsLine("{=Blue}Species logged: " + loggedBirds.Count() +"{/}");
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
namespace Project01;
using System;
using System.Collections.Generic;
using System.IO;

public class AdminMenu
{
    public static void LogIn()
    {
        int wConsole = Console.WindowWidth;
        int hConsole = Console.WindowHeight;
        string[] initialPrompt = {"Please select log-in type","1. Administrator","2. Client"};
        int userSelect = 0;

        Console.Clear();
        UserInterface.menuFillVertical(initialPrompt);
        UserInterface.menuFillHorizontal(initialPrompt);
        UserInterface.menuFillVertical(initialPrompt);

        try
        {
            userSelect = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}. Please key in valid selection");
        }

        switch (userSelect)
        {
            case 1:
            AdminMenu.LogIn();
            break;
            case 2:
            ClientMenu.LogIn();
            break;
            default:
            Console.WriteLine("Please enter valid selection");
            return;
        }
    }
}
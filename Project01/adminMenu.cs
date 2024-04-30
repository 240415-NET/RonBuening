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
        string[] initialPrompt = {"Please enter your username and key","separated by a space"};
        int userSelect = 0;

        Console.Clear();
        UserInterface.menuFillVertical(initialPrompt);
        UserInterface.menuFillHorizontal(initialPrompt);
        UserInterface.menuFillVertical(initialPrompt);

        
    }
}
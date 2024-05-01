namespace Project01;
using System;
using System.Collections.Generic;
using System.IO;

public class ClientMenu
{
    public static void LogIn()
    {
        int wConsole = Console.WindowWidth;
        int hConsole = Console.WindowHeight;
        string[] initialPrompt = {"Please enter your email to sign in"};
        string userSignOn;

        Console.Clear();
        UserInterface.menuFillVertical(initialPrompt);
        UserInterface.menuFillHorizontal(initialPrompt);
        UserInterface.menuFillVertical(initialPrompt);
       

    }

    public static void RootMenu()
    {
        
    }
}
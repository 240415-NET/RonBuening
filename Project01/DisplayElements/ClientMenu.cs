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
        UserInterface.menuPrintBase(initialPrompt);
    }

    public static void RootMenu()
    {

    }
}
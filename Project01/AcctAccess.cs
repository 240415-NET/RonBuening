namespace Project01;
using System;
using System.Collections.Generic;
using System.IO;
public class AcctAccess
{
    public static void LogIn()
    {
        int wConsole = Console.WindowWidth;
        int hConsole = Console.WindowHeight;
        string[] initialPrompt = {"Please select log-in type","1. Administrator","2. Client"};

        Console.Clear();
        UserInterface.menuFillVertical(initialPrompt);
        UserInterface.menuFillHorizontal(initialPrompt);
        UserInterface.menuFillVertical(initialPrompt);
    }
}
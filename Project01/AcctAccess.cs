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
        for (int s = 0; s < initialPrompt.Length; s++)
        {
            for (int w = 0; w < (wConsole - (initialPrompt[0].Length+4))/2; w++)
            {
                Console.Write("=");
            }
            if (s > 0)
            {
                int widthAdjust = ((initialPrompt[0].Length ) - initialPrompt[s].Length) / 2;
                for (int w = 0; w < widthAdjust; w++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write("  ");
            Console.Write(initialPrompt[s]);
            Console.Write("  ");
            if (s > 0)
            {
                int widthAdjust = ((initialPrompt[0].Length ) - initialPrompt[s].Length) / 2;
                for (int w = 0; w < widthAdjust; w++)
                {
                    Console.Write(" ");
                }
            }
            for (int w = 0; w < (wConsole - (initialPrompt[0].Length+4))/2; w++)
            {
                Console.Write(" ");
            }
            Console.Write('\n');
        }
        UserInterface.menuFillVertical(initialPrompt);
    }
}
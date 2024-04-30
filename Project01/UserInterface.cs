namespace Project01;
using System;
using System.Collections.Generic;
using System.IO;
public class UserInterface
{
    public static void menuFillVertical(string[] args)
    {
        int wConsole = Console.WindowWidth;
        int hConsole = Console.WindowHeight;
        string[] menuPrint = args;

        Console.Clear();
        for (int h = 0; h < (hConsole - menuPrint.Length - 2)/2; h++)
        {
            for (int w = 0; w < wConsole; w++)
            {
                Console.Write("=");
            }
        }
    }
}
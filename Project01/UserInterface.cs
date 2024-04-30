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

        for (int h = 0; h < (hConsole - menuPrint.Length - 2)/2; h++)
        {
            for (int w = 0; w < wConsole; w++)
            {
                Console.Write("=");
            }
        }
    }
    public static void menuFillHorizontal(string[] args)
    {
        int wConsole = Console.WindowWidth;
        int hConsole = Console.WindowHeight;
        string[] menuPrint = args;

        for (int s = 0; s < menuPrint.Length; s++)
        {
            Console.Write("===");
            for (int w = 0; w < (wConsole - (menuPrint[s].Length + 6))/2; w++)
            {
                Console.Write(" ");
            }
            Console.Write(menuPrint[s]);
            for (int w = 0; w < (wConsole - (menuPrint[s].Length + 6))/2; w++)
            {
                Console.Write(" ");
            }
            Console.Write("===");
            Console.Write('\n');
        }
    }
}
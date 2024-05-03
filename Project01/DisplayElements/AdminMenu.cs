namespace Project01;
using System;
using System.Collections.Generic;
using System.IO;

public class AdminMenu
{
    public static void LogIn()
    {
        string[] initialPrompt = {"Please enter your username and key","separated by a space"};
        int userSelect = 0;
        string userSignOn;
        string[] adminSignOn = {"",""}

        Console.Clear();
        UserInterface.menuPrintBase(initialPrompt);
        do
        {
            try
            {
                userSignOn = Console.ReadLine();
                nullEmpty = String.IsNullOrEmpty(userSignOn); //will return true if string given is null or empty
                if (nullEmpty == true)
                {
                    Console.WriteLine("Please provide a valid sign on")
                }
                else
                {
                    adminSignOn = userSignOn.Split(' ').Select(str => str.Trim()).ToArray();
                    if (adminSignOn.Length() == 2)
                    {
                        AdminMenu.UserCheck(adminSignOn);
                    }
                    else
                    {
                        Console.WriteLine("Please provide a valid sign on");
                        nullEmpty = true;
                    }
               }
            }
            catch (Exception signon)
            {
                Console.WriteLine("Please provide a valid sign on");
            }
        }
        while (nullEmpty == true);
    }
}
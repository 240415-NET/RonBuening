namespace Project01;
using System;
using System.Collections.Generic;
using System.IO;

public class ClientMenu
{
    public static void LogIn()
    {
        string[] initialPrompt = {"Please enter your email to sign in"};
        string userSignOn;
        bool nullEmpty = false;
        
        Console.Clear();
        UserInterface.menuPrintBase(initialPrompt);
        
        do
        {
            userSignOn = Console.ReadLine.Trim();
            nullEmpty = String.IsNullOrEmpty(userSignOn); //will return true if string given is null or empty
            if (nullEmpty == true)
            {
                Console.WriteLine("Please provide a valid sign on")
            }
            else
            {
                Clients.UserCheck(userSignOn);
            }
        }
        while (nullEmpty == true);
    }

    public static void RootMenu()
    {

    }
}
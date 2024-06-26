namespace Project01;
using System;
using System.Collections.Generic;
using System.IO;
public class AcctAccess
{
    public static void LogIn()
    {
        string[] initialPrompt = {"Please select log-in type","1. Administrator","2. Client","3. Exit"};
        int userSelect = 0;
        bool valid = false;

        Console.Clear();
        UserInterface.menuPrintBase(initialPrompt);
        
        do 
        {
            try
            {
                userSelect = Convert.ToInt32(Console.ReadLine());
                switch (userSelect)
                {
                    case 1:
                    valid = true;
                    AdminMenu.LogIn();
                    break;
                    case 2:
                    valid = true;
                    ClientMenu.LogIn();
                    break;
                    case 3:
                    UserInterface.exit();
                    Console.WriteLine("Please enter a selection to continue");
                    break;
                    default:
                    Console.WriteLine("Please enter valid selection");
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}. Please key in valid selection");
            }
        }
        while (valid == false);
    }
}
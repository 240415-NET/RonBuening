namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class AcctAccess
{
    public static void LogIn()
    {
        //This method prompts for sign-in or account creation and routes requests appropriately.
        
        string[] initialPrompt = {"In this program, actionable objects are highlighted in colors","Key the highlighted text to make a selection","{=Green}1.{/} Existing User","{=Yellow}2.{/} New User","{=Red}3.{/} Exit"};
        int userSelect = 0;
        bool valid = false;
        string email;

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
                    UserMaintenance.LogIn();
                    break;
                    case 2:
                    valid = true;
                    UserCreation.CreateUser();
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
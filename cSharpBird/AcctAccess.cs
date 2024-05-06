namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class AcctAccess
{
    public static void initMenu()
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
                    LogIn();
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
    public static void LogIn()
    {
        bool logInSuccess = false;
        Console.Clear();
        do
        {
            UserInterface.WriteColors("Please enter your {=Green}email{/} to sign in to your account\n");
            string email = Console.ReadLine().Trim();
            PassEmail:
            if (String.IsNullOrEmpty(email))
            {
                Console.Clear();
                UserInterface.WriteColors("{=Green}Email{/} cannot be blank. Please try again\n");
            }
            else if (!string.IsNullOrEmpty(email))
            {
                if (User.FindUser(email) != null)
                {
                    logInSuccess = true;
                    User currentSession = User.FindUser(email);
                    UserMaintenance.UserMenu(currentSession);
                }
                else
                {
                    UserInterface.WriteColors("Email not found. Do you need to create an account? Re-enter your {=Green}email{/} or type {=Green}create{/} to make new account\n");
                    email = Console.ReadLine().Trim();
                    if (email.ToLower() == "create" || email.ToLower() == "c")
                        UserCreation.CreateUser();
                    else 
                        goto PassEmail;
                }
            }
        }
        while (logInSuccess == false);
    }
}
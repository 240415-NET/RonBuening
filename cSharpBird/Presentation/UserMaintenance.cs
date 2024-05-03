namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class UserMaintenance
{
    public static void LogIn()
    {
        bool logInSuccess = false;
        do
        {
            UserInterface.WriteColors("Please enter your {=Green}email{/} to create a new account");
            email = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(email))
            {
                Console.Clear();
                UserInterface.WriteColors("{=Green}Email{/} cannot be blank. Please try again");
            }
            else if
            {
                UserInterface.WriteColors("Email not found. Do you need to create an account? Re-enter your {=Green}email{/} or type {=Green}create{/} to make new account");
                email = Console.ReadLine().Trim();
                if (email.ToLower == "create" || email.ToLower == "c")
                    UserCreation.CreateUser();
            }
            else if 
            {
                
            }
        }
        while (logInSuccess == false);
    }
    public static void LogIn(string email)
    {
        Console.WriteLine("Attempting sign-in!");
    }
    public static bool SignInSuccess (string email)
    {
        return true;
    }
}
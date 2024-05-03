namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class UserCreation
{
    public static void CreateUser()
    {
        string email;
        bool exitLoop = false;

        Console.Clear();
        do
        {
            UserInterface.WriteColors("Please enter your {=Green}email{/} to create a new account\n");
            email = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(email))
            {
                Console.Clear();
                UserInterface.WriteColors("{=Green}Email{/} cannot be blank. Please try again");
            }
            else if(UserCreation.UserDupe(email))
            {
                exitLoop = true;
                UserInterface.WriteColors("{=Green}Email{/} already in use. Please sign in");
                UserMaintenance.LogIn();
            }
            else
            {
                exitLoop = true;
                NewUser(email);
            }
        }
        while (exitLoop == false);
    }
    public static bool UserDupe(string userRequested)
    {
        return false;
    }
    public static User NewUser(string email)
    {
        User newUser = new User(email);
        AccessFile.WriteUser(newUser);
        return newUser;
    }
}
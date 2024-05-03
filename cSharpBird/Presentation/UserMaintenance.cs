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
            string email = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(email))
            {
                Console.Clear();
                UserInterface.WriteColors("{=Green}Email{/} cannot be blank. Please try again");
            }
            else if (!string.IsNullOrEmpty(email))
            {
                User currentSession = FindUser(email);
            }
            /*
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
            */
        }
        while (logInSuccess == false);
    }
    public static User FindUser(string entry)
    {
        string email = entry;
        User foundUser = new User();
        //This method is used to find the user attempting to sign in and return the proper user object
        try
        {
            //Will return full user list
            List<User> userList = AccessFile.ReadUser();
            foundUser = userList.FirstOrDefault(u => u.userName == email);
            //return foundUser;
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}: User not found. Please rekey email");
            email = Console.ReadLine().Trim();
        }
        return foundUser;
    }
    public static bool SignInSuccess (string email)
    {
        return true;
    }
}
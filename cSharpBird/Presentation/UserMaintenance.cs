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
            UserInterface.WriteColors("Please enter your {=Green}email{/} to sign in to your account\n");
            string email = Console.ReadLine().Trim();
            if (String.IsNullOrEmpty(email))
            {
                Console.Clear();
                UserInterface.WriteColors("{=Green}Email{/} cannot be blank. Please try again\n");
            }
            else if (!string.IsNullOrEmpty(email))
            {
                if (FindUser(email) != null)
                {
                    logInSuccess = true;
                    User currentSession = FindUser(email);
                    UserMenu(currentSession);
                }
                else
                {
                    UserInterface.WriteColors("Email not found. Do you need to create an account? Re-enter your {=Green}email{/} or type {=Green}create{/} to make new account\n");
                    email = Console.ReadLine().Trim();
                    if (email.ToLower() == "create" || email.ToLower() == "c")
                        UserCreation.CreateUser();
                }
            }
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
            foundUser = userList.FirstOrDefault(u => u.userName.ToLower() == email.ToLower());
            //return foundUser;
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}: User not found. Please rekey email");
            email = Console.ReadLine().Trim();
        }
        return foundUser;
    }
    public static void UserMenu(User currentSession)
    {
        AccessFile.WriteCurrentUser(currentSession);
        string[] menu = {"Welcome back to cSharpBird!","What would you like to do today?","{=Green}1. New{/} Checklist","{=Yellow}2. Edit{/} Checklist","{=Red}3. Delete{/} Checklist","{=Blue}4. Update{/} user"};
        UserInterface.menuPrintBase(menu);
    }
}
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
                UserInterface.WriteColors("{=Green}Email{/} cannot be blank. Please try again\n");
            }
            else if(UserCreation.UserDupe(email))
            {
                exitLoop = true;
                UserInterface.WriteColors("{=Green}Email{/} already in use. Please sign in\n");
                UserMaintenance.LogIn();
            }
            else
            {
                exitLoop = true;
                User currentSession = NewUser(email);
                UserInterface.WriteColors("{=Blue}New user created for " + email +"\n");
                UserMaintenance.UserMenu(currentSession);
            }
        }
        while (exitLoop == false);
    }
    public static bool UserDupe(string userRequested)
    {
        string email = userRequested;
        User foundUser = new User();
        //This method is used to find the user attempting to sign in and return the proper user object
        //Will return full user list
        List<User> userList = AccessFile.ReadUser();
        foundUser = userList.FirstOrDefault(u => u.userName.ToLower() == email.ToLower());
        if (foundUser == null)
            return false;
        else
            return true;
    }
    public static User NewUser(string email)
    {
        User newUser = new User(email);
        AccessFile.WriteUser(newUser);
        return newUser;
    }
}
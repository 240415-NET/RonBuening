namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class UserMaintenance
{
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
                    else 
                        goto PassEmail;
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
        string tempName;
        if (currentSession.displayName == null)
            tempName = currentSession.userName;
        else
            tempName = currentSession.displayName;
        string[] menu = {"Welcome back to cSharpBird "+tempName+"!","What would you like to do today?","{=Green}1. New{/} Checklist","{=Blue}2. View{/} Checklist","{=Yellow}3. Update{/} user","{=Red}4. Exit{/} Program"};
        string userInput;
        bool validInput = false;

        Console.Clear();
        do
        {
            try
            {
                UserInterface.menuPrintBase(menu);
                userInput = Console.ReadLine().Trim();
                switch (userInput.ToLower())
                {
                    case "1":
                    case "1.":
                    case "1. new":
                    case "new":
                    validInput = true;
                    EntryChecklist.Create();
                    break;
                    case "2":
                    case "2.":
                    case "2. view":
                    case "view":
                    validInput = true;
                    EntryChecklist.View();
                    break;
                    case "3":
                    case "3.":
                    case "3. update":
                    case "update":
                    validInput = true;
                    UserUpdate(currentSession);
                    break;
                    case "4":
                    case "4.":
                    case "4. exit":
                    case "exit":
                    validInput = true;
                    UserInterface.exitConfirm();
                    break;
                    default:
                    Console.WriteLine("Please enter valid selection");
                    break;
                }
            }
            catch (Exception i)
            {
                Console.WriteLine($"{i.Message}: please enter a valid selection");
            }
        }
        while (validInput == false);
    }
    public static void UserUpdate(User currentSession)
    {
        string[] menu = {"What would you like to do today?","{=Green}1. Change{/} email","{=Blue}2. Update{/} name","{=Yellow}3. Return{/} to main menu"};
        string userInput;
        bool validInput = false;
        
        Console.Clear();
        do
        {
            try
            {
                UserInterface.menuPrintBase(menu);
                userInput = Console.ReadLine().Trim();
                switch (userInput.ToLower())
                {
                    case "1":
                    case "1.":
                    case "1. change":
                    case "change":
                    case "email":
                    //validInput = true;
                    Console.Clear();
                    User.changeEmail(currentSession);
                    break;
                    case "2":
                    case "2.":
                    case "2. update":
                    case "update":
                    case "name":
                    //validInput = true;
                    Console.Clear();
                    User.changeName(currentSession);
                    break;
                    case "3":
                    case "3.":
                    case "3. return":
                    case "return":
                    validInput = true;
                    Console.Clear();
                    UserMenu(currentSession);
                    break;
                    default:
                    Console.WriteLine("Please enter valid selection");
                    break;
                }
            }
            catch (Exception i)
            {
                Console.WriteLine($"{i.Message}: please enter a valid selection");
            }
        }
        while (validInput == false);
    }
}
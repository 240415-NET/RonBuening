namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class UserMaintenance
{
    public static void UserMenu(User currentSession)
    {
        UserController.WriteCurrentUser(currentSession);
        string tempName;
        if (currentSession.displayName == null)
            tempName = currentSession.userName;
        else
            tempName = currentSession.displayName;
        string[] menu = {"Welcome back to cSharpBird "+tempName+"!","What would you like to do today?","{=Green}1. New{/} Checklist","{=Blue}2. View{/} Checklist Menu","{=Yellow}3. Update{/} user","{=Red}4. Exit{/} Program","{=Magenta}5. Logoff{/}"};
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
                    EntryChecklist.Menu();
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
                    UserInterface.exit();
                    break;
                    case "5":
                    case "5.":
                    case "5. logoff":
                    case "logoff":
                    validInput = true;
                    UserInterface.logoff();
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
                    UserController.changeEmail(currentSession);
                    break;
                    case "2":
                    case "2.":
                    case "2. update":
                    case "update":
                    case "name":
                    //validInput = true;
                    Console.Clear();
                    UserController.changeName(currentSession);
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
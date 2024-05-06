namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class EntryChecklist
{
    public static void Menu()
    {
        Console.Clear();
        string[] menu = {"{=Magenta}CHECKLIST MENU{/}","{=Green}1. Create{/} New Checklist","{=Cyan}2. List{/} Existing Checklists","{=Blue}3. View{/} Existing Checklist","{=Red}4. Exit{/} to Menu."};
        string menuRequest;
        bool validInput = false;
        UserInterface.menuPrintBase(menu);
        do 
        {
            try
            {
                menuRequest = Console.ReadLine();
                switch (menuRequest.ToLower())
                {
                    case "1":
                    case "1.":
                    case "1. create":
                    case "new":
                    case "create new":
                    validInput = true;
                    EntryChecklist.Create();
                    break;
                    case "2":
                    case "2.":
                    case "2. list":
                    case "list":
                    case "list all":
                    validInput = true;
                    EntryChecklist.List(AccessFile.ReadCurrentUser());
                    break;
                    case "3":
                    case "3.":
                    case "3. view":
                    case "view":
                    case "view checklist":
                    validInput = true;
                    //UserUpdate(currentSession);
                    break;
                    case "4":
                    case "4.":
                    case "4. exit":
                    case "exit":
                    case "quit":
                    case "back":
                    case "cancel":
                    validInput = true;
                    UserMaintenance.UserMenu(AccessFile.ReadCurrentUser());
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
        while (validInput == false);
    }
    public static void Create()
    {
        string hotspot;
        string[] createMenu = {"{=Magenta}NEW CHECKLIST{/}","{=Green}1. Current{/} Checklist","{=Blue}2. Historic{/} Checklist","{=Red}3. Cancel{/}"};
        bool validInput = false;
        string menuRequest;

        Console.Clear();

        UserInterface.menuPrintBase(createMenu);
        do 
        {
            try
            {
                menuRequest = Console.ReadLine();
                switch (menuRequest.ToLower())
                {
                    case "1":
                    case "1.":
                    case "1. current":
                    case "current":
                    case "create new":
                    case "today":
                    case "now":
                    validInput = true;
                    //EntryChecklist.Create();
                    break;
                    case "2":
                    case "2.":
                    case "2. historic":
                    case "past":
                    case "historic":
                    validInput = true;
                    //EntryChecklist.List(AccessFile.ReadCurrentUser());
                    break;
                    case "3":
                    case "3.":
                    case "3. exit":
                    case "exit":
                    case "quit":
                    case "back":
                    case "cancel":
                    validInput = true;
                    Menu();
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
        while (validInput == false);
    }
    public static void List(User user)
    {
        List<Checklist> userChecklists = new List<Checklist>();
        userChecklists = ChecklistFile.GetLists(user);

    }
    public static void View()
    {

    }
    public static void Edit(Checklist oldChecklist)
    {
        string editRequest;
        bool validInput = false;
        UserInterface.WriteColorsLine("{=Green}1. Birder{/}: " + oldChecklist.birder + "\t" + "{=Cyan}2. Location{/}: " + oldChecklist.locationName + "\t" + "{=Blue}3. Date{/}: "+ oldChecklist.checklistDateTime + "\t" + "{=Yellow)4. Species{/}: " + oldChecklist.birdChecklist.Count + "\t" + "{=Red}5. Cancel{/}");
        UserInterface.WriteColorsLine("What do you need to edit?");
        do 
        {
            try
            {
                editRequest = Console.ReadLine();
                switch (editRequest.ToLower())
                {
                    case "1":
                    case "1.":
                    case "1. birder":
                    case "birder":
                    case "user":
                    validInput = true;
                    //EntryChecklist.Create();
                    break;
                    case "2":
                    case "2.":
                    case "2. location":
                    case "location":
                    validInput = true;
                    //EntryChecklist.View();
                    break;
                    case "3":
                    case "3.":
                    case "3. date":
                    case "date":
                    validInput = true;
                    //UserUpdate(currentSession);
                    break;
                    case "4":
                    case "4.":
                    case "4. species":
                    case "species":
                    case "birds":
                    case "bird":
                    validInput = true;
                    //UserInterface.exitConfirm();
                    break;
                    case "5":
                    case "5.":
                    case "5. cancel":
                    case "cancel":
                    case "exit":
                    case "quit":
                    validInput = true;
                    UserInterface.exitConfirm();
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
        while (validInput == false);
    }
    public static void Delete(Checklist oldChecklist)
    {

    }
    public static List<Bird> addSpecies(List<Bird> speciesList)
    {
        return speciesList;
    }
    public static List<Bird> removeSpecies(List<Bird> speciesList)
    {
        return speciesList;
    }
    public static void changeBirder(Checklist oldChecklist)
    {

    }
    public static void changeLocation(Checklist oldChecklist)
    {

    }
    public static void changeDate(Checklist oldChecklist)
    {

    }
    public static Checklist changeSpecies(Checklist oldChecklist)
    {
        List<Bird> update = oldChecklist.birdChecklist;
        string userInput;
        bool valid = false;
        for (int i = 0; i < update.Count; i++)
        {
            Console.WriteLine($"{i+1}: {update[i].speciesName}");
        }
        /*
        Console.Write("Do you need to ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("add");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(" or ");
        Console.ForegroundColor = Console.Color.Red;
        Console.Write("remove");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(" a species?");
        */
        UserInterface.WriteColors("Do you need to {=Red}add{/} or {=Red}remove{/} a species?");
        do
        {
            userInput = Console.ReadLine().Trim();
            if (userInput.ToLower() == "a" || userInput.ToLower() == "add")
            {
                valid = true;
                update = addSpecies(update);
            }
            else if (userInput.ToLower() == "r" || userInput.ToLower() == "remove")
            {
                valid = true;
                update = removeSpecies(update);
            }
            else
            {
            UserInterface.WriteColors("Please chose to {=Red}add{/} or {=Red}remove{/} a species");
            }
        }
        while (valid == false);
        oldChecklist.birdChecklist = update;
        return oldChecklist;
    }
}
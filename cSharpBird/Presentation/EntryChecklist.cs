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
                    EntryChecklist.List(UserController.ReadCurrentUser());
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
                    UserMaintenance.UserMenu(UserController.ReadCurrentUser());
                    break;
                    default:
                    Console.WriteLine("Please enter valid selection");
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}. Please key in valid selection for Checklist home menu");
            }
        }
        while (validInput == false);
    }
    public static void Create()
    {
        string hotspot;
        string checklistDate;
        string[] createMenu = {"{=Magenta}NEW CHECKLIST{/}","{=Green}1. Current{/} Checklist","{=Blue}2. Historic{/} Checklist","{=Red}3. Cancel{/}"};
        bool validInput = false;
        string menuRequest;
        User currentUser = UserController.ReadCurrentUser();

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
                    collectInitData();
                    break;
                    case "2":
                    case "2.":
                    case "2. historic":
                    case "past":
                    case "historic":
                    validInput = true;
                    collectInitDataHistoric();
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
                Console.WriteLine($"{e.Message}. Please key in valid selection for Create menu");
            }
        }
        while (validInput == false);
    }
    public static void List(User user)
    {
        List<Checklist> userChecklists = new List<Checklist>();
        userChecklists = ChecklistController.GetLists(user);
        
        string userInput;
        bool validInput = false;

        int widthConsole = Console.WindowWidth;
        int widthColumn = widthConsole / 3;
        int userSelect = 0;
        int listNum = 0;

        string header0 = "Checklist";
        string header1 = "Location";
        string header2 = "Date";
        

        UserInterface.WriteColorsLine("Please enter the {=Blue}Checklist number{/} you'd like to view additional details for, or 0 to go back");
        //Console.WriteLine("{0,-widthColumn}","{1,-widthColumn}",header0,header1);
        UserInterface.WriteColorsLine("{=Blue}Number{/}\tLocation\tDate");
        for (int i = 0; i < userChecklists.Count(); i++)
        {
            listNum = i+1;
            //Console.WriteLine("{0,-widthColumn}","{1,-widthColumn}","{2,widthColumn}",i+1,userChecklists[i].locationName,userChecklists[i].checklistDateTime);
            UserInterface.WriteColors("{=Blue}" + listNum + ".{/}\t");
            Console.Write(userChecklists[i].locationName + "\t" + userChecklists[i].checklistDateTime + "\n");
        }
        try
        {
            do
            {
                userInput = UserInterface.exitChecker(Console.ReadLine().Trim());
                userSelect = Convert.ToInt32(userInput);
                if (userSelect == 0)
                {
                    validInput = true;
                    Menu();
                }
                else if (userSelect < userChecklists.Count())
                {
                    validInput = true;
                    ViewAndAppend(userChecklists[userSelect-1]);
                }
                else
                    Console.WriteLine("Please key in valid checklist number");
            }
            while (validInput == false);
        }
        catch (Exception o)
        {
            Console.WriteLine("Please enter valid checklist number");
        }
    }
    public static void collectInitData()
    {
        User currentUser = UserController.ReadCurrentUser();

        Console.WriteLine("What hotspot should be used for this checklist?");
        string hotspot = Console.ReadLine().Trim();

        Checklist checklist = new Checklist (currentUser.userId,hotspot);
        checklist.birds = BirdController.GetFullBirdList();
        ChecklistController.WriteChecklist(checklist);
        ViewAndAppend(checklist);
    }
    public static void collectInitDataHistoric()
    {
        User currentUser = UserController.ReadCurrentUser();
        Console.WriteLine("When was this checklist taken?");
        string checklistDate = Console.ReadLine().Trim();
        Console.WriteLine("What hotspot should be used for this checklist?");
        string hotspot = Console.ReadLine().Trim();
        Checklist historicChecklist = new Checklist (currentUser.userId,hotspot,checklistDate);
        historicChecklist.birds = BirdController.GetFullBirdList();
        ChecklistController.WriteChecklist(historicChecklist);
        ViewAndAppend(historicChecklist);
    }
    public static void ViewAndAppend(Checklist viewList)
    {
        List<Bird> loggedBirds = new List<Bird>();
        bool userDone = false;
        string userInput = "";
        do
        {
            //loggedBirds = ChecklistController.RetrieveLoggedBirds(viewList);
            //BirdController.WriteBirdsForChecklist(viewList);
            UIChecklist.viewList(viewList);
            UserInterface.WriteColorsLine("Please key a {=Green}band code{/} and the {=Blue}number{/} of that bird seen to log or {=Red}done{/} to finish list");
            try
            {
                userInput = UserInterface.exitChecker(Console.ReadLine().Trim());
                if (userInput.ToLower() == "done" || userInput.ToLower() == "d")
                    userDone = true;
                else if (ChecklistController.ValidListUpdate(userInput))
                {
                    ChecklistController.ListUpdate(userInput,viewList);
                    Console.Clear();
                }
                else 
                {
                    UserInterface.WriteColorsLine("Please key a {=Green}band code{/} and the {=Blue}number{/} of that bird seen to log separated by a space or comma. Key {=Green}band code{/} and '0' to remove");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        while (userDone == false);
        ChecklistController.WriteUpdatedList(viewList);
        Menu();
    }
    public static void Edit(Checklist oldChecklist)
    {
        string editRequest;
        bool validInput = false;
        UserInterface.WriteColorsLine("{=Green}1. Location{/}: " + oldChecklist.locationName + "\t" + "{=Blue}2. Date{/}: "+ oldChecklist.checklistDateTime + "\t" + "{=Yellow)3. Species{/}: " + oldChecklist.birds.Count + "\t" + "{=Red}5. Cancel{/}");
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
                    case "1. location":
                    case "location":
                    validInput = true;
                    //EntryChecklist.View();
                    break;
                    case "2":
                    case "2.":
                    case "2. date":
                    case "date":
                    validInput = true;
                    //UserUpdate(currentSession);
                    break;
                    case "3":
                    case "3.":
                    case "3. species":
                    case "species":
                    case "birds":
                    case "bird":
                    validInput = true;
                    //UserInterface.exitConfirm();
                    break;
                    case "4":
                    case "4.":
                    case "4. cancel":
                    case "cancel":
                    case "exit":
                    case "quit":
                    validInput = true;
                    ViewAndAppend(oldChecklist);
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
    public static Dictionary<int,Bird> addSpecies(Dictionary<int,Bird> speciesList)
    {
        return speciesList;
    }
    public static Dictionary<int,Bird> removeSpecies(Dictionary<int,Bird> speciesList)
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
        string userInput;
        bool valid = false;
        /*
        for (int i = 0; i < update.Count; i++)
        {
            Console.WriteLine($"{i+1}: {update[i].speciesName}");
        }
        UserInterface.WriteColors("Do you need to {=Green}add{/} or {=Red}remove{/} a species?");
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
            UserInterface.WriteColors("Please chose to {=Green}add{/} or {=Red}remove{/} a species");
            }
        }
        while (valid == false);
        oldChecklist.birds = update;
        */
        return oldChecklist;
    }
}
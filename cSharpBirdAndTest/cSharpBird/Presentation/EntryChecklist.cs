namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class EntryChecklist
{
    public static void Menu()
    {
        Console.Clear();
        string[] menu = {"{=Magenta}CHECKLIST MENU{/}","{=Green}1. Create{/} New Checklist","{=Cyan}2. List{/} Existing Checklists","{=Blue}3. Edit{/} Existing Checklist Details","{=Red}4. Exit{/} to Menu."};
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
                    case "view":
                    case "view all":
                    validInput = true;
                    EntryChecklist.List(UserController.ReadCurrentUser());
                    break;
                    case "3":
                    case "3.":
                    case "3. edit":
                    case "edit":
                    case "edit checklist":
                    case "details":
                    validInput = true;
                    EntryChecklist.Edit(UserController.ReadCurrentUser());
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
        Console.Clear();
        List<Checklist> userChecklists = new List<Checklist>();
        userChecklists = ChecklistController.GetLists(user);
        
        string userInput;
        bool validInput = false;

        int userSelect = 0;
        int listNum = 0;

        UIChecklist.ListLists(userChecklists);

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
                else if (userSelect <= userChecklists.Count())
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
    public static void Edit (User user)
    {
        Console.Clear();
        List<Checklist> userChecklists = new List<Checklist>();
        userChecklists = ChecklistController.GetLists(user);
        
        string userInput;
        bool validInput = false;

        int userSelect = 0;
        int listNum = 0;

        UIChecklist.ListEdits(userChecklists);

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
                else if (userSelect <= userChecklists.Count())
                {
                    validInput = true;
                    SelectedEdit(userChecklists[userSelect-1]);
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
    public static void SelectedEdit(Checklist oldChecklist)
    {
        string editRequest;
        bool validInput = false;
        Console.Clear();
        string[] menu = {"What would you like to change on this list today?","{=Green}1. Location{/}: " + oldChecklist.locationName,"{=Cyan}2. Date{/}: "+ oldChecklist.checklistDateTime.ToString("d"),"{=Blue}3. Species{/}: " + ChecklistController.CountListBird(oldChecklist),"{=Yellow}4. Return{/}","{=Red}5. Delete{/} this checklist"};

        UserInterface.menuPrintBase(menu);
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
                    changeLocation(oldChecklist);
                    break;
                    case "2":
                    case "2.":
                    case "2. date":
                    case "date":
                    validInput = true;
                    changeDate(oldChecklist);
                    break;
                    case "3":
                    case "3.":
                    case "3. species":
                    case "species":
                    case "birds":
                    case "bird":
                    validInput = true;
                    ViewAndAppend(oldChecklist);
                    break;
                    case "4":
                    case "4.":
                    case "4. cancel":
                    case "cancel":
                    case "exit":
                    case "quit":
                    case "return":
                    case "back":
                    validInput = true;
                    Edit(UserController.ReadCurrentUser());
                    break;
                    case "5":
                    case "5.":
                    case "5. delete":
                    case "delete":
                    validInput = true;
                    Delete(oldChecklist);
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
        Console.Clear();
        
    }
    public static void changeBirder(Checklist oldChecklist)
    {

    }
    public static void changeLocation(Checklist oldChecklist)
    {
        Console.Clear();
        string descriptor = "{=Green}" + oldChecklist.locationName + "{/} is the current location. Please key a new location or 0 to return to previous menu";
        UserInterface.WriteColorsLine(descriptor);
        string userInput = Console.ReadLine().Trim();
        switch (userInput.ToLower())
        {
            case "0":
            case "back":
            case "done":
            case "return":
                SelectedEdit(oldChecklist);
                break;
            default:
                ChecklistController.LocationUpdate(userInput,oldChecklist);
                descriptor = "Checklist location updated to {=Green}" + userInput + "{/}";
                UserInterface.WriteColorsLine(descriptor);
                Console.ReadKey();
                SelectedEdit(oldChecklist);
                break;
        }
    }
    public static void changeDate(Checklist oldChecklist)
    {
        Console.Clear();
        string descriptor = "{=Green}" + oldChecklist.checklistDateTime + "{/} is the current date. Please key a new date or 0 to return to previous menu";
        UserInterface.WriteColorsLine(descriptor);
        string userInput = Console.ReadLine().Trim();
        switch (userInput.ToLower())
        {
            case "0":
            case "back":
            case "done":
            case "return":
                SelectedEdit(oldChecklist);
                break;
            default:
                ChecklistController.DateUpdate(userInput,oldChecklist);
                descriptor = "Checklist date updated to {=Green}" + userInput + "{/}. Press any key to continue.";
                UserInterface.WriteColorsLine(descriptor);
                Console.ReadKey();
                SelectedEdit(oldChecklist);
                break;
        }
    }
}
namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class UIChecklist
{
    public static void viewList(Checklist xlist)
    {
        //calls submethods appropriately for the arguments passed
        Console.Clear();
        UIChecklist.PrintHeader(xlist);
        List<Bird> loggedBirds = xlist.birds.Where(i => i.numSeen > 0).ToList();
        if (loggedBirds.Count() > 0)
            PrintLoggedBirds(loggedBirds);
    }
    public static void PrintHeader(Checklist xlist)
    {
        User currentUser = UserController.ReadCurrentUser();
        List<Bird> loggedBirds = xlist.birds.Where(i => i.numSeen > 0).ToList();
        string tempName;
        try
        {
            if (currentUser.displayName == null)
                tempName = currentUser.userName;
            else
                tempName = currentUser.displayName;
            UserInterface.WriteColorsLine("{=Magenta}" + tempName + "'s " + xlist.locationName + " checklist for " + xlist.checklistDateTime.ToString("d") + "{/}");
            if (loggedBirds.Count() == 0)
                UserInterface.WriteColorsLine("{=Red}No birds logged yet{/}");
            else
                UserInterface.WriteColorsLine("{=Blue}Species logged: " + loggedBirds.Count() +"{/}");
            UserInterface.menuFillHorizontalEmpty();
        }
        catch (Exception l)
        {
            Console.WriteLine(l.Message);
        }
    }
    public static void PrintLoggedBirds(List<Bird> loggedBirds)
    {
        int i = 0;
        string[] headers = {"{=Green}Band Code{/}","{=Cyan}Species Name{/}","{=Blue}Number Seen{/}"};
        string[] birdData;
        string printLine = string.Format("{0,-15} {1,-35} {2,15}",headers[0],headers[1],headers[2]);
        UserInterface.WriteColorsLine(printLine);
        foreach (Bird b in loggedBirds)
        {
            printLine = string.Format("{0,-15} {1,-35} {2,15}",loggedBirds[i].bandCode,loggedBirds[i].speciesName,loggedBirds[i].numSeen);
            UserInterface.WriteColorsLine(printLine);
            i++;
        }
    }
    /* Deprecated methods
    public static void viewList(Checklist xlist,List<Bird> loggedBirds)
    {
        //calls submethods appropriately for the arguments passed
        UIChecklist.PrintHeader(xlist,loggedBirds);
        if (loggedBirds.Count() > 0)
            PrintLoggedBirds(loggedBirds);
    }
    public static void PrintHeader(Checklist xlist,List<Bird> loggedBirds)
    {
        User currentUser = UserController.ReadCurrentUser();
        string tempName;
        try
        {
            if (currentUser.displayName == null)
                tempName = currentUser.userName;
            else
                tempName = currentUser.displayName;
            UserInterface.WriteColorsLine("{=Magenta}" + tempName + "'s " + xlist.locationName + " checklist for " + xlist.checklistDateTime.ToString("d") + "{/}");
            if (loggedBirds.Count() == 0)
                UserInterface.WriteColorsLine("{=Red}No birds logged yet{/}");
            else
                UserInterface.WriteColorsLine("{=Blue}Species logged: " + loggedBirds.Count() +"{/}");
            UserInterface.menuFillHorizontalEmpty();
        }
        catch (Exception l)
        {
            Console.WriteLine(l.Message);
        }
    }
    public static void PrintLoggedBirds(List<Bird> loggedBirds)
    {
        int i = 0;
        string[] headers = {"{=Green}Band Code{/}","{=Cyan}Species Name{/}","{=Blue}Number Seen{/}"};
        string[] birdData;
        string printLine = string.Format("{0,-10} {1,25} {2,12}",headers[0],headers[1],headers[2]);
        UserInterface.WriteColorsLine(printLine);
        foreach (Bird b in loggedBirds)
        {
            printLine = string.Format("{0,-10} {1,25} {2,12}",loggedBirds[i].bandCode,loggedBirds[i].speciesName,loggedBirds[i].numSeen);
            UserInterface.WriteColorsLine(printLine);
            i++;
        }
    }*/
}
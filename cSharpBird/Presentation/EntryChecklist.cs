namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
public class EntryChecklist
{
    public static void Create()
    {
        
    }
    public static void Edit(Checklist oldChecklist)
    {
        string editRequest;
        bool valid = false;
        Console.WriteLine($"1. Birder: {oldChecklist.birder}\t2. Location: {oldChecklist.locationName}\t3. Date: {oldChecklist.checklistDateTime}\t4. Species: {oldChecklist.birdChecklist.Count}\nWhat do you need to edit?");
        do 
        {
            try
            {
                editRequest = Console.ReadLine();
                /*
                switch (userSelect)
                {
                    case 1:
                    valid = true;
                    changeBirder();
                    break;
                    case 2:
                    valid = true;
                    changeLocation();
                    break;
                    case 3:
                    UserInterface.exit();
                    Console.WriteLine("Please enter a selection to continue");
                    break;
                    default:
                    Console.WriteLine("Please enter valid selection");
                    break;
                }*/
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}. Please key in valid selection");
            }
        }
        while (valid == false);
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
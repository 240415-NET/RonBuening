namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class ChecklistController
{
    public static IAccessChecklistFile AccessChecklistFile = new AccessChecklistFileJson();
    public static List<Checklist> GetLists(User searchUser)
    {
        List<Checklist> userChecklists = AccessChecklistFile.GetLists(searchUser);
        return userChecklists;
    }
    public static void WriteChecklist(Checklist newList)
    {
        AccessChecklistFile.WriteChecklist(newList);
        //BirdController.WriteBirdsForChecklist(newList);
    }
    public static void WriteUpdatedList(Checklist updatedList)
    {
        AccessChecklistFile.WriteUpdatedList(updatedList);
        //BirdController.WriteBirdsForChecklist(updatedList);
    }
    public static List<Bird> RetrieveLoggedBirds(Checklist checklist)
    {
        List<Bird> birdList = BirdController.ReadBirdsForChecklist(checklist);
        birdList = birdList.Where(i => i.numSeen > 0).ToList();
        return birdList;
    }
    public static bool ValidListUpdate(string userInput)
    {
        userInput = userInput.Trim();
        string[] input = userInput.Split(' ',',');
        bool valid = false;
        if (input[0].Length == 4 && Convert.ToInt64(input[1]) > -1)
            valid = true;
        if  (userInput.Length <= 4)
            valid = false;
        return valid;
    }
    public static void ListUpdate(string userInput,Checklist checklist)
    {
        userInput = userInput.Trim();
        string[] input = userInput.Split(' ',',');
        bool valid = false;
        Bird updatedCount = checklist.birds.First(i => i.bandCode == input[0]);
        var checklistLocation = checklist.birds.IndexOf(updatedCount);
        updatedCount.numSeen = int.Parse(input[1]);
        if (checklistLocation != -1)
            checklist.birds[checklistLocation] = updatedCount;
        AccessChecklistFile.WriteUpdatedList(checklist);
        //BirdController.WriteBirdsForChecklist(checklist);
    }
    public static List<Bird> PrintListBird(Checklist checklist)
    {
        List<Bird> birdList = checklist.birds.Where(i => i.numSeen > 0).ToList();
        return birdList;
    }
    public static int CountListBird(Checklist checklist)
    {
        List<Bird> birdList = checklist.birds.Where(i => i.numSeen > 0).ToList();
        int count = birdList.Count();
        return count;
    }
    public static void LocationUpdate(string userInput,Checklist checklist)
    {
        checklist.locationName = userInput;
        AccessChecklistFile.WriteUpdatedList(checklist);
    }
    public static void DateUpdate(string userInput,Checklist checklist)
    {
        checklist.checklistDateTime = DateTime.Parse(userInput);
        AccessChecklistFile.WriteUpdatedList(checklist);
    }
    public static void DeleteChecklist(Checklist checklist)
    {
        AccessChecklistFile.DeleteChecklist(checklist);
    }
}
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
        BirdController.WriteBirdsForChecklist(newList);
    }
    public static void WriteUpdatedList(Checklist updatedList)
    {
        AccessChecklistFile.WriteUpdatedList(updatedList);
        BirdController.WriteBirdsForChecklist(updatedList);
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
    public static void ListUpdate(string userInput)
    {

    }
}
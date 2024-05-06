namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class ChecklistFile
{
    public static List<Checklist> GetLists(User searchUser)
    {
        //Will return the user list for the Users.json file, creating it and adding a defaultUser if file does not already exist
        string pathFile = "Checklists.json";
        List<Checklist> ChecklistArchive = new List<Checklist>();
        List<Checklist> userChecklists = new List<Checklist>();
        string existingChecklistJSON;

        if (File.Exists(pathFile))
        {
            existingChecklistJSON =File.ReadAllText(pathFile);
            ChecklistArchive = JsonSerializer.Deserialize<List<Checklist>>(existingChecklistJSON);
        }
        else if(!File.Exists(pathFile))
        {
            ChecklistArchive.Add(new Checklist(searchUser.userId,"defaultLocation"));
            existingChecklistJSON = JsonSerializer.Serialize(ChecklistArchive);
            File.WriteAllText(pathFile,existingChecklistJSON);
        }
        //IEnumerable<Checklist> temp = ChecklistArchive.Where(i => i.userId == searchUser.userId);
        //userChecklists = temp.ToList();
        userChecklists = ChecklistArchive.Where(i => i.userId == searchUser.userId).ToList();
        return userChecklists;
    }
    public static void WriteChecklist(Checklist newList)
    {
        //This method will write a new Checklist to the json file, creating it if it does not exist.
        string pathFile = "Checklists.json"";
        List<Checklist> ChecklistArchive = new List<Checklist>();
        string existingChecklistJSON;
        if (File.Exists(pathFile))
        {
            existingChecklistJSON =File.ReadAllText(pathFile);
            ChecklistArchive = JsonSerializer.Deserialize<List<Checklist>>(existingChecklistJSON);
            ChecklistArchive.Add(newList);
            existingChecklistJSON = JsonSerializer.Serialize(ChecklistArchive);
            File.WriteAllText(pathFile,existingChecklistJSON);
        }
        else if(!File.Exists(pathFile))
        {
            ChecklistArchive.Add(new Checklist(searchUser.userId,"defaultLocation"));
            existingChecklistJSON = JsonSerializer.Serialize(ChecklistArchive);
            File.WriteAllText(pathFile,existingChecklistJSON);
        }
    }
    public static void WriteUpdatedList(Checklist updatedList)
    {
        //This method will write a new user to the json file, creating it if it does not exist.
        List<Checklist> ChecklistArchive = new List<Checklist>();
        string existingChecklistJSON;

        existingChecklistJSON =File.ReadAllText(pathFile);
        ChecklistArchive = JsonSerializer.Deserialize<List<User>>(existingChecklistJSON);
        User oldUser = ChecklistArchive.First(i => i.userId == updatedUser.userId);
        var userLocation = ChecklistArchive.IndexOf(oldUser);
        if (userLocation != -1)
            ChecklistArchive[userLocation] = updatedUser;
        
        existingChecklistJSON = JsonSerializer.Serialize(ChecklistArchive);
        File.WriteAllText(pathFile,existingChecklistJSON);
    }
}
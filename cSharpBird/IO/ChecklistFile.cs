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
        userChecklists = ChecklistArchive.Where(i => i.userId == searchUser.userId);
        return userChecklists;
    }
}
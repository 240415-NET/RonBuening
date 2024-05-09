namespace cSharpBird;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
public class AccessBirdCSV : IAccessBird
{
    public List<Bird> GetFullBirdList()
    {
        string bandCode = "";
        string speciesName = "";

        string pathFile = "USGSBBL.csv";
        List<Bird> birdList = new List<Bird>();
        birdList = File.ReadAllLines(pathFile)
            .Select(line => line.Split(','))
            .Select(x => new Bird{
                bandCode = x[0],
                speciesName = x[1]
            }).ToList();

        string pathFileTemp = "Birds.json";
        string existingBirdsJSON;
        if (File.Exists(pathFileTemp))
        {
            existingBirdsJSON = JsonSerializer.Serialize(birdList);
            File.WriteAllText(pathFileTemp,existingBirdsJSON);
        }
        else if(!File.Exists(pathFileTemp))
        {
            existingBirdsJSON = JsonSerializer.Serialize(birdList);
            File.WriteAllText(pathFileTemp,existingBirdsJSON);
        }

        return birdList;
    }
    public void WriteBirdsForChecklist (Checklist checklist)
    {
        string path = "checklist\\" + checklist.checklistID;
        string pathFile = path + "\\birds.json";
        if (File.Exists(pathFile))
        {
            string existingChecklistJSON = JsonSerializer.Serialize(checklist.birds);
            File.WriteAllText(pathFile,existingChecklistJSON);
        }
        else if (!File.Exists(pathFile))
        {
            Directory.CreateDirectory(path);
            string existingChecklistJSON = JsonSerializer.Serialize(checklist.birds);
            File.WriteAllText(pathFile,existingChecklistJSON);
        }
    }
    public List<Bird> ReadBirdsForChecklist (Checklist checklist)
    {
        string path = "checklist\\" + checklist.checklistID;
        string pathFile = path + "\\birds.json";
        List<Bird> birdList = new List<Bird>();
        if (File.Exists(pathFile))
        {
            string existingChecklistJSON = File.ReadAllText(pathFile);
            birdList = JsonSerializer.Deserialize<List<Bird>>(existingChecklistJSON);
        }
        else if (!File.Exists(pathFile))
        {
            Directory.CreateDirectory(path);
            string existingChecklistJSON = File.ReadAllText(pathFile);
            birdList = JsonSerializer.Deserialize<List<Bird>>(existingChecklistJSON);
        }
        return birdList;
    }
}
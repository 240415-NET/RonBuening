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
            File.WriteAllText(pathFileTemp,existingUsersJSON);
        }
        else if(!File.Exists(pathFileTemp))
        {
            existingBirdsJSON = JsonSerializer.Serialize(birdList);
            File.WriteAllText(pathFileTemp,existingUsersJSON);
        }

        return birdList;
    }
}